using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Rx.NET_Serial_Port_Example
{
    public class SerialPortDevice
    {
        private readonly ISerialPort _serialPort;
        private readonly IDataParser _dataParser;
        private readonly IScheduler _scheduler;

        public SerialPortDevice(ISerialPort serialPort, IDataParser dataParser, IScheduler scheduler)
        {
            _serialPort = serialPort;
            _dataParser = dataParser;
            _scheduler = scheduler;
        }

        public void ObserveDataReceived(double timeout = 10d)
        {
            var dataReceivedObservable = Observable.FromEvent<SerialPort.DataReceivedEventHandler, string>(
                    x => _serialPort.DataReceived += x,
                    x => _serialPort.DataReceived -= x);

            //read data and parse only on changes
            dataReceivedObservable
                .DistinctUntilChanged()
                .Subscribe(OnDataReceived);

            //detect that there is no information from device for specified number of seconds
            dataReceivedObservable.Throttle(TimeSpan.FromSeconds(timeout), _scheduler).Subscribe(x =>
             {
                 OnDataError($"Serial port data timeout [{timeout}s]");
             });
        }


        private void OnDataError(string message)
        {
            throw new TimeoutException(message);
        }

        private void OnDataReceived(string message)
        {
            var result = _dataParser.Parse(message);
        }

    }
}
