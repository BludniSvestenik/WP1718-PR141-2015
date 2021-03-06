﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Taksi.Models
{
    public class Automobil
    {

        public Automobil()
        {
            this.Vozac = null;
            this.Godiste = null;
            this.BrojRegistarskeOznake = null;
            this.BrojTaksiVozila = null;
            this.Tip = TipAutomobila.PUTNICKI;

        }

        public Automobil(string vozac, string godiste, string BRO, string BTV, string tip)
        {
            this.Vozac = vozac;
            this.Godiste = godiste;
            this.BrojRegistarskeOznake = BRO;
            this.BrojTaksiVozila = BTV;
            this.Tip = (TipAutomobila)Enum.Parse(typeof(TipAutomobila), tip); 
        }


        [Required(ErrorMessage = "Vozac je neophodan")]
        public string Vozac { get; set; }


        [Required(ErrorMessage = "Godiste je neophodno")]
        public string Godiste { get; set; }


        [Required(ErrorMessage = "Registarska oznaka je neophodna")]
        public string BrojRegistarskeOznake { get; set; }


        [Required(ErrorMessage = "Broj taksi vozila je neophodno")]
        public string BrojTaksiVozila { get; set; }


        [Required(ErrorMessage = "Tip automobila je neophodan")]
        public TipAutomobila Tip { get; set; }

    }
}