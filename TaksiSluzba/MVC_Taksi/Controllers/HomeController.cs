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
        AutomobilRepository _AutomobilRepository = new AutomobilRepository();
        VozacRepository _VozacRepository = new VozacRepository();
        VoznjeRepository _VoznjeRepository = new VoznjeRepository();
        Korisnik korisnik = new Korisnik();
        Vozac vozac = new Vozac();

        #region Login success are fails

        public ActionResult Index(string korisnickoIme, string lozinka)
        {
            try
            {
                List<Korisnik> SviKorisnici = new List<Korisnik>();



                if (Session["KorisnikData"] != null)
                {
                    korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
                    vozac = _VozacRepository.GetVozac(Session["KorisnikData"].ToString());
                    TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                    TempData["Lozinka"] = korisnik.Lozinka;
                    TempData["Uloga"] = korisnik.Uloga;
                    TempData["Ime"] = korisnik.Ime;
                    TempData["Prezime"] = korisnik.Prezime;
                    TempData["Pol"] = korisnik.Pol;
                    TempData["JMBG"] = korisnik.JMBG;
                    TempData["KontaktTelefon"] = korisnik.KontaktTelefon;
                    if (vozac != null)
                        TempData["Lokacija"] = vozac.Lokacija;
                    TempData["Email"] = korisnik.Email;

                    if (korisnik.Uloga.ToString() == "VOZAC")
                    {
                        return View(_VoznjeRepository.UzmiVoznje().Where(s => s.Vozac == korisnik.KorisnickoIme).ToList());
                    }
                    else if (korisnik.Uloga.ToString() == "MUSTERIJA")
                    {
                        return View(_VoznjeRepository.UzmiVoznje().Where(s => s.Musterija == korisnik.KorisnickoIme).ToList());
                    }
                    else
                    {
                        return View(_VoznjeRepository.UzmiVoznje().Where(s => s.Dispecer == korisnik.KorisnickoIme).ToList());
                    }
                    
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
                    vozac = _VozacRepository.GetVozac(korisnickoIme, lozinka);
                    //if (SviKorisnici.Count != 0)
                    if (korisnik != null)
                    {
                        Session["KorisnikData"] = korisnik.KorisnickoIme;
                        TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                        TempData["Lozinka"] = korisnik.Lozinka;
                        TempData["Uloga"] = korisnik.Uloga;
                        TempData["Ime"] = korisnik.Ime;
                        TempData["Prezime"] = korisnik.Prezime;
                        TempData["Pol"] = korisnik.Pol;
                        TempData["JMBG"] = korisnik.JMBG;
                        TempData["KontaktTelefon"] = korisnik.KontaktTelefon;
                        if (vozac != null)
                            TempData["Lokacija"] = vozac.Lokacija;
                        TempData["Email"] = korisnik.Email;

                        if (korisnik.Uloga.ToString() == "VOZAC")
                        {
                            return View(_VoznjeRepository.UzmiVoznje().Where(s => s.Vozac == korisnik.KorisnickoIme).ToList());
                        }
                        else if (korisnik.Uloga.ToString() == "MUSTERIJA")
                        {
                            return View(_VoznjeRepository.UzmiVoznje().Where(s => s.Musterija == korisnik.KorisnickoIme).ToList());
                        }
                        else
                        {
                            return View(_VoznjeRepository.UzmiVoznje().Where(s => s.Dispecer == korisnik.KorisnickoIme).ToList());
                        }
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


        #region Registracija Vozaca

        [HttpGet]
        public ActionResult RegistracijaVozaca()
        {
            korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
            TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
            TempData["Lozinka"] = korisnik.Lozinka;
            TempData["Uloga"] = korisnik.Uloga;
            
            return View();
        }

        [HttpPost]
        public ActionResult RegistracijaVozaca(Vozac _vozac)
        {
            //try
            {

                _VozacRepository.InsertVozac(_vozac);

                
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
        public ActionResult RegistracijaIzmena(string korisnickoIme)
        {
            try
            {
                korisnik = _KorisnikRepository.GetKorisnik(korisnickoIme);
                TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                TempData["Lozinka"] = korisnik.Lozinka;
                TempData["Uloga"] = korisnik.Uloga;
                return View(korisnik);
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


        #region Registracija izmena Dispecera

        [HttpGet]
        public ActionResult RegistracijaIzmenaDispecer(string korisnickoIme)
        {
            try
            {
                korisnik = _KorisnikRepository.GetKorisnik(korisnickoIme);
                TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                TempData["Lozinka"] = korisnik.Lozinka;
                TempData["Uloga"] = korisnik.Uloga;
                return View(korisnik);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult RegistracijaIzmenaDispecer(Korisnik korisnik)
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


        #region Registracija izmena Vozaca

        [HttpGet]
        public ActionResult RegistracijaIzmenaVozac(string korisnickoIme)
        {
            try
            {
                vozac = _VozacRepository.GetVozac(korisnickoIme);
                TempData["KorisnickoIme"] = vozac.KorisnickoIme;
                TempData["Lozinka"] = vozac.Lozinka;
                TempData["Uloga"] = vozac.Uloga;
                return View(vozac);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult RegistracijaIzmenaVozac(Vozac vozac)
        {
            try
            {
                _VozacRepository.EditVozac(vozac);
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


        #region Lista Vozaca

        [HttpGet]
        public ActionResult ListaVozaca(string korisnickoIme)
        {


            try
            {
                korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
                TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                TempData["Lozinka"] = korisnik.Lozinka;
                TempData["Uloga"] = korisnik.Uloga;
                return View(_VozacRepository.UzmiVozace().ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult ListaVozaca(Korisnik korisnik)
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


        #region Lista Svih Voznji

        [HttpGet]
        public ActionResult ListaSvihVoznji(string korisnickoIme)
        {


            try
            {
                korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
                TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                TempData["Lozinka"] = korisnik.Lozinka;
                TempData["Uloga"] = korisnik.Uloga;
                return View(_VoznjeRepository.UzmiVoznje().ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult ListaSvihVoznji(Voznja voznja, string sortDatum, string pretragaOdOcene, string pretragaDoOcene, string iznosOd, string iznosDo, string imeKorisnika, string prezimeKorisnika)
        {


            try
            {
                List<Voznja> sortiranaListaPoDatumu;




                //sortiranaListaPoDatumu = newlist.OrderByDescending(x => DateTime.Parse(x)).ToList();


                //.OrderBy(x => x.newsdate ?? x.createDate)


                if (voznja.StatusVoznje.ToString() == "SVE")
                {
                    sortiranaListaPoDatumu = _VoznjeRepository.UzmiVoznje().ToList();
                }

                else 
                {
                    sortiranaListaPoDatumu = _VoznjeRepository.UzmiVoznje().Where(s => s.StatusVoznje == voznja.StatusVoznje).ToList();
                }

                if (sortDatum == "sort0")
                {

                }
                else if (sortDatum == "sort1")
                {
                  sortiranaListaPoDatumu = sortiranaListaPoDatumu.OrderBy(m => m.DatumIVremePorudzbine).ToList();
                }

                else if (sortDatum == "sort2")
                {
                  sortiranaListaPoDatumu = sortiranaListaPoDatumu.OrderByDescending(m => m.DatumIVremePorudzbine).ToList();

                }
                else if (sortDatum == "sort3")
                {
                    sortiranaListaPoDatumu = sortiranaListaPoDatumu.OrderByDescending(m => m.Komentar.Ocena).ToList();
                }

                if (iznosOd == "")
                {
                    iznosOd = "0";
                }
                if (iznosDo == "")
                {
                    iznosDo = "999999999";
                }
                sortiranaListaPoDatumu = sortiranaListaPoDatumu.Where(s => Int32.Parse(s.Iznos) >= Int32.Parse(iznosOd)).ToList();
                sortiranaListaPoDatumu = sortiranaListaPoDatumu.Where(s => Int32.Parse(s.Iznos) <= Int32.Parse(iznosDo)).ToList();

                if (pretragaOdOcene == "")
                {
                    pretragaOdOcene = "0";
                }
                if (pretragaDoOcene == "")
                {
                    pretragaDoOcene = "5";
                }
                sortiranaListaPoDatumu = sortiranaListaPoDatumu.Where(s => (int)s.Komentar.Ocena >= Int32.Parse(pretragaOdOcene)).ToList();
                sortiranaListaPoDatumu = sortiranaListaPoDatumu.Where(s => (int)s.Komentar.Ocena <= Int32.Parse(pretragaDoOcene)).ToList();


                Korisnik korisnik1 = _KorisnikRepository.GetKorisnik(imeKorisnika, prezimeKorisnika, 1);

                if (korisnik1 != null)
                    sortiranaListaPoDatumu = sortiranaListaPoDatumu.Where(s => s.Musterija == korisnik1.KorisnickoIme).ToList();
                else if (imeKorisnika == "" && prezimeKorisnika == "")
                    return View(sortiranaListaPoDatumu);
                else
                    sortiranaListaPoDatumu = new List<Voznja>();

                return View(sortiranaListaPoDatumu);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        #endregion


        #region Dodaj Automobil

        [HttpGet]
        public ActionResult DodajVozilo(string korisnickoIme)
        {


            try
            {
                korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
                TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                TempData["Lozinka"] = korisnik.Lozinka;
                TempData["Uloga"] = korisnik.Uloga;
                TempData["VozacIme"] = korisnickoIme;
                return View(_AutomobilRepository.UzmiAutomobile().Where(s => s.Vozac == "").ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult DodajVozilo(Automobil automobil)
        {
            try
            {
                _AutomobilRepository.ZaduziAutomobil(automobil);
                _VozacRepository.ZaduziVozaca(automobil);
                //TempData["Sucss"] = "You are record update successfully..";
                //TempData["mySesstion0"] = korisnik.Email; TempData["mySesstion1"] = korisnik.Lozinka;

                return RedirectToAction("../Home/ListaVozaca");
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        #endregion


        #region Dodaj Voznju

        [HttpGet]
        public ActionResult DodajVoznju(string korisnickoIme)
        {


            try
            {
                korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
                TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                TempData["Lozinka"] = korisnik.Lozinka;
                TempData["Uloga"] = korisnik.Uloga;
                TempData["VozacIme"] = korisnickoIme;
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult DodajVoznju(Voznja voznje)
        {
            try
            {
                _VoznjeRepository.InsertVoznja(voznje);
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


        #region Promeni Lokaciju Vozaca

        [HttpGet]
        public ActionResult PromenaLokacijeVozaca(string korisnickoIme)
        {


            try
            {
                vozac = _VozacRepository.GetVozac(Session["KorisnikData"].ToString());
                TempData["KorisnickoIme"] = vozac.KorisnickoIme;
                TempData["Lozinka"] = vozac.Lozinka;
                TempData["Uloga"] = vozac.Uloga;
                TempData["VozacIme"] = korisnickoIme;
                return View(vozac);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult PromenaLokacijeVozaca(Vozac vozac, string xKoordinata, string yKoordinata, string ulica, string broj, string naseljenoMesto, string pozivniBroj)
        {
            try
            {

                vozac = _VozacRepository.GetVozac(Session["KorisnikData"].ToString());
                string lokacija = "X: " + xKoordinata + ", Y: " + yKoordinata + ", Ulica: " + ulica + " " + broj + ", Mesto: " + naseljenoMesto + ", Pozivni broj: " + pozivniBroj;
                vozac.Lokacija = lokacija;
                _VozacRepository.EditVozac(vozac);
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


        #region Promeni Stanje Voznje

        [HttpGet]
        public ActionResult PromeniStanjeVoznje(string korisnickoIme)
        {


            try
            {

                vozac = _VozacRepository.GetVozac(Session["KorisnikData"].ToString());
                TempData["KorisnickoIme"] = vozac.KorisnickoIme;
                TempData["Lozinka"] = vozac.Lozinka;
                TempData["Uloga"] = vozac.Uloga;
                TempData["VozacIme"] = korisnickoIme;
                return View(_VoznjeRepository.UzmiVoznje().ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult PromeniStanjeVoznje(Voznja voznja, DateTime datum, string opis)
        {
            try
            {

                _VoznjeRepository.EditVoznja(voznja, datum, opis);
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


        #region Promeni Stanje Voznje

        [HttpGet]
        public ActionResult OtkaziVoznju(string korisnickoIme)
        {


            try
            {

                korisnik = _KorisnikRepository.GetKorisnik(Session["KorisnikData"].ToString());
                TempData["KorisnickoIme"] = korisnik.KorisnickoIme;
                TempData["Lozinka"] = korisnik.Lozinka;
                TempData["Uloga"] = korisnik.Uloga;
                TempData["VozacIme"] = korisnickoIme;
                return View(_VoznjeRepository.UzmiVoznje().ToList());
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public ActionResult OtkaziVoznju(Voznja voznja, DateTime datum, string opis, string Ocena)
        {
            try
            {

                _VoznjeRepository.EditVoznja(voznja, datum, opis, Ocena);
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