using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proje.Controllers
{
    public class KategoriEkle : ApiController
    {
        [HttpGet] 
        [Route("api/categories/{CategoryID}")] 
        public Category CategoryByID(int CategoryID) 
        { Kategori kayit = db.Categories.Where(s => s.CategoryID == CategoryID).Select(x => new Category() 
        { CategoryID = x.CategoryID, 
          CategoryName = x.CategoryName,}).         
          return kayit; }
        [HttpPost]
        [Route("api/kategoriekle")]
        public KategoriModel KategoriEkle(KategoriModel model)
        {
            if (db.Categories.Count(c => c.CategoryName == model.CategoryName) > 0) 
            { sonuc.islem = false; sonuc.mesaj = "Girilen Kategori Mevcut"; 
            return sonuc; }
        }

        Categories yeni = new Category();{
        yeni.CategoryID = model.CategoryID;            
        yeni.CategoryName = model.CategoryName;                       
        
        db.Categories(yeni);            
        db.SaveChanges();            
        
        sonuc.islem = true;             
        sonuc.mesaj = "Kategori Eklendi";            
            
        return sonuc;}

}
