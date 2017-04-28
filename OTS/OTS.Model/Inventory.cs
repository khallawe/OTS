using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace OTS.Model
{
    public class Inventory: Base
    {
        [Key]
        public int InventoryID { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "this field Required")]
        public string description { get; set; }
        public virtual List<SubInventory> subInventories { get; set; }

    }
}
        