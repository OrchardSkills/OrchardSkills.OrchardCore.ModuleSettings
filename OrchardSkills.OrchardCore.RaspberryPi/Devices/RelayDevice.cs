using System;
using System.Device.Gpio;

namespace OrchardSkills.OrchardCore.RaspberryPi.Devices
{
    public class RelayDevice : IDisposable
    {
        private const int gpioPin = 17;

        private GpioController _controller;
        private bool disposedValue = false;
        private object _locker = new object();
        private bool relaySupported = true;
        public RelayDevice()
        {
            try
            {
                _controller = new GpioController();
                _controller.OpenPin(gpioPin, PinMode.Output);
                _controller.Write(gpioPin, PinValue.Low);
                IsReplayOn = false;
            }
            catch (Exception ex)
            {
                relaySupported = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsReplaySupported = relaySupported;
            }
        }

        public bool IsReplaySupported { get; private set; }
        public bool IsReplayOn { get; private set; }

        public void ReplayOn()
        {
            lock (_locker)
            {
                if (relaySupported) _controller.Write(gpioPin, PinValue.High);

                IsReplayOn = true;
            }
        }

        public void ReplayOff()
        {
            lock (_locker)
            {
                if (relaySupported) _controller.Write(gpioPin, PinValue.Low);

                IsReplayOn = false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (relaySupported) _controller.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
