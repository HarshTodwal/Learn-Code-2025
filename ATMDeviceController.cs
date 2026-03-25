using ATM.Exceptions;
using ATM.Interfaces;

namespace ATM;

public class ATMDeviceController
{
    private const string PrimaryDevice = "DEV1";
    private readonly IATMGateway _gateway;

    public ATMDeviceController(IATMGateway gateway)
    {
        _gateway = gateway;
    }

    public void Withdraw(string accountId, double amount)
    {
        var handle = _gateway.GetHandle(PrimaryDevice);
        var record = _gateway.GetDeviceRecord(handle);

        ValidateDevice(record);
        ValidateFunds(accountId, amount);

        _gateway.DispenseCash(handle, amount);
    }

    public bool TryWithdraw(string accountId, double amount)
    {
        try
        {
            Withdraw(accountId, amount);
            return true;
        }
        catch (DeviceLockedException ex)
        {
            Console.WriteLine($"Device locked: {ex.Message}");
        }
        catch (NetworkConnectionException ex)
        {
            Console.WriteLine($"Network error: {ex.Message}");
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Declined: {ex.Message}");
        }

        return false;
    }

    private void ValidateDevice(DeviceRecord record)
    {
        if (record.Status == DeviceStatus.Suspended)
            throw new DeviceLockedException();

        if (record.Network != NetworkStatus.Connected)
            throw new NetworkConnectionException();
    }

    private void ValidateFunds(string accountId, double amount)
    {
        double balance = _gateway.GetBalance(accountId);

        if (balance < amount)
            throw new InsufficientFundsException(amount, balance);
    }
}
