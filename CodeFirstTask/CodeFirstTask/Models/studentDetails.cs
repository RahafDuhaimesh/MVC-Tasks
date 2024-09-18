using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstTask.Models
{
    public class studentDetails
    {
        [Key]
        public int ID { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int NumOfSiblings { get; set; }

        public virtual Student Students { get; set; }
    }
}