using System.Collections.Generic;
using System.Web.Mvc;
using GuitarWeb.Interfaces;
using GuitarWeb.Models;
using GuitarWeb.Repository;
using System.Linq;


namespace GuitarWeb.Controllers
{
    public class GuitarController : Controller
    {
        private readonly IGuitarRepository _guitarRepository = new GuitarRepository();

        public ActionResult GuitarList()
        {
            ViewBag.Message = "All your guitars";

            return View(_guitarRepository.GetGuitars());
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Message = "All your guitars";

            return View(_guitarRepository.GetGuitarById(id));
        }

        [HttpPost]
        public JsonResult GetGuitar(string id)
        {
            return Json(_guitarRepository.GetGuitarById(id));
        }

        [HttpPost]
        public JsonResult GetGuitars()
        {
            return Json(_guitarRepository.GetGuitars());
        }
        

        [HttpPost] 
        public ViewResult Edit(Guitar guitar) { 

            if (!TryUpdateModel(guitar)) { 
                ViewBag.updateError = "Update Failure"; 
                return View(guitar); 
            }

            var guitars = _guitarRepository.GetGuitars();

            UpdateGuitarsWithChanges(guitars, guitar);

            _guitarRepository.SaveGuitars(guitars);
 
            return View("GuitarList", _guitarRepository.GetGuitars()); 
        }

        [HttpPost]
        public ActionResult Delete(string guitarId)
        {
            var guitars = _guitarRepository.GetGuitars();

            var guitarToDelete = (from g in guitars where g.RegNumber == guitarId select g).FirstOrDefault();

            if (guitarToDelete != null)
            {
                guitars.Remove(guitarToDelete);

                _guitarRepository.SaveGuitars(guitars);
            }

            return Json(guitars);
        }

        public ActionResult New()
        {
            ViewBag.Message = "New guitar";

            return View(new Guitar());
        }

        [HttpPost]
        public ViewResult New(Guitar guitar)
        {
            var guitars = _guitarRepository.GetGuitars();

            guitars.Add(guitar);

            _guitarRepository.SaveGuitars(guitars);

            return View("GuitarList", guitars);
        }

       

        private void UpdateGuitarsWithChanges(IEnumerable<Guitar> guitars, Guitar guitar)
        {
            var editedGuitar = guitars.Where(g => g.RegNumber == guitar.RegNumber).FirstOrDefault();

            if (editedGuitar != null)
            {
                editedGuitar.ProductionYear = guitar.ProductionYear;
                editedGuitar.Model = guitar.Model;
            }
                
        }
    }
}
