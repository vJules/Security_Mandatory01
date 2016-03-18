using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Security_Mandatory01.ViewModels
{
    public class ShiftViewModel
    {
        [Required(ErrorMessage = "Please enter some text")]
        public string text { get; set; }
        [Required(ErrorMessage = "Please enter a key")]
        public int numberKey { get; set; }
        public string encodedText { get; set; }
    }
}