﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MichalZawadzkiLab66.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [RegularExpression("(^[a-zA-Z][a-zA-Z0-9]*@[a-zA-Z0-9]+\\.[a-zA-Z0-9]+)", ErrorMessage = "Email address can consist of numbers, english letters and '.-_'")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}