using Assignment3.Models;
using Assignment3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private INurseRepository repository;

        public HomeController(/*INurseRepository nurseRepository*/)
        {
           // repository = nurseRepository;
           repository = new NurseRepository();
        }

        public IActionResult Index()
        {
            IEnumerable<Nurse> nurses = repository.getAll();
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
        public ActionResult Create(Nurse nurse)
        {
            if(ModelState.IsValid)
            {
                Nurse newNurse=repository.Add(nurse);
                return RedirectToAction("NurseDetails", new { newNurse.Id });
            }
            return View();
            
        }
        
    }
}
