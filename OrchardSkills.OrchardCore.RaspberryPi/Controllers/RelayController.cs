using Microsoft.AspNetCore.Mvc;
using OrchardSkills.OrchardCore.RaspberryPi.Devices;

namespace OrchardSkills.OrchardCore.RaspberryPi.Controllers
{
    public class RelayController : Controller
    {
        
        private readonly RelayDevice _relayDevice;

        public RelayController(RelayDevice relayDevice)
        {
            _relayDevice = relayDevice;
        }

        public IActionResult Index()
        {
            ViewBag.ReplaySupported = _relayDevice.IsReplaySupported ? "Yes" : "No";
            ViewBag.ReplayState = _relayDevice.IsReplayOn ? "On" : "Off";
            ViewBag.RelayGpioPin = _relayDevice.RelayGpioPin.ToString();
            return View();
        }

        public IActionResult ReplayOn()
        {
            _relayDevice.ReplayOn();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReplayOff()
        {
            _relayDevice.ReplayOff();

            return RedirectToAction(nameof(Index));
        }
    }
}
