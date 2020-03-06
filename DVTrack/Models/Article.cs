using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVTrack.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string ExternalLink { get; set; }
        public DateTime PostedDate { get; set; }
        public string Headline { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string ArticleBody { get; set; }
    }
}