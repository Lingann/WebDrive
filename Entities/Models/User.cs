using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "age is required")]
        public int age { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "date is required")]
        public DateTime date { get; set; }
    }
}
