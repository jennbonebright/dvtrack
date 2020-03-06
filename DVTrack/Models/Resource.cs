using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTrack.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        public string ResourceLink { get; set; }
        public string Title { get; set; }

    }
}