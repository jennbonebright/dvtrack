using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTrack.Models
{
    public class StateMeet
    {
        [Key]
        public int Year { get; set; }
        [Key]
        public string Gender { get; set; }
        public int Place { get; set; }
    }
}