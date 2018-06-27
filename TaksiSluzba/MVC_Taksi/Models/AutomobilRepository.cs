using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace MVC_Taksi.Models
{
    public class AutomobilRepository
    {

        private List<Automobil> sviAutomobili;
        private XDocument AutomobilData;

        public AutomobilRepository()
        {
            try
            {
                sviAutomobili = new List<Automobil>();
                AutomobilData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Automobil.xml"));
                var Automobili = from t in AutomobilData.Descendants("item")
                               select new Automobil(
                               t.Element("Vozac").Value,
                               t.Element("Godiste").Value,
                               t.Element("BrojRegistarskeOznake").Value,
                               t.Element("BrojTaksiVozila").Value,
                               t.Element("Tip").Value);

                sviAutomobili.AddRange(Automobili.ToList<Automobil>());
            }
            catch (Exception)
            {

             //   throw new NotImplementedException();
            }
        }

        public IEnumerable<Automobil> UzmiAutomobile()
        {
            return sviAutomobili;
        }

        public Automobil GetAutomobil(string brojRegistarskeOznake)
        {
            return sviAutomobili.Find(item => item.BrojRegistarskeOznake == brojRegistarskeOznake);
        }



        public void ZaduziAutomobil(Automobil automobil)
        {
            try
            {
                XElement node = AutomobilData.Root.Elements("item").Where(i => (string)i.Element("BrojTaksiVozila") == automobil.BrojTaksiVozila).FirstOrDefault();

                node.SetElementValue("Vozac", automobil.Vozac);

                AutomobilData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Automobil.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }
    }
}