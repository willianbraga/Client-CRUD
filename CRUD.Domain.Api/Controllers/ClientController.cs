using CRUD.Domain.Entities.Client;
using CRUD.Domain.Entities.Generics;
using CRUD.Domain.Handlers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Domain.Api.Controllers
{
    /// <summary>Client Controller</summary>
    [ApiVersion("1.0")]
    [Route("[controller]/v{version:apiVersion}")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <summary>Criar novo Registro de Cliente</summary>
        /// <param name="createClient">Objeto de requisição Cliente</param>
        /// <param name="handler">Injeção de dependencia</param>
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