using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Taksi.Models
{
    public class Komentar
    {


        public Komentar()
        {
            this.Opis = null;
            this.DatumObjave = DateTime.Now;
            this.Korisnik = null;
            this.Voznja = null;
            this.Ocena = Ocena.NULA;
        }


        public Komentar(string opis, Korisnik korisnik, Voznja voznja, Ocena ocena)
        {
            this.Opis = opis;
            this.DatumObjave = DateTime.Now;
            this.Korisnik = korisnik;
            this.Voznja = voznja;
            this.Ocena = ocena;
        }



        [Required(ErrorMessage = "Opis je neophodan")]
        public string Opis{ get; set; }


        [Required(ErrorMessage = "Datum objave je neophodan")]
        public DateTime DatumObjave { get; set; }


        [Required(ErrorMessage = "Korisnik je neophodan")]
        public Korisnik Korisnik { get; set; }


        [Required(ErrorMessage = "Voznja je neophodna")]
        public Voznja Voznja { get; set; }


        [Required(ErrorMessage = "Ocena je neophodna")]
        public Ocena Ocena { get; set; }


    }
}