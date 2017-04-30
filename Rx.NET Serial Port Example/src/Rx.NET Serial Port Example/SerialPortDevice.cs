using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Rx.NET_Serial_Port_Example
{
    public class SerialPortDevice
    {
        private readonly ISerialPort _serialPort;
        private readonly IDataParser _dataParser;

        public SerialPortDevice(ISerialPort serialPort, IDataParser dataParser)
        {
            _serialPort = serialPort;
            _dataParser = dataParser;
        }

        public void ObserveDataReceived()
        {
            var dataReceivedObservable = Observable.FromEvent<SerialPort.DataReceivedEventHandler, string>(
                    x => _serialPort.DataReceived += x,
                    x => _serialPort.DataReceived -= x);

            //read data and parse only on changes
            dataReceivedObservable
                .DistinctUntilChanged()
                .Subscribe(OnDataReceived);

            //detect that there is no information from device for 10 second
            dataReceivedObservable.Throttle(TimeSpan.FromSeconds(10)).Subscribe(x =>
            {
                OnDataError($"Data timeout");
            });
        }


        private void OnDataError(string message)
        {
            Debug.WriteLine(message);
        }

        private void OnDataReceived(string message)
        {
            var result = _dataParser.Parse(message);
            Debug.WriteLine($"Value: '{result}' from raw message: '{message}'");
        }

    }
}
