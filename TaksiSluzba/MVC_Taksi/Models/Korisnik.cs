using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MVC_Taksi.Models
{
    public class Korisnik
    {

        public Korisnik()
        {
            this.KorisnickoIme = null;
            this.Lozinka = null;
            this.Ime = null;
            this.Prezime = null;
            //this.Pol = Pol.MUSKO;
            this.JMBG = null;
            this.KontaktTelefon = null;
            this.Email = null;
           // this.Uloga = Uloga.MUSTERIJA;
            this.Voznje = null;

        }
        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string jmbg, string kontaktTelefon, string email, string uloga, string voznja)
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
        }

        [Required(ErrorMessage = "Korisnicko ime je neophodno")]
        public string KorisnickoIme { get; set; }


        [Required(ErrorMessage = "Lozinka je neophodna")]
        public string Lozinka { get; set; }


        [Required(ErrorMessage = "Ime je neophodno")]
        public string Ime { get; set; }


        [Required(ErrorMessage = "Prezime je neophodno")]
        public string Prezime { get; set; }


        [Required(ErrorMessage = "Pol je neophodan")]
        public Pol Pol { get; set; }


        [Required(ErrorMessage = "JMBG je neophodan")]
        public string JMBG { get; set; }


        [Required(ErrorMessage = "Kontakt telefon je neophodan")]
        public string KontaktTelefon { get; set; }


        [Required(ErrorMessage = "Email je neophodan")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Uloga je neophodna")]
        public Uloga Uloga { get; set; }


        [Required(ErrorMessage = "Voznje su neophodne")]
        public string Voznje { get; set; }
        //public List<Voznja> Voznje { get; set; }




    }

}