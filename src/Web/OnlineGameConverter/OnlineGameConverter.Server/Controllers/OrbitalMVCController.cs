using Microsoft.AspNetCore.Mvc;
using OnlineGameConverter.Server.Classes.Orbital;

namespace OnlineGameConverter.Server.Controllers
{
    public class OrbitalMVCController : Controller
    {
         Performer performer = new();

        [HttpGet]
        public ViewResult OrbitalMVCForm()
        {
            OrbitalForecastConditionNumber init = performer.GetInitialNumber();
            OrbitalForecastConditionDateTime o = new OrbitalForecastConditionDateTime(init);
            o.Begin = DateTime.Now;
            o.End = DateTime.Now + TimeSpan.FromDays(1);
            return View("/Views/OrbitalMVC/OrbitalMVCForm.cshtml", o);
        }

        [HttpPost]
        public ViewResult OrbitalMVCForm(OrbitalForecastConditionDateTime init)
        {
            var t = new CancellationToken();
            var x = performer.CalculateOrbitalForecastItemDateTime(init, t);
            if (ModelState.IsValid)
            {
                init.Items = x;
                return View("/Views/OrbitalMVC/OrbitalMVCForm.cshtml", init);
            }
            return View();
        }

        /*


                [HttpGet]
                public ViewResult OrbitalMVCForm()
                {
                    return View();
                }


                // GET: OrbitalMVCController/Create
                public ActionResult Create()
                {
                    return View();
                }
        /*
                // POST: OrbitalMVCController/Create
                [HttpGet]
             //   [ValidateAntiForgeryToken]
                public ActionResult OrbitalMVCForm(OrbitalForecastConditionNumber condition)
                {
                   try
                    {
                        var r = performer.CalculateOrbitalForecastItemNumber(condition);
                        return View(r);
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: OrbitalMVCController/Edit/5
                public ActionResult Edit(int id)
                {
                    return View();
                }

                // POST: OrbitalMVCController/Edit/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: OrbitalMVCController/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: OrbitalMVCController/Delete/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Delete(int id, IFormCollection collection)
                {
                    try
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }*/
    }
}
