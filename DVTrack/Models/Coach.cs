using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVTrack.Models
{
    public class Coach
    {
        [Key]
        public int StaffId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string PhotoSrc { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Biography:")]
        [AllowHtml]
        public string Biography { get; set; }

        public string Group { get; set; }
        public string Event { get; set; }

        public bool Active { get; set; }
        public bool Head { get; set; }
    }



}