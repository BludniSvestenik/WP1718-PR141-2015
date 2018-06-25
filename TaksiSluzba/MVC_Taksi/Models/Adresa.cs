using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Taksi.Models
{
    public class Adresa
    {


        public Adresa()
        {
            this.Ulica = null;
            this.Broj = null;
            this.NaseljenoMesto = null;
            this.PozivniBroj = null;
        }


        public Adresa(string ulica, string broj, string naseljenoMesto, string pozivniBroj)
        {
            this.Ulica = ulica;
            this.Broj = broj;
            this.NaseljenoMesto = naseljenoMesto;
            this.PozivniBroj = pozivniBroj;
        }






        [Required(ErrorMessage = "Ulica je neophodna")]
        public string Ulica { get; set; }


        [Required(ErrorMessage = "Broj je neophodan")]
        public string Broj { get; set; }


        [Required(ErrorMessage = "Naseljeno mesto je neophodno")]
        public string NaseljenoMesto { get; set; }


        [Required(ErrorMessage = "Pozivni broj je neophodan")]
        public string PozivniBroj { get; set; }
    }
}