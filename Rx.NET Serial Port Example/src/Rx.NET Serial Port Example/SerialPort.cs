namespace Rx.NET_Serial_Port_Example
{
    public class SerialPort : ISerialPort
    {
        public delegate void DataReceivedEventHandler(string data);

        public event DataReceivedEventHandler DataReceived;
    }
}