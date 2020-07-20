using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using Data.Repositories;
using Data.Infrastructure;
using Domain.Entities;
using Service;
using System.IO;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {

        private ServiceProduct servprd;

        public ProductsController()
        {
            this.servprd = new ServiceProduct();
        }

        public ActionResult Index2()
        {
            var list = servprd.GetAll().ToList();
            return View(list);
        }
        //
        // GET: /Products/
        public ActionResult Index(string filtre)
        {
            var list = servprd.GetAll().ToList();

            // recherche
            //if (!String.IsNullOrEmpty(filtre))
            //{
            //    list = list.Where(m => m.Name.ToString().ToLower().Contains(filtre)).ToList();
            //}
            if (!String.IsNullOrEmpty(filtre))
            {
                list = servprd.GetProductByName(filtre).ToList();
            }
            return View(list);
            //return View();
        }

        //
        // GET: /Products/Details/5
        public ActionResult Details(int id)
        {
            var objproduct = servprd.GetById(id);

            //var Product = new Product();
            //Category.Name
            //    Name
            //    Description
            //        Price
            //        Quantity
            //            DateProd
            //            ImageName

            //Product.ProductId = id;

            //Employee.Name = objemp.;

            //Employee.Salary = objemp.Salary;

            //Employee.Age = objemp.Age;

            //Employee.Address = objemp.Address;

            //Employee.worktype = objemp.worktype;


            return View(objproduct);
        }

        //
        // GET: /Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(servprd.unitofwork.DataContext.Categories, "CategoryId", "Name");
            return View(new Product());
        }

        //
        // POST: /Products/Create
        [HttpPost]
        public ActionResult Create(/*FormCollection collection,*/ Product prdct, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                prdct.ImageName = file.FileName;

                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }
                servprd.Create(prdct);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = servprd.GetById(id);
            ViewBag.CategoryId = new SelectList(servprd.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);  
        }

        //
        // POST: /Products/Edit/5
       
        [HttpPost]
        public ActionResult Edit(Product prdct, HttpPostedFileBase file)
        {
            try
            {
                prdct.ImageName = file.FileName;
                servprd.Update(prdct);
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        //
        // GET: /Products/Delete/5
        public ActionResult Delete(int id)
        {
            var objprdct = servprd.GetById(id); // calling GetEmployeeByID method of EmployeeRepository

            return View(objprdct);
        }

        //
        // POST: /Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var prdct = servprd.GetById(id);
                servprd.Delete(prdct);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

            }
            return View("Index");
        }
    }
}   
    

