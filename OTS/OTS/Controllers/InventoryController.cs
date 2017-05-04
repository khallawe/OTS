using OTS.Authentication;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTS.code;




namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class InventoryController : Controller
    {
        

        

        // GET: Inventory
        public ActionResult Index()
        {
            try
            {
                List<Inventory> inventories = BLL.Inventory.Instance.SelectAll();

                return View(inventories);
            }
            catch(Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return View();
            }
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {           
            return View();
        }

        // GET: Inventory/Create

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CreatedDate,CreatedBy")] Inventory inventory)
        {

            try
            {
                if (BLL.Inventory.Instance.getDbSet().Any(x => x.name.ToLower() == inventory.name.ToLower()))
                {
                    ModelState.AddModelError("name", "This User is already in use OR In disactivate Mode ");
                }

                if (ModelState.IsValid)
                {
                    inventory.CreatedDate = DateTime.Now;
                    inventory.CreatedBy = ((Model.User)Session["User"]).ID;
                    int res= BLL.Inventory.Instance.Add(inventory);
                    return  RedirectToAction("Index");
                }
                return View();
            }

            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return View();
            }

        }

        // GET: Inventory/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Inventory inventory = BLL.Inventory.Instance.SelectOne(id);

                return View(inventory);
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);

                return View();
            }

        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "CreatedDate,CreatedBy,ModifiedBy,ModifiedDate")]Inventory inventory)
        {
            try
            {
                if (BLL.Inventory.Instance.getDbSet().Any(x => x.name.ToLower() == inventory.name.ToLower() && x.InventoryID !=inventory.InventoryID))
                {
                    ModelState.AddModelError("name", "This User is already in use");
                }

                inventory.ModifiedBy = ((Model.User)Session["User"]).ID;
                inventory.ModifiedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    BLL.Inventory.Instance.Update(inventory);
                    return RedirectToAction("Index");
                }

                return View();
            }

            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);

                return View();
            }
        }
        
       

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Inventory inventory = BLL.Inventory.Instance.SelectOne(id);
            if (inventory != null)
            {
                return View(inventory);
            }
            else
            {
                return RedirectToAction("Index");
             
            }
        }


        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(Inventory inventory)
        {
            try
            {
                int x=BLL.Inventory.Instance.Delete(inventory.InventoryID);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);

                return View(inventory);
            }
        }
    }
}
