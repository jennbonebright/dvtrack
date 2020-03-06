using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTrack.Models
{
    public class BoosterEvent
    {
        [Key]
        public int EventId { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDetails { get; set; }
        public string EventImgSrc { get; set; }
        public string EventType { get; set; }
    }
}