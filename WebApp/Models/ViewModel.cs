using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}