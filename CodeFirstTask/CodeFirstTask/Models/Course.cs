using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstTask.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        public string ClassName { get; set; }
        public string Description { get; set; }

        [ForeignKey("teacher")]
        public int TeacherID { get; set; }

        public virtual Teacher teacher { get; set; }
    }
}