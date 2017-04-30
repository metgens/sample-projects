namespace Rx.NET_Serial_Port_Example
{
    public interface ISerialPort
    {
        event SerialPort.DataReceivedEventHandler DataReceived;
    }

    public class SerialPort : ISerialPort
    {
        public delegate void DataReceivedEventHandler(string data);

        public event DataReceivedEventHandler DataReceived;
    }
}