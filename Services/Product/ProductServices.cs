using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Web;
namespace Services.Product
{
    public class ProductServices : IProductServices
    {
        //private Models.Repositories.ProductRepository bl_Product=new Models.Repositories.ProductRepository();

        //public bool AddProduct(CreateProductViewModel model, IEnumerable<HttpPostedFileBase> files)
        //{
        //    string filename = "";
        //    string mappath = HttpContext.Current.Server.MapPath("~") + "File\\ProductPicture\\";
        //    var tmp = model.product;
        //    foreach (var item in files)
        //    {
        //        filename = DateTime.Now.ToString() + "_" + tmp.ProductFiles.Count +"." + item.FileName.Substring(item.FileName.Length-3,3);
        //        item.SaveAs(mappath + filename);
        //        tmp.ProductFiles.Add(new Models.ProductFile() { LocationFile = "File\\ProductPicture\\" + filename });
        //    }
        //    return bl_Product.Add(tmp);
        //}
        //public bool DeleteProduct(int Id)
        //{
        //    return true;
        //}
        //public bool UpdateProduct(CreateProductViewModel model, IEnumerable<HttpPostedFileBase> files)
        //{
        //    return true;
        //}

    }
}
