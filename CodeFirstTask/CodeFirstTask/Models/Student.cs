using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstTask.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Student Name Required.")]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required]
        public int Age { get; set; }

        [ForeignKey("StudentDetails")]
        public int StudentDetailsID { get; set; }

        public virtual studentDetails StudentDetails { get; set; }
    }
}