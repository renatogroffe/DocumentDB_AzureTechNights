using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Documents.Client;

namespace ExemploDocumentDBLinux.Controllers
{
    [Route("api/[controller]")]
    public class CatalogoController : Controller
    {
        [HttpGet]
        public List<dynamic> Get(
            [FromServices]IConfiguration config)
        {
            using (var client = new DocumentClient(
                new Uri(config["Testes:EndpointUri"]),
                        config["Testes:PrimaryKey"]))
            {
                FeedOptions queryOptions =
                    new FeedOptions { MaxItemCount = -1 };

                return
                    client.CreateDocumentQuery(
                        UriFactory.CreateDocumentCollectionUri(
                            config["Testes:Database"],
                            config["Testes:ColecaoCatalogo"]),
                            "SELECT c.id, c.Nome FROM Catalogo c", queryOptions)
                        .ToList();
            }
        }
    }
}