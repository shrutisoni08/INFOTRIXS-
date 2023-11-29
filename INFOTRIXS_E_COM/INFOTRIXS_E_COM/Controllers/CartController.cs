using INFOTRIXS_E_COM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INFOTRIXS_E_COM.Controllers
{
    public class CartController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
          using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.Carts.ToList());
            }
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public HttpResponseMessage Post(int id)
        {
            using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
            {
                Product value = db.Products.FirstOrDefault(el => el.id == id) ;
                if (id > 0) { }

                User modify = db.Users.FirstOrDefault(el => el.Email == User.Identity.Name);
                if(modify == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, " not found or need to login!"); 
                }
               
                Cart model = new Cart();

                model.category = value.category;
                model.description = value.description;
                model.image = value.image;
                model.title = value.title;
                model.ratingCount = value.ratingCount;
                model.ratingRate = value.ratingRate;
                model.price = value.price;
                model.userID =modify.ID;
                //model.userID =1;
                modify.Carts.Add(model);
                db.Entry(modify).State = EntityState.Modified;
                db.SaveChanges();


                db.Carts.Add(model);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, "Added");
            }

        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using(INFOTRIXS_E_COM_DBContext db = new INFOTRIXS_E_COM_DBContext())
            {
                db.Carts.Remove(db.Carts.FirstOrDefault(el => el.id == id));
                db.SaveChanges();
            }
        }
    }
}