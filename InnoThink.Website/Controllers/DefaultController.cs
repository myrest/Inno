using System.Web.Mvc;

namespace InnoThink.Website.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            return View();
        }
    }
}