using Interage.Orion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Interage.Controllers
{
    public class TesteController : ApiController
    {
        [HttpGet]
        [Route("api/EntityCreation")]
        public async Task EntityCreationAsync()
        {
            var client = new HttpClient();
            var endpoint = "http://192.168.1.13:1026/v1/updateContext";

            var response = await client.PostAsJsonAsync(endpoint, 
                new Entity
                {
                    contextElements = new List<ContextElements>()
                    {
                        new ContextElements
                        {
                            type = "SalaDiscussao",
                            isPattern = "false",
                            id = "1",
                            attributes = new List<AttributeObject>
                            {
                                new AttributeObject
                                {
                                    name = "codUsuario",
                                    type = "Integer",
                                    value = "2145"
                                },
                                new AttributeObject
                                {
                                    name = "cpfUsuario",
                                    type = "String",
                                    value = "12312312312"
                                },
                                new AttributeObject
                                {
                                    name = "pergunta",
                                    type = "String",
                                    value = "Pergunta?"
                                },
                                new AttributeObject
                                {
                                    name = "flagRespondida",
                                    type = "Boolean",
                                    value = "true"
                                }
                            }
                        }
                    }, 
                    updateAction =  "APPEND"
                }
            );
            if (response.IsSuccessStatusCode)
            {
                Trace.WriteLine("Sucesso!");
            }
        }

        [HttpGet]
        [Route("api/Query")]
        public async Task QueryEntitynAsync()
        {
            var client = new HttpClient();
            var endpoint = "http://192.168.1.13:1026/v1/queryContext";

            var response = await client.PostAsJsonAsync(endpoint, new
                {
                    entities = new List<object>
                    {
                        new {
                            type = "SalaDiscussao",
                            isPattern = "false",
                            id = "1"
                        }
                    }
                }
            );
            if (response.IsSuccessStatusCode)
            {
                string str = await response.Content.ReadAsStringAsync();
                Trace.WriteLine(str);
            }
        }

        [HttpPost]
        [Route("api/PostChange")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostChange(object dado)
        {
            Trace.WriteLine(dado);
            return Ok();
        }

    }
}