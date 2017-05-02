namespace Rx.NET_Serial_Port_Example
{
    public interface ISerialPortDevice
    {
        void ObserveDataReceived(double timeout = 10);
    }
}