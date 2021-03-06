﻿using OTS.Authentication;
using OTS.Helper.ExportImport;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace OTS.Controllers
{
    [AuthenticateAdminSession]
    public class InventoryController : Controller
    {
        

        ErrorLog errorLog = new ErrorLog();

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
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;
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
                    ModelState.AddModelError("name", "This User is already in use");
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
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

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
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

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
                errorLog.UserID = ((Model.User)Session["User"]).ID;
                errorLog.CreatedDate = DateTime.Now;
                errorLog.errorMsg = ex.Message;

                return View();
            }
        }

        public ActionResult ExportXlsx()
        {
            try
            {
                ExportManager exportManager = new ExportManager();
                var bytes = exportManager.ExportInventoriesToXlsx(BLL.Inventory.Instance.SelectAll());

                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "inventories.xlsx");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ImportFromXlsx()
        {
            try
            {
                ImportManager importManager = new ImportManager();
                var file = Request.Files["importexcelfile"];
                if (file != null && file.ContentLength > 0)
                {
                    importManager.ImportInventoriesFromXlsx(file.InputStream, ((Model.User)Session["User"]).ID);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception exc)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Inventory inventory = BLL.Inventory.Instance.SelectOne(id);
            return View(inventory);
        }
        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(Inventory inventory)
        {
            try
            {
                BLL.Inventory.Instance.Delete(inventory.InventoryID);

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
