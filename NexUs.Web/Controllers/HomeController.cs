using Microsoft.AspNetCore.Mvc;
using NexUs.Core.Application.Dtos.Email;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Web.Models;
using System.Diagnostics;

namespace NexUs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

  
        

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            _emailService.SendAsync(new EmailRequest
            {
                To = "yeury.dcm2406@gmail.com",
                Subject = "TestMessage",
                Body = "<h1>Felicidades!! </h1> <p>Pudiste Configurar correcetamente el <b>envío de correos!!</b></p>"
            });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
