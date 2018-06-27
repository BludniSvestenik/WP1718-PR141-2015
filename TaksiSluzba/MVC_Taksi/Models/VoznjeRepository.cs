using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace MVC_Taksi.Models
{
    public class VoznjeRepository
    {

        private List<Voznja> sveVoznje = new List<Voznja>();
        private XDocument VoznjaData;

  
       

        public VoznjeRepository()
        {
            try
            {



                if (File.Exists(HttpContext.Current.Server.MapPath("~/App_Data/Voznje.xml")))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Voznja>));
                    using (TextReader textReader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/Voznje.xml")))
                    {

                        object obj = deserializer.Deserialize(textReader);
                        sveVoznje = (List<Voznja>)obj;


                    }
                }





                //sveVoznje = new List<Voznja>();
               // VoznjaData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Voznje.xml"));
               // var Voznje = from t in VoznjaData.Descendants("item")
              //                   select new Voznja(
              //                   t.Element("Lokacija").Value,
              //                   t.Element("Tip").Value,
               //                  t.Element("Musterija").Value,
               //                  t.Element("Odrediste").Value,
              //                   t.Element("Dispecer").Value,
             //                    t.Element("Vozac").Value,
             //                    t.Element("Iznos").Value,
             //                    t.Element("Komentar").Value,
              //                   t.Element("StatusVoznje").Value);

             //   sveVoznje.AddRange(Automobili.ToList<Automobil>());
            }
            catch (Exception)
            {

                //   throw new NotImplementedException();
            }
        }

        public IEnumerable<Voznja> UzmiVoznje()
        {
            return sveVoznje;
        }

        public Voznja GetVoznjaDispecer(string dispecer)
        {
            return sveVoznje.Find(item => item.Dispecer == dispecer);
        }

        public Voznja GetVoznjaVozac(string vozac)
        {
            return sveVoznje.Find(item => item.Vozac == vozac);
        }

        public Voznja GetVoznjaMusterija(string musterija)
        {
            return sveVoznje.Find(item => item.Musterija == musterija);
        }

        public void InsertVoznja(Voznja voznja)
        {


            sveVoznje.Add(voznja);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Voznja>));
            using (TextWriter textWriter = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/Voznje.xml")))
            {
                serializer.Serialize(textWriter, sveVoznje);
            }
 
            // 2. create an XML node from object
           // XmlElement node = SerializeToXmlElement(voznja);
            // 3. append that node to Shortcuts node under XML root
            //var shortcutsNode = xDoc.CreateElement("item");
            //shortcutsNode.AppendChild(node);
           // xDoc.DocumentElement.AppendChild(shortcutsNode);
            // 4. save changes
           // xDoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/Voznje.xml"));



            //VoznjaData.Root.Add(new XElement("item",
            //    new XElement("Lokacija", Korisnik.KorisnickoIme),
            //    new XElement("Tip", Korisnik.Lozinka),
            //    new XElement("Musterija", Korisnik.Ime),
            //    new XElement("Odrediste", Korisnik.Prezime),
            //    new XElement("Dispecer", Korisnik.Pol),
            //    new XElement("Vozac", Korisnik.JMBG),
            //    new XElement("Iznos", Korisnik.KontaktTelefon),
            //    new XElement("Komentar", Korisnik.Email),
            //    new XElement("StatusVoznje", Korisnik.Uloga)
            //    ));


            //VoznjaData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Voznje.xml"));
        }

        public void DodajKomentar(Komentar komentar, Korisnik korisnik)
        {
            try
            {
                XElement node = VoznjaData.Root.Elements("item").Where(i => (string)i.Element("KorisnickoIme") == korisnik.KorisnickoIme).FirstOrDefault();

                node.SetElementValue("Komentar", komentar);

                VoznjaData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Voznje.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }



        public static XmlElement SerializeToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return doc.DocumentElement;
        }



    }
}