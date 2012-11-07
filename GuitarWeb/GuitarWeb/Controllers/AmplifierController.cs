using System.Web.Mvc;

namespace GuitarWeb.Controllers
{
    public class AmplifierController : Controller
    {
        //
        // GET: /Amplifier/

        public ActionResult AmplifierList()
        {
            ViewBag.Message = "My Amps";
            return View();
        }

    }
}
