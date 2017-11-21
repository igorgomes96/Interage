using InterageApp.DTO;
using InterageApp.Exceptions;
using InterageApp.Models;
using InterageApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterageApp.Controllers
{
    public class PerfisController : ApiController
    {
        private readonly IService<Perfil, PerfilDto, int> _service;

        public PerfisController(IService<Perfil, PerfilDto, int> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public ICollection<PerfilDto> Get()
        {
            return _service.Read();
        }

        public IHttpActionResult Get(int id)
        {
            try { 
                return Ok(_service.Read(id));
            } catch (NotFoundException e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Post(PerfilDto perfil)
        {
            try
            {
                return Ok(_service.Save(perfil));
            } catch(NotFoundException e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            } catch (NotFoundException e)
            {
                return Content(HttpStatusCode.NotFound, e.Message);
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
