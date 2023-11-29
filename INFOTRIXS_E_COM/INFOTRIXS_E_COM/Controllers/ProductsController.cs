using INFOTRIXS_E_COM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INFOTRIXS_E_COM.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
            {
            return Request.CreateResponse(HttpStatusCode.OK, db.Products.ToList());
            }
            
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            if(id > 0)
            {
                using (INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, db.Products.FirstOrDefault(el => el.id == id));
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not Avilable!");
            }
        }

        // POST api/<controller>
        /*
         {"title":"Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops","price":109.95,"description":"Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday","category":"men's clothing","image":"https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg","ratingRate":3.9,"ratingCount":120}
         */
        public HttpResponseMessage Post([FromBody] Product value)
        {
            using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(value);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Data is created : " + value);
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Data is not in Correct format!");
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] Product value)
        {
            if(id > 0)
            {
                if (ModelState.IsValid)
                {
                    using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
                    {
                        Product model = db.Products.FirstOrDefault(el => el.id == id);
                        if (model != null)
                        {
                            model.image = value.image != null ? value.image : model.image;
                            model.price = value.price < 0 ? value.price : model.price;
                            model.ratingCount = value.ratingCount != null ? value.ratingCount : model.ratingCount;
                            model.ratingRate = value.ratingRate != null ? value.ratingRate : model.ratingRate;
                            model.description = value.description != null ? value.description : model.description;
                            model.title = value.title != null ? value.title : model.title;
                            model.category = value.category != null ? value.category : model.category;
                            db.SaveChanges();
                            return Request.CreateResponse(HttpStatusCode.Accepted, $"{value.ToString()} value is updated");
                        }
                        else return Request.CreateResponse(HttpStatusCode.NotAcceptable, $"ID : {id} is not valid!");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, " invalid input!");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "");
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
            {
                Product model = db.Products.FirstOrDefault(el => el.id == id);
                if (model != null)
                {
                    db.Products.Remove(model);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, $"Product {id} is deleted!");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "Product not found!");
                }
            }
        }
    }
}