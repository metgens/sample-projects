namespace Rx.NET_Serial_Port_Example
{
    public interface ISerialPort
    {
        event SerialPort.DataReceivedEventHandler DataReceived;
    }
}