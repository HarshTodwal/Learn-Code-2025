namespace ATM.Interfaces;

public enum DeviceStatus { Active, Suspended }
public enum NetworkStatus { Connected, Disconnected }

public class DeviceHandle
{
    public static readonly DeviceHandle Invalid = new(false);
    public bool IsValid { get; }
    public DeviceHandle(bool isValid = true) => IsValid = isValid;
}

public class DeviceRecord
{
    public DeviceStatus Status { get; set; }
    public NetworkStatus Network { get; set; }
}

public interface IATMGateway
{
    DeviceHandle GetHandle(string deviceId);
    DeviceRecord GetDeviceRecord(DeviceHandle handle);
    double GetBalance(string accountId);
    void DispenseCash(DeviceHandle handle, double amount);
}
