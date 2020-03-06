using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTrack.Models
{
    public class Officer
    {
        [Key]
        public int OfficerId { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
    }
}