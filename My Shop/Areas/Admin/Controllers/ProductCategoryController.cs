using Common;
using Models;
using My_Shop.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Shop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var temp = db.productCategories.AsQueryable();
            var model = new ProductCategoryViewModel()
            {
                AllProduct = new SelectList(db.products, "Id", "caption"),
                SelectedSpecial = temp.Where(p => p.ProductType == ProductCategoryType.SpecialProduct).Select(p => p.Product.Id),
                SelectedNewProduct = temp.Where(p => p.ProductType == ProductCategoryType.NewProduct).Select(p => p.Product.Id),
                SelectedBstSeller = temp.Where(p => p.ProductType == ProductCategoryType.BestSellerProduct).Select(p => p.Product.Id),
                SelectedProposed = temp.Where(p => p.ProductType == ProductCategoryType.ProposedProduct).Select(p => p.Product.Id)
            };

            return View(model);
        }
        public JavaScriptResult UpdateSelectedSpecial(int[] SelectedSpecial)
        {
            var temp = db.productCategories.Where(p => p.ProductType == ProductCategoryType.SpecialProduct);
            var item_del = temp.Where(p => !SelectedSpecial.Any(j => j == p.productId));
            var item_add = SelectedSpecial.Where(p => !temp.Any(j => j.productId == p));
            foreach (var item in item_del)
            {
                db.productCategories.Remove(db.productCategories.Find(item.Id));
            }
            foreach (var item in item_add)
            {
                db.productCategories.Add(new ProductCategory()
                {
                    productId = item,
                    ProductType = ProductCategoryType.SpecialProduct
                });
            }
            db.SaveChanges();
            return JavaScript("alert('ok')");
        }
        public JavaScriptResult UpdateSelectedNewProduct(int[] SelectedNewProduct)
        {
            var temp = db.productCategories.Where(p => p.ProductType == ProductCategoryType.NewProduct);
            var item_del = temp.Where(p => !SelectedNewProduct.Any(j => j == p.productId));
            var item_add = SelectedNewProduct.Where(p => !temp.Any(j => j.productId == p));
            foreach (var item in item_del)
            {
                db.productCategories.Remove(db.productCategories.Find(item.Id));
            }
            foreach (var item in item_add)
            {
                db.productCategories.Add(new ProductCategory()
                {
                    productId = item,
                    ProductType = ProductCategoryType.NewProduct
                });
            }
            db.SaveChanges();
            return JavaScript("alert('ok')");
        }
        public JavaScriptResult UpdateSelectedProposed(int[] SelectedProposed)
        {
            var temp = db.productCategories.Where(p => p.ProductType == ProductCategoryType.ProposedProduct);
            var item_del = temp.Where(p => !SelectedProposed.Any(j => j == p.productId));
            var item_add = SelectedProposed.Where(p => !temp.Any(j => j.productId == p));
            foreach (var item in item_del)
            {
                db.productCategories.Remove(db.productCategories.Find(item.Id));
            }
            foreach (var item in item_add)
            {
                db.productCategories.Add(new ProductCategory()
                {
                    productId = item,
                    ProductType = ProductCategoryType.ProposedProduct
                });
            }
            db.SaveChanges();
            return JavaScript("alert('ok')");
        }
        public JavaScriptResult UpdateSelectedBstSeller(int[] SelectedBstSeller)
        {
            var temp = db.productCategories.Where(p => p.ProductType == ProductCategoryType.BestSellerProduct);
            var item_del = temp.Where(p => !SelectedBstSeller.Any(j => j == p.productId));
            var item_add = SelectedBstSeller.Where(p => !temp.Any(j => j.productId == p));
            foreach (var item in item_del)
            {
                db.productCategories.Remove(db.productCategories.Find(item.Id));
            }
            foreach (var item in item_add)
            {
                db.productCategories.Add(new ProductCategory()
                {
                    productId = item,
                    ProductType = ProductCategoryType.BestSellerProduct
                });
            }
            db.SaveChanges();
            return JavaScript("alert('ok')");
        }
    }
}