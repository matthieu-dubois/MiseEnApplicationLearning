
using MiseEnApplicationASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiseApplicationLearning.Controllers
{
    public class UtilisateursController : Controller
    {

        List<int> Age = new List<int>()
        {
            22 , 23
        };

        MiseApplicationLearningEntities ContextEF = new MiseApplicationLearningEntities();

        // GET: Utilisateurs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {

            var utilisateurs = ContextEF.Utilisateurs.ToList();

            return View(utilisateurs);

        }

        public ActionResult Edit(int id)
        {
            Utilisateurs utilisateurs = ContextEF.Utilisateurs.Single(u => u.id == id);

            return View(utilisateurs);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "id , Prenom , Nom , Age")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                ContextEF.Entry(utilisateurs).State = EntityState.Modified;
                ContextEF.SaveChanges();

                return RedirectToAction("List");

            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            Utilisateurs utilisateurs = ContextEF.Utilisateurs.Single(u => u.id == id);

            return View(utilisateurs);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            Utilisateurs utilisateurs = ContextEF.Utilisateurs.Single(u => u.id == id);
            ContextEF.Utilisateurs.Remove(utilisateurs);
            ContextEF.SaveChanges();

            //Utilisateurs utilisateurs = ContextEF.Utilisateurs.Find(id);
            //ContextEF.Utilisateurs.Remove(utilisateurs);
            //ContextEF.SaveChanges();


            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "id , Prenom , Nom , Age")] Utilisateurs utilisateurs)
        {
            ContextEF.Utilisateurs.Add(utilisateurs);
            ContextEF.SaveChanges();

            var utilisateurss = ContextEF.Utilisateurs.ToList();

            //return RedirectToAction("List");

            return View(utilisateurss);

        }

        public ActionResult Create()
        {
            ViewBag.Mdu = Age;

            return View();
        }
    }
}
