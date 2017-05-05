using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace OTS.Model
{
    public class SubInventory: Base
    {
        //[Required(ErrorMessage = "This field Required")]

        [Key]
        public int SubInventoryID { get; set; }

        [Required(ErrorMessage = "This field Required")]
        public int InventoryID { get; set; }
        [Required(ErrorMessage = "This field Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "This field Required")]
        public string description { get; set; }

        public virtual Inventory inventory { get; set; }
        public List<Exam> exams { get; set; }
        public List<Question> questions { get; set; }

    }
}
