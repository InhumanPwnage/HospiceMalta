using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    

    public class TimeValidation
    {
        public DateTime? StartTime { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Invalid Time.")]
        public string StartTimeValue
        {
            get
            {
                return StartTime.HasValue ? StartTime.Value.ToString("hh:mm tt") : string.Empty;
            }

            set
            {
                StartTime = DateTime.Parse(value);
            }
        }

    }
}