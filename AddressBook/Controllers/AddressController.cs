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
        static readonly IAddressRepository _addresses = new AddressRepository();

        //public AddressController(IAddressRepository repository)
        //{
        //    if (repository == null)
        //    {
        //        throw new ArgumentException("repository");
        //    }
        //    _addresses = repository;
        //}

        // GET api/<controller>
        // Get all addresses
        public IEnumerable<Address> Get()
        {
            return _addresses.GetAll();
        }

        // GET api/<controller>/5
        // Get address by id
        public Address Get(int id)
        {
            try
            {
                var address = _addresses.Get(id);
                return address;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));
            }
        }

        // POST api/<controller>
        // Insert Address
        public HttpResponseMessage Post(Address value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Model state is invalid");

                Address address = _addresses.Add(value);
                var response = Request.CreateResponse(HttpStatusCode.Created, address);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<controller>/5
        // Update Address by id
        public HttpResponseMessage Put(int id, Address value)
        {
            try
            {
                _addresses.Update(id, value);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        // Delete Address by id
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _addresses.Remove(id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}