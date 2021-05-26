using Assignment3.Models;
using Assignment3.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private INurseRepository repository;
        private IWebHostEnvironment iHost;

        public HomeController(IWebHostEnvironment iHost, INurseRepository nurseRepository)
        {
           repository = nurseRepository;
           //repository = new NurseRepository();
            this.iHost = iHost;
        }

        public IActionResult Index()
        {
            IEnumerable<Nurse> nurses = repository.ShowAllNurses();
            return View(nurses);
        }
        public ViewResult NurseDetails(int id)
        {
            HomeNurseDetailsViewModel hnvm = new HomeNurseDetailsViewModel();
            Nurse nurse = repository.GetNurse(id);
            hnvm.Nurse = nurse;
            hnvm.Title = "Nurse Details Page";
            return View(hnvm);
            //Nurse nurse = repository.GetNurse(id);
           // return View(nurse);
         
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NurseCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo!=null)
                {
                    string uploadFolder=Path.Combine(iHost.WebRootPath,"img");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    model.Photo.CopyTo(fileStream);
                }
                Nurse newNurse = new Nurse()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Section = model.Section,
                    PhotoName = uniqueFileName
                };
                repository.Add(newNurse);

                
                return RedirectToAction("NurseDetails", new { newNurse.Id });
            }
            return View();
            
        }
        
    }
}
