using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVTrack.Models
{
    public class Meet
    {
        [Key]
        public int MeetId { get; set; }
        public int YearId { get; set; }
        public string MeetTitle { get; set; }
        public DateTime? MeetDate { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public int ArticleId { get; set; }
        [AllowHtml]
        public string Notes { get; set; }
        public string ResultLink { get; set; }
        public string PhotoLink { get; set; }
    }


}