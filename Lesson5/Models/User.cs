using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Lesson5.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Lesson5.Models
{
    public class User
    {
        [Required]
        [Remote("UniqueUserName", "Remote")]
        public string Username { get; set; }

    }
}
