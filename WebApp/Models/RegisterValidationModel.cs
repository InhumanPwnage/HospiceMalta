using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HospicePortableApplication.Models
{
    public class RegisterValidationModel
    {
 
            [Required]
            [Display(Name = "FileNumber")]
            public int FileNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Date Of Birth")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", HtmlEncode = false)]
            public string DOB { get; set; }

            [Required]
            [Display(Name = "Date Of First Contact")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", HtmlEncode = false)]
            public string DateOfFirstContact { get; set; }
        //https://msdn.microsoft.com/en-us/library/dd410405(v=vs.100).aspx
        //http://stackoverflow.com/questions/8506960/how-can-i-check-modelstate-isvalid-from-inside-my-razor-view
        }
}
