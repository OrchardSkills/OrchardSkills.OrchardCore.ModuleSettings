using System;
using OrchardCore.Entities;
using OrchardCore.Settings;
using System.Device.Gpio;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.Settings;

namespace OrchardSkills.OrchardCore.RaspberryPi.Devices
{
    public class RelayDevice : IDisposable
    {
        private GpioController _controller;
        private bool disposedValue = false;
        private object _locker = new object();
        private bool relaySupported = true;
        private int relayGpioPin = 17;
        private readonly ISiteService _siteService;
        public RelayDevice(ISiteService siteServive)
        {
            try
            {
                _siteService = siteServive;
                var raspberryPiRelaySettings = _siteService.GetSiteSettingsAsync()
                    .GetAwaiter().GetResult()
                    .As<RaspberryPiRelaySettings>();
                relayGpioPin = raspberryPiRelaySettings.GpioPin;
                _controller = new GpioController();
                _controller.OpenPin(relayGpioPin, PinMode.Output);
                _controller.Write(relayGpioPin, PinValue.Low);
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
                RelayGpioPin = relayGpioPin;
            }
        }

        public bool IsReplaySupported { get; private set; }
        public bool IsReplayOn { get; private set; }
        public int RelayGpioPin { get; private set; }
        public void ReplayOn()
        {
            lock (_locker)
            {
                if (relaySupported) _controller.Write(relayGpioPin, PinValue.High);

                IsReplayOn = true;
            }
        }

        public void ReplayOff()
        {
            lock (_locker)
            {
                if (relaySupported) _controller.Write(relayGpioPin, PinValue.Low);

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
