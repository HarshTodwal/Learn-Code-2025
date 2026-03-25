namespace ATM.Exceptions;

public class DeviceLockedException : Exception
{
    public DeviceLockedException() : base("ATM device is suspended.") { }
}

public class InsufficientFundsException : Exception
{
    public double Requested { get; }
    public double Available { get; }

    public InsufficientFundsException(double requested, double available)
        : base($"Requested {requested:C} but only {available:C} available.")
    {
        Requested = requested;
        Available = available;
    }
}

public class NetworkConnectionException : Exception
{
    public NetworkConnectionException() : base("ATM is not connected to the network.") { }
}
