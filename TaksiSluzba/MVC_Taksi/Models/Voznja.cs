using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Taksi.Models
{
    public class Voznja
    {


        public Voznja()
        {
            this.DatumIVremePorudzbine = DateTime.Now;
            this.Lokacija = null;
            this.Tip = TipAutomobila.PUTNICKI;
            this.Musterija = null;
            this.Odrediste = null;
            this.Dispecer = null;
            this.Vozac = null;
            this.Iznos = null;
            this.Komentar = null;
            this.StatusVoznje = Status.OBRADJENA;
        }

        public Voznja(Lokacija lokacija, TipAutomobila tip, string musterija, Lokacija odrediste, string dispecer, string vozac, string iznos, Komentar komentar, Status status)
        {
            this.DatumIVremePorudzbine = DateTime.Now;
            this.Lokacija = lokacija;
            this.Tip = tip;
            this.Musterija = musterija;
            this.Odrediste = odrediste;
            this.Dispecer = dispecer;
            this.Vozac = vozac;
            this.Iznos = iznos;
            this.Komentar = komentar;
            this.StatusVoznje = status;


        }



        [Required(ErrorMessage = "Datum i vreme porudzbine su neophodni")]
        public DateTime DatumIVremePorudzbine { get; set; }


        [Required(ErrorMessage = "Lokacija je neophodna")]
        public Lokacija Lokacija { get; set; }


        [Required(ErrorMessage = "Tip automobila je neophodan")]
        public TipAutomobila Tip { get; set; }


        [Required(ErrorMessage = "Musterija je neophodna")]
        public string Musterija { get; set; }


        [Required(ErrorMessage = "Odrediste je neophodno")]
        public Lokacija Odrediste { get; set; }


        [Required(ErrorMessage = "Dispecer je neophodan")]
        public string Dispecer { get; set; }


        [Required(ErrorMessage = "Vozac je neophodan")]
        public string Vozac { get; set; }


        [Required(ErrorMessage = "Iznos je neophodan")]
        public string Iznos { get; set; }


        [Required(ErrorMessage = "Komentar je neophodan")]
        public Komentar Komentar { get; set; }


        [Required(ErrorMessage = "Status voznje je neophodan")]
        public Status StatusVoznje { get; set; }
    }
}