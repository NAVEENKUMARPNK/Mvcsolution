using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Controllers
{
    public class ProductController : Controller
       
    {
        IProductRepository con = null;
        public ProductController(IProductRepository source)
        {
            con = source;

        }

        // GET: ProductController
        public ActionResult List()
        {
            var result = con.selectallProduct();
            return View("List", result);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var result = con.selectbyId(id);
            return View("Details", result);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View("Add",new Products());
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products regs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = con.selectbyname(regs.Name);
                    if (result != null)
                    {
                        ModelState.AddModelError("", "user already exsist");
                        return View("Add", regs);
                    }

                    con.insertproduct(regs);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Add", regs);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
         
            var edit = con.selectbyId( id);
            return View("Edit",edit);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products regs)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = con.selectbyname(regs.Name);
                    if (result != null)
                    {
                        ModelState.AddModelError("", "user already exsist");
                        return View("Edit", regs);


                    }

                    con.UpdateProduct(regs);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Edit", regs);

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(string Name)
        {
            var edit = con.selectbyname(Name);
            return View("ConfrimDelete", edit);
           ;
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            try
            {
                con.DeleteProduct(Id);
                return RedirectToAction(nameof(List));
            }
            catch(Exception ex )
            {
                return View();
            }
        }
    }
}
