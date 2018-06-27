using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace MVC_Taksi.Models
{



    public class KorisnikRepository : IKorisnikRepository
    {

        private List<Korisnik> sviKorisnici;
        private XDocument KorisnikData;

        public KorisnikRepository()
        {
            try
            {
                sviKorisnici = new List<Korisnik>();
                KorisnikData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Korisnik.xml"));
                var Korisnici = from t in KorisnikData.Descendants("item")
                               select new Korisnik(
                               t.Element("KorisnickoIme").Value,
                               t.Element("Lozinka").Value,
                               t.Element("Ime").Value,
                               t.Element("Prezime").Value,
                               t.Element("Pol").Value,
                               t.Element("JMBG").Value,
                               t.Element("KontaktTelefon").Value,
                               t.Element("Email").Value,
                               t.Element("Uloga").Value,
                               t.Element("Voznje").Value);

                sviKorisnici.AddRange(Korisnici.ToList<Korisnik>());
            }
            catch (Exception)
            {

             //   throw new NotImplementedException();
            }
        }

        public IEnumerable<Korisnik> UzmiKorisnike()
        {
            return sviKorisnici;
        }

        public Korisnik GetKorisnik(string korisnickoime)
        {
            return sviKorisnici.Find(item => item.KorisnickoIme == korisnickoime);
        }

        public Korisnik GetKorisnik(string korisnickoime, string lozinka)
        {
            return sviKorisnici.Find(item => item.KorisnickoIme == korisnickoime && item.Lozinka == lozinka);
        }


        public void InsertKorisnik(Korisnik Korisnik)
        {
            
            KorisnikData.Root.Add(new XElement("item",
                new XElement("KorisnickoIme", Korisnik.KorisnickoIme),
                new XElement("Lozinka", Korisnik.Lozinka),
                new XElement("Ime", Korisnik.Ime),
                new XElement("Prezime", Korisnik.Prezime),
                new XElement("Pol", Korisnik.Pol),
                new XElement("JMBG", Korisnik.JMBG),
                new XElement("KontaktTelefon", Korisnik.KontaktTelefon),
                new XElement("Email", Korisnik.Email),
                new XElement("Uloga", Korisnik.Uloga),
                 new XElement("Voznje", Korisnik.Voznje)
                ));


            KorisnikData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Korisnik.xml"));
        }


        public void EditKorisnik(Korisnik korisnik)
        {
            try
            {
                XElement node = KorisnikData.Root.Elements("item").Where(i => (string)i.Element("KorisnickoIme") == korisnik.KorisnickoIme).FirstOrDefault();

                node.SetElementValue("KorisnickoIme", korisnik.KorisnickoIme);
                node.SetElementValue("Lozinka", korisnik.Lozinka);
                node.SetElementValue("Ime", korisnik.Ime);
                node.SetElementValue("Prezime", korisnik.Prezime);
                node.SetElementValue("Pol", korisnik.Pol);
                node.SetElementValue("JMBG", korisnik.JMBG);
                node.SetElementValue("KontaktTelefon", korisnik.KontaktTelefon);
                node.SetElementValue("Email", korisnik.Email);
                node.SetElementValue("Uloga", korisnik.Uloga);
                KorisnikData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Korisnik.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

    }

}