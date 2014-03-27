using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class AddressController : ApiController
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
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));
            }
        }
 
        // Insert Address
        public HttpResponseMessage Post(Address value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Model state is invalid");
 
                Address address = Addresses.Add(value);
                var response = Request.CreateResponse(HttpStatusCode.Created, address);
 
                // TODO: Check if the location is useful?
                string uri = Url.Link("DefaultApi", new {id = value.Id});
                response.Headers.Location = new Uri(uri);
               
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
 
        // Update Address by id
        public HttpResponseMessage Put(int id, Address value)
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
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
 
        // Delete Address by id
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Addresses.Remove(id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
