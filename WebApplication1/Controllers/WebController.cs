using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class WebController : Controller
    {

        readonly IWebRepository _webRepository;

        public WebController(IWebRepository webRepository)
        {
            _webRepository = webRepository;
        }

        public ActionResult Create()
        {
            return View(new WebViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WebViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View(_webRepository.CreateViewModel(collection.Url));
                }
                else
                {
                    return View(collection);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(collection);
            }
        }

    }
}
