﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pagar.Models
{
    public class Pagari
    {
        public int Id { get; set; }
        public int Kogus { get; set; }
        public Tooted Toode { get; set; }    
        public DateTime Tähtaeg { get; set; }
        public string Lisa { get; set; }
        [Display(Name = "Tulen järgi")]
        public bool TuleJärgi { get; set; }
        public string Aadress { get; set; }
        public int Valmis { get; set; } = 0;
        public int PaneTeele { get; set; } = 0;

        public enum Tooted
        {
            Aleksandri_kook = 1,
            Amaretto_šokolaadiküpsis = 2,
            Apelsinikeeks = 3,
            Banaanirull = 4,
            Ekleer = 5,
            Brita_kook = 6
        }

    }
}
