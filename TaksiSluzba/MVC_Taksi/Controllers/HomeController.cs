using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Taksi.Models;

namespace MVC_Taksi.Controllers
{
    public class HomeController : Controller
    {
        KorisnikRepository _KorisnikRepository = new KorisnikRepository();



        #region Login success are fails

        public ActionResult Index(string korisnickoIme, string lozinka)
        {
            try
            {
                List<Korisnik> SviKorisnici = new List<Korisnik>();
                Korisnik korisnik = new Korisnik();


                if (Session["KorisnikData"] != null)
                {
                    korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
                    return View(korisnik);
                }


                if (TempData["mySesstion0"] != null)
                {
                    korisnickoIme = TempData["mySesstion0"].ToString(); 
                    lozinka = TempData["mySesstion1"].ToString();
                }


                if (korisnickoIme != null && lozinka != null)
                {
                    SviKorisnici = _KorisnikRepository.UzmiKorisnike().Where(s => s.KorisnickoIme == korisnickoIme && s.Lozinka == lozinka).ToList();

                    korisnik = _KorisnikRepository.GetKorisnik(korisnickoIme, lozinka);

                    //if (SviKorisnici.Count != 0)
                    if (korisnik != null)
                    {
                        Session["KorisnikData"] = SviKorisnici[0].KorisnickoIme;
                        TempData["KorisnickoIme"] = SviKorisnici[0].KorisnickoIme;
                        TempData["Lozinka"] = SviKorisnici[0].Lozinka;
                        return View(korisnik);
                    }
                    else
                    {
                        TempData["ErrorLogin"] = "Korisnicko ime i/ili lozinka nisu ispravni...";
                        return View("../Home/LoginPage");
                    }
                }
                else
                {
                    return View("../Home/LoginPage");
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }
        #endregion


        #region Registracija

        [HttpGet]
        public ActionResult Registracija()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registracija(Korisnik korisnik, HttpPostedFileBase file)
        {
            //try
            {
                
                _KorisnikRepository.InsertKorisnik(korisnik);

                TempData["mySesstion0"] = korisnik.KorisnickoIme; TempData["mySesstion1"] = korisnik.Lozinka;
                return RedirectToAction("../Home/Index");
            }
            //catch (Exception)
           // {
                throw new NotImplementedException();
           // }
        }
        #endregion


        #region Registracija izmena

        [HttpGet]
        public ActionResult RegistracijaIzmena(string korisnickoime )
        {
            try
            {
                return View(_KorisnikRepository.GetKorisnik(korisnickoime));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult RegistracijaIzmena(Korisnik korisnik)
        {
            try
            {
                _KorisnikRepository.EditKorisnik(korisnik);
                //TempData["Sucss"] = "You are record update successfully..";
                //TempData["mySesstion0"] = korisnik.Email; TempData["mySesstion1"] = korisnik.Lozinka;
                return RedirectToAction("../Home/Index");
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        #endregion


        #region session Log off controlle

        public ActionResult Signout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        #endregion




       
    }
}