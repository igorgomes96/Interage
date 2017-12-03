using InterageApp.DTO;
using InterageApp.Filters;
using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterageApp.Controllers
{
    [JwtAuthentication]
    public class AreasInteresseController : ApiController
    {
        private readonly IAreasInteresseService _interesseService;

        public AreasInteresseController(IAreasInteresseService interesseService)
        {
            _interesseService = interesseService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_interesseService.Listar());
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Post(AreaInteresseDto areaInteresse) 
        {
            try
            {
                return Ok(_interesseService.CriarNova(areaInteresse));
            } catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(_interesseService.Excluir(id));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
