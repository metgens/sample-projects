namespace Rx.NET_Serial_Port_Example
{
    public interface IDataParser
    {
        DeviceOutput Parse(string message);
    }
}