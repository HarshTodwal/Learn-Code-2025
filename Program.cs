using ATM;
using ATM.Interfaces;

var gateway = new StubGateway(300);
var atm = new ATMDeviceController(gateway);

atm.TryWithdraw("ACC-001", 200);
atm.TryWithdraw("ACC-001", 9999);

public class StubGateway : IATMGateway
{
    private readonly double _balance;
    public StubGateway(double balance) => _balance = balance;

    public DeviceHandle GetHandle(string id) => new DeviceHandle();
    public DeviceRecord GetDeviceRecord(DeviceHandle h) => new DeviceRecord
    {
        Status = DeviceStatus.Active,
        Network = NetworkStatus.Connected
    };
    public double GetBalance(string accountId) => _balance;
    public void DispenseCash(DeviceHandle h, double amount) =>
        Console.WriteLine($"Dispensed {amount:C} successfully.");
}
