using Microsoft.AspNetCore.Mvc;
using NostalgiaApp.Data;
using NostalgiaApp.Models;
using System.Collections.Generic;

namespace NostalgiaApp.Controllers
{
    [Route("nostalgia")]
    public class NostalgiaController : Controller
    {
        private INostalgiaDao _nostalgiaDao;

        public NostalgiaController(INostalgiaDao nostalgiaDao)
        {
            _nostalgiaDao = nostalgiaDao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ExistingNostalgiaReminders()
        {
            ExistingNostalgiasViewModel vm = new ExistingNostalgiasViewModel();

            vm.Nostalgias.AddRange(_nostalgiaDao.GetNostalgias());
            
            return View(vm);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddNostalgia()
        {           
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddNostalgiaToDb([Bind("Title,Description")] Nostalgia nostalgia)
        {
            _nostalgiaDao.SaveNostalgia(nostalgia);
            return RedirectToAction("ExistingNostalgiaReminders");            
        }
    }
}
