using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proje.Controllers
{
    public class MusteriEkle : ApiController
    {
            [HttpGet]
            [Route("api/customers/{ProductID}")]
            public Customer ProductByID(int CustomerID)
            {
                Urun kayit = db.Customers.Where(s => s.CustomersID == CustomersID).Select(x => new Customer()
                {
                    CustomerID = x.CustomerID,
                    Firstname = x.Firstname,
                    LastName = x.LastName,
                    Address = x.Address,
                    City = x.City,
                    PostalCode = x.PostalCode,
                    Phone = x.Phone,
                    UserID = x.UserID
                });
                return kayit;
            }
            [HttpPost]
            [Route("api/musteriekle")]
            public MusteriModel MusteriEkle(MusteriModel model)
            {
                if (db.Customers.Count(c => c.Firstname == model.Firstname) > 0)
                {
                    sonuc.islem = false; sonuc.mesaj = "Girilen Musteri Mevcut";
                    return sonuc;
                }
            }

            Customers yeni = new Customer();{
                yeni.CustomerID = model.CustomerID,
                yeni.Firstname = model.Firstname,
                yeni.LastName = model.LastName,
                yeni.Address = model.Address,
                yeni.City = model.City,
                yeni.PostalCode = model.PostalCode,
                yeni.Phone = model.Phone,
                yeni.UserID = model.UserID

        db.Customers(yeni);
            db.SaveChanges();            
        
        sonuc.islem = true;             
        sonuc.mesaj = "Musteri Eklendi";            
            
        return sonuc;}
    }
}
