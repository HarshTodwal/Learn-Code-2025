using System;
using System.Collections.Generic;

namespace Payment.Processing
{
    public class PaymentProcessor
    {
        private const int MAX_RETRIES = 2;
        private static readonly decimal MIN_AMOUNT = 0.01m;
        private static readonly decimal MAX_PAYMENT_LIMIT = 5000m;
        private const string PAYMENT_SUCCESS = "Payment successful";
        private const string PAYMENT_FAILED = "Payment failed";

        private readonly ILogger _logger;
        private readonly INotificationService _notifier;
        private readonly Dictionary<string, PaymentRecord> _history;

        public PaymentProcessor(ILogger logger, INotificationService notifier)
        {
            _logger = logger;
            _notifier = notifier;
            _history = new Dictionary<string, PaymentRecord>();
        }

        public PaymentResult Process(PaymentRequest request)
        {
            int attempt = 0;
            Validate(request);

            while (attempt < MAX_RETRIES)
            {
                try
                {
                    Execute(request);
                    Record(request);
                    NotifySuccess(request);

                    return new PaymentResult(true, PAYMENT_SUCCESS, GenerateId());
                }
                catch (PaymentException)
                {
                    attempt++;
                    _logger.Log($"Retry attempt: {attempt}");
                }
            }

            return new PaymentResult(false, PAYMENT_FAILED, null);
        }

        private void Validate(PaymentRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CustomerId))
                throw new ArgumentException("Customer ID required");

            if (request.Amount == null || request.Amount < MIN_AMOUNT)
                throw new ArgumentException("Invalid amount");
        }

        private void Execute(PaymentRequest request)
        {
            _logger.Log($"Executing payment of {request.Amount}");

            if (request.Amount > MAX_PAYMENT_LIMIT)
                throw new PaymentException("Limit exceeded");
        }

        private void Record(PaymentRequest request)
        {
            _history.Add(
                GenerateId(),
                new PaymentRecord(
                    request.CustomerId,
                    request.Amount,
                    DateTime.Now
                )
            );
        }

        private void NotifySuccess(PaymentRequest request)
        {
            _notifier.Send(
                request.CustomerId,
                $"Payment of {request.Amount} processed"
            );
        }

        private string GenerateId()
        {
            return $"TXN-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
        }
    }
}
