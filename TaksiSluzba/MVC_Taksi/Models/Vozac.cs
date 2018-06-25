using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MVC_Taksi.Models
{
    public class Vozac : Korisnik
    {

        public Vozac()
        {
            this.Automobil = null;
            this.Lokacija = null;
        }

        public Vozac(Automobil automobil, Lokacija lokacija)
        {
            this.Automobil = automobil;
            this.Lokacija = lokacija;
        }

        [Required(ErrorMessage = "Automobil je neophodan")]
        public Automobil Automobil { get; set; }


        [Required(ErrorMessage = "Lokacija je neophodna")]
        public Lokacija Lokacija { get; set; }
    }
}