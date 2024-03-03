using BusinessLayerr.Concrete;
using BusinessLayerr.ValidationRules;
using DataAccesssLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() 
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet] //sayfa yüklendiğinde
        public ActionResult AddCategory()
        {
            return View(); //sayfa gelsin
        }
        [HttpPost] //bir şeye tıklandıgında
        public ActionResult AddCategory(Category p) 
        {
            //cm.CategoryAddBL(p);
            CategoryValidator categoryValidator=new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid) //hata yoksa cmye ekler
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList"); 
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View(); //buradaki işlemler yapılsın
        }
    }
}