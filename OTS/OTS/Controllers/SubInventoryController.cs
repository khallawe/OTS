using OTS.Authentication;
using OTS.DAL;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class SubInventoryController : Controller
    {
        ErrorLog errorLog = new ErrorLog();


        // GET: SubInventory
        public ActionResult Index()
        {
            try
            {

                List<SubInventory> subInventories = BLL.SubInventory.Instance.SelectAll();
                return View(subInventories);
            }
            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

               return  RedirectToAction("Create","Inventory");
            }
        }

        // GET: SubInventory/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                //OTSContext db = new OTSContext();

                SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(id);
                ViewBag.GetInventoryName = BLL.Inventory.Instance.getDbSet().SingleOrDefault(x => x.InventoryID == subInventory.InventoryID).name;
                return View(subInventory);
            }

            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                return View() ;

            }
        }

        // GET: SubInventory/Create

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
               // OTSContext db = new OTSContext();
                TempData["InventoryID"] = new SelectList(BLL.Inventory.Instance.getDbSet(), "InventoryID", "name");
                return View();
            }
            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                return View();

            }
        }


        // POST: SubInventory/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CreatedDate,CreatedBy")] SubInventory subInventory)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (BLL.SubInventory.Instance.getDbSet().Any(x => x.name.ToLower() == subInventory.name.ToLower()))
                    {
                        ModelState.AddModelError("name", "This User is already in use");
                    }

                    subInventory.CreatedDate = DateTime.Now;
                    subInventory.CreatedBy = ((Model.User)Session["User"]).ID;
                    BLL.SubInventory.Instance.Add(subInventory);

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    errorLog.UserID = ((Model.User)Session["User"]).ID;
                    errorLog.CreatedDate = DateTime.Now;
                    errorLog.errorMsg = ex.Message;
                    return View();

                }           

            }
            return View();

        }

        // GET: SubInventory/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(id);
                TempData["InventoryIDEdit"] = new SelectList(BLL.Inventory.Instance.getDbSet(), "InventoryID", "name", subInventory.InventoryID);

                return View(subInventory);
            }
            catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                return View();

            }

        }

        // POST: SubInventory/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "CreatedDate,CreatedBy,ModifiedBy,ModifiedDate")]SubInventory subInventory)
        {
            try
            {
                if (BLL.SubInventory.Instance.getDbSet().Any(x => x.name.ToLower() == subInventory.name.ToLower() && x.InventoryID != subInventory.InventoryID))
                {
                    ModelState.AddModelError("name", "This User is already in use");
                }

                subInventory.ModifiedBy = ((Model.User)Session["User"]).ID;
                subInventory.ModifiedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    BLL.SubInventory.Instance.Update(subInventory);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch(Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                return View();

            }
        }


        
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            try
            {
                SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(id);
                return View(subInventory);
            }
            catch(Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                return View();

            }
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            try
            {
                BLL.SubInventory.Instance.Delete(id);

                return RedirectToAction("Index");
            }
           catch (Exception ex)
            {
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
                return View();

            }
        }
    }
}




