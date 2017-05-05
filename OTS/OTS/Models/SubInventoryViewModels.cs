using OTS.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OTS.Models
{
    public class SubInventoryViewModels
    {
        public int InventoryID { get; set; }
        public IEnumerable<SelectListItem> Inventories { get; set; }
        public SubInventory subinventory { get; set; }
    }
}