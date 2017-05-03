using System;
using Microsoft.Reactive.Testing;
using Moq;
using NUnit.Framework;

namespace Rx.NET_Serial_Port_Example.Tests.SerialPortDeviceTests
{
    [TestFixture]
    public class SerialPortDeviceTests
    {

        public class ObserveDataReceived : SerialPortDeviceTests
        {
            private Mock<IDataParser> _dataParserMock;
            private Mock<ISerialPort> _serialPortMock;

            [SetUp]
            public void Setup()
            {

                _serialPortMock = new Mock<ISerialPort>();
                _dataParserMock = new Mock<IDataParser>();
            }


            [Test]
            public void For2InputEvents_ShouldExecuteDataParserTwice()
            {
                var testScheduler = new TestScheduler();

                //arrange
                var target = new SerialPortDevice(_serialPortMock.Object, _dataParserMock.Object, testScheduler);

                //act

                target.ObserveDataReceived(10d);

                //input events
                _serialPortMock.Raise(port => port.DataReceived += null, "Test message 1");
                _serialPortMock.Raise(port => port.DataReceived += null, "Test message 2");

                //assert
                _dataParserMock.Verify(x => x.Parse(It.Is<string>(y => y == "Test message 1")),Times.Once);
                _dataParserMock.Verify(x => x.Parse(It.Is<string>(y => y == "Test message 2")),Times.Once);

            }


            [Test]
            public void For2SameInputEvents_ShouldExecuteDataParserOnce()
            {
                var testScheduler = new TestScheduler();

                //arrange
                var target = new SerialPortDevice(_serialPortMock.Object, _dataParserMock.Object, testScheduler);

                //act

                target.ObserveDataReceived(10d);

                //input events
                _serialPortMock.Raise(port => port.DataReceived += null, "Test message 1");
                _serialPortMock.Raise(port => port.DataReceived += null, "Test message 1");

                //assert
                _dataParserMock.Verify(x => x.Parse(It.IsAny<string>()), Times.Once);

            }


            [Test]
            public void ForNoInputFor20sec_ShouldThrowTimeoutException()
            {
                var testScheduler = new TestScheduler();
                //arrange
                var target = new SerialPortDevice(_serialPortMock.Object, _dataParserMock.Object, testScheduler);

                //act && assert
                try
                {
                    target.ObserveDataReceived(10d);

                    //input event
                    _serialPortMock.Raise(port => port.DataReceived += null, "Test message");
                    //wait 20 sec. - more than timeout limit
                    testScheduler.AdvanceBy(TimeSpan.FromSeconds(20).Ticks);
                    Assert.Fail("No exception was thrown");

                }
                catch (Exception ex)
                {
                    Assert.IsTrue(ex is TimeoutException);
                }


            }


            [Test]
            public void ForNoInputFor5sec_ShouldNotThrowTimeoutException()
            {
                var testScheduler = new TestScheduler();
                //arrange
                var target = new SerialPortDevice(_serialPortMock.Object, _dataParserMock.Object, testScheduler);

                //act && assert
                try
                {
                    target.ObserveDataReceived(10d);

                    //input event
                    _serialPortMock.Raise(port => port.DataReceived += null, "Test message");
                    //wait 5 sec - less than timeout limit
                    testScheduler.AdvanceBy(TimeSpan.FromSeconds(5).Ticks);

                }
                catch (Exception ex)
                {
                    Assert.Fail("Exception was thrown but it shouldn't");

                }


            }
        }
    }
}
