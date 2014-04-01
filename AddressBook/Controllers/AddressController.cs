using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class AddressController : Controller
    {
        static readonly IAddressRepository Addresses = new AddressRepository();
 
        #region Use DI (Ninject?)
        //public AddressController(IAddressRepository repository)
        //{
        //    if (repository == null)
        //    {
        //        throw new ArgumentException("repository");
        //    }
        //    _addresses = repository;
        //}
        #endregion

        public ActionResult Index()
        {
            ViewBag.TimeNow = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult List()
        {
            var data = Addresses.GetAll();
            return View(data);
        }
        // Get all addresses
        public IEnumerable<Address> Get()
        {
            return Addresses.GetAll();
        }
 
        // Get address by id
        public Address Get(int id)
        {
            try
            {
                var address = Addresses.Get(id);
                return address;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Id not found"
                };
                throw new HttpResponseException(response); // Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));
            }
        }
 
        // Insert Address
        public void /*HttpResponseMessage*/ Post(Address value)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Model state is invalid");
 
                Address address = Addresses.Add(value);
                //var response = Request.CreateResponse(HttpStatusCode.Created, address);
                 //return response;
            }
            catch (Exception ex)
            {
                throw;
                //return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
 
        // Update Address by id
        public /*HttpResponseMessage*/ void Put(int id, Address value)
        {
            try
            {
                if (!Addresses.Update(id, value))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                throw;
                //return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
           // return Request.CreateResponse(HttpStatusCode.OK);
        }
 
        // Delete Address by id
        public /*HttpResponseMessage*/ void Delete(int id)
        {
            try
            {
                Addresses.Remove(id);
            }
            catch (Exception ex)
            {
                throw;
                //return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            //return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
