using CRUD.Domain.Entities.Client;
using CRUD.Domain.Entities.Generics;
using CRUD.Domain.Handlers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Domain.Api.Controllers
{
    public class ClientController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericResult CreateClient(
            [FromBody] CreateClient createClient,
            [FromServices] ClientHandler handler
        )
        {
            return (GenericResult)handler.Handle(createClient);
        }
    }
}