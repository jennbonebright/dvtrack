using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVTrack.Models
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }
        public int Year { get; set; }
        public string Event { get; set; }
        public DateTime? Time { get; set; }
        public decimal? Meters { get; set; }
        public decimal? Inches { get; set; }
        public string Gender { get; set; }
        public int Grade { get; set; }
        public string AthleteName { get; set; }
    }

}