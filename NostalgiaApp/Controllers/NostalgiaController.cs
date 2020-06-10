using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NostalgiaApp.Data;
using NostalgiaApp.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;

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

            var nostalgias = _nostalgiaDao.GetNostalgias();

            foreach(var nostalgia in nostalgias)
            {
                vm.Nostalgias.Add(mapNostalgiaModel(nostalgia));                
            }           
            
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
        public IActionResult AddNostalgiaToDb([Bind("Title,Description")] Nostalgia nostalgia, IFormFile File)
        {                      
            if (File != null)
            {
                if (File.Length > 0)
                {
                    var image = Image.Load(File.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    
                    string imageString = image.ToString();

                    using (var ms = new MemoryStream())
                    {                        
                        image.Save(ms, Image.DetectFormat(File.OpenReadStream()));
                        nostalgia.Image = ms.ToArray();
                    }
                }
            }

            _nostalgiaDao.SaveNostalgia(nostalgia);
            return RedirectToAction("ExistingNostalgiaReminders");            
        }

        private NostalgiaViewModel mapNostalgiaModel(Nostalgia nostalgia)
        {
            NostalgiaViewModel model = new NostalgiaViewModel();

            model.Id = nostalgia.Id;
            model.Title = nostalgia.Title;
            model.Description = nostalgia.Description;
            model.CreateDate = nostalgia.CreateDate;
            model.NextReminderDate = nostalgia.NextReminderDate;

            if (nostalgia.Image != null && nostalgia.Image.Length > 0)
            {
                string imageBase64Data =
                    Convert.ToBase64String(nostalgia.Image);

                model.Image = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            }

            return model;
        }
    }
}
