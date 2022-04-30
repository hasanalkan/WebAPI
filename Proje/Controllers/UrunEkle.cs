using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proje.Controllers
{
    public class UrunEkle : ApiController
    {
        [HttpGet]
        [Route("api/products/{ProductID}")]
        public Product ProductByID(int ProductIT)
        {
            Urun kayit = db.Product.Where(s => s.ProductID == ProductID).Select(x => new Product()
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryID = x.CategoryID,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                Description = x.Description,
                ProductImage = x.ProductImage
            });
          return kayit;
        }
        [HttpPost]
        [Route("api/urunekle")]
        public UrunModel UrunEkle(UrunModel model)
        {
            if (db.Products.Count(c => c.ProductName == model.ProductName) > 0)
            {
                sonuc.islem = false; sonuc.mesaj = "Girilen Urun Mevcut";
                return sonuc;
            }
        }

        Products yeni = new Product();{
                yeni.ProductID = model.ProductID,
                yeni.ProductName = model.ProductName,
                yeni.CategoryID = model.CategoryID,
                yeni.QuantityPerUnit = model.QuantityPerUnit,
                yeni.UnitPrice = model.UnitPrice,
                yeni.UnitsInStock = model.UnitsInStock,
                yeni.Description = model.Description,
                yeni.ProductImage = model.ProductImage

        db.Products(yeni);            
        db.SaveChanges();            
        
        sonuc.islem = true;             
        sonuc.mesaj = "Urun Eklendi";            
            
        return sonuc;}

}
