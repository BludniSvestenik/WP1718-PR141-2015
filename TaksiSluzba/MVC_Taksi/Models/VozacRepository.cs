using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace MVC_Taksi.Models
{



    public class VozacRepository
    {

        private List<Vozac> sviVozaci;
        private XDocument VozacData;

        public VozacRepository()
        {
            try
            {
                sviVozaci = new List<Vozac>();
                VozacData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Korisnik.xml"));
                var Vozaci = from t in VozacData.Descendants("item")
                                where (string)t.Element("Uloga") == "VOZAC"

                                select new Vozac(
                                t.Element("KorisnickoIme").Value,
                                t.Element("Lozinka").Value,
                                t.Element("Ime").Value,
                                t.Element("Prezime").Value,
                                t.Element("Pol").Value,
                                t.Element("JMBG").Value,
                                t.Element("KontaktTelefon").Value,
                                t.Element("Email").Value,
                                t.Element("Uloga").Value,
                                t.Element("Voznje").Value,
                                t.Element("Automobil").Value,
                                t.Element("Lokacija").Value);





                sviVozaci.AddRange(Vozaci.ToList<Vozac>());
            }
            catch (Exception)
            {

                //   throw new NotImplementedException();
            }
        }

        public IEnumerable<Vozac> UzmiVozace()
        {
            return sviVozaci;
        }

        public Vozac GetVozac(string korisnickoime)
        {
            return sviVozaci.Find(item => item.KorisnickoIme == korisnickoime);
        }

        public Vozac GetVozac(string korisnickoime, string lozinka)
        {
            return sviVozaci.Find(item => item.KorisnickoIme == korisnickoime && item.Lozinka == lozinka);
        }


        public void InsertVozac(Vozac vozac)
        {

            VozacData.Root.Add(new XElement("item",
                new XElement("KorisnickoIme", vozac.KorisnickoIme),
                new XElement("Lozinka", vozac.Lozinka),
                new XElement("Ime", vozac.Ime),
                new XElement("Prezime", vozac.Prezime),
                new XElement("Pol", vozac.Pol),
                new XElement("JMBG", vozac.JMBG),
                new XElement("KontaktTelefon", vozac.KontaktTelefon),
                new XElement("Email", vozac.Email),
                new XElement("Uloga", vozac.Uloga),
                 new XElement("Voznje", vozac.Voznje),
                 new XElement("Automobil", vozac.Automobil),
                 new XElement("Lokacija", vozac.Lokacija)
                ));


            VozacData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Korisnik.xml"));
        }


        public void EditVozac(Vozac vozac)
        {
            try
            {
                XElement node = VozacData.Root.Elements("item").Where(i => (string)i.Element("KorisnickoIme") == vozac.KorisnickoIme).FirstOrDefault();

                node.SetElementValue("KorisnickoIme", vozac.KorisnickoIme);
                node.SetElementValue("Lozinka", vozac.Lozinka);
                node.SetElementValue("Ime", vozac.Ime);
                node.SetElementValue("Prezime", vozac.Prezime);
                node.SetElementValue("Pol", vozac.Pol);
                node.SetElementValue("JMBG", vozac.JMBG);
                node.SetElementValue("KontaktTelefon", vozac.KontaktTelefon);
                node.SetElementValue("Email", vozac.Email);
                node.SetElementValue("Uloga", vozac.Uloga);
                node.SetElementValue("Automobil", vozac.Automobil);
                node.SetElementValue("Lokacija", vozac.Lokacija);

                VozacData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Vozac.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public void ZaduziVozaca(Automobil automobil)
        {
            try
            {
                XElement node = VozacData.Root.Elements("item").Where(i => (string)i.Element("KorisnickoIme") == automobil.Vozac).FirstOrDefault();

                node.SetElementValue("Automobil", automobil.BrojTaksiVozila);

                VozacData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Korisnik.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

    }

}