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
            this.KorisnickoIme = null;
            this.Lozinka = null;
            this.Ime = null;
            this.Prezime = null;
            this.Pol = Pol.MUSKO;
            this.JMBG = null;
            this.KontaktTelefon = null;
            this.Email = null;
            this.Uloga = Uloga.VOZAC;
            this.Voznje = null;
            this.Automobil = null;
            this.Lokacija = null;
        }

        public Vozac(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string jmbg, string kontaktTelefon, string email, string uloga, string voznja, string automobil, string lokacija)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pol = (Pol)Enum.Parse(typeof(Pol), pol);
            this.JMBG = jmbg;
            this.KontaktTelefon = kontaktTelefon;
            this.Email = email;
            this.Uloga = (Uloga)Enum.Parse(typeof(Uloga), uloga);
            this.Voznje = voznja;
            this.Automobil = automobil;
            this.Lokacija = lokacija;
        }

        [Required(ErrorMessage = "Automobil je neophodan")]
        public string Automobil { get; set; }


        [Required(ErrorMessage = "Lokacija je neophodna")]
        public string Lokacija { get; set; }
    }
}