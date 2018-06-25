using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Taksi.Models
{
    public class Lokacija
    {

        public Lokacija()
        {
            this.X = 0;
            this.Y = 0;
            this.Adresa = null;
        }

        public Lokacija(int x, int y, Adresa adresa)
        {
            this.X = x;
            this.Y = y;
            this.Adresa = adresa;
        }




        [Required(ErrorMessage = "X Koordinata je neophodna")]
        public int X { get; set; }


        [Required(ErrorMessage = "Y Koordinata je neophodna")]
        public int Y { get; set; }


        [Required(ErrorMessage = "Adresa je neophodna")]
        public Adresa Adresa { get; set; }
    }
}