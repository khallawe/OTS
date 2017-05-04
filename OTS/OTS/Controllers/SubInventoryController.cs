using OTS.Authentication;
using OTS.code;
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
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return View();
            }
        }

        // GET: SubInventory/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                SubInventory subInventory = BLL.SubInventory.Instance.SelectOne(id);
                ViewBag.GetInventoryName = BLL.Inventory.Instance.getDbSet().SingleOrDefault(x => x.InventoryID == subInventory.InventoryID).name;
                return View(subInventory);
            }

            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return RedirectToAction("Index");

            }
        }

        // GET: SubInventory/Create

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                

                TempData["InventoryID"] = new SelectList(BLL.Inventory.Instance.getDbSet().Where(x=>x.IsActive==true), "InventoryID", "name");


                return View();
            }
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return View();

            }
        }


        // POST: SubInventory/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "CreatedDate,CreatedBy")] SubInventory subInventory)
        {
            if (BLL.SubInventory.Instance.getDbSet().Any(x => x.name.ToLower() == subInventory.name.ToLower()))
            {
                ModelState.AddModelError("name", "This User is already in use OR In disactivate Mode");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    subInventory.CreatedDate = DateTime.Now;
                    subInventory.CreatedBy = ((Model.User)Session["User"]).ID;

                    BLL.SubInventory.Instance.Add(subInventory);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
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
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
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
                    ModelState.AddModelError("name", "This User is already in use OR In disactivate Mode");
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
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
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
            catch (Exception ex)
            {
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID);
                return RedirectToAction("Index");

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
                GenerateErrorLog.AddLog(ex.Message, ((Model.User)Session["User"]).ID); ;
                return View();

            }
        }
    }
}




