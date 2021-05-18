using System;
using System.Collections.Generic;
using CRUD.Domain.Entities.Client;
using CRUD.Domain.Entities.Generics;
using CRUD.Domain.Handlers.Contracts;
using CRUD.Domain.Repositories;
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
            [FromServices] ClientHandler handler)
        {
            return (GenericResult)handler.Handle(createClient);
        }

        /// <summary>Listar todos os registros de Clientes</summary>
        [Route("")]
        [HttpGet]
        public IEnumerable<ClientItem> GetAllClients(
            [FromServices] IClientRepository repository)
        {
            return repository.GetAll();
        }

        /// <summary>Atualiza Registro de Cliente</summary>
        /// <param name="updateClient">Objeto de requisição Cliente</param>
        /// <param name="handler">Injeção de dependencia</param>
        [Route("")]
        [HttpPut]
        public GenericResult UpdateClient(
            [FromBody] UpdateClient updateClient,
            [FromServices] ClientHandler handler)
        {
            return (GenericResult)handler.Handle(updateClient);
        }

        /// <summary>Criar novo Registro de Cliente</summary>
        /// <param name="deleteClient">Objeto de requisição Cliente</param>
        /// <param name="handler">Injeção de dependencia</param>
        [Route("")]
        [HttpDelete]
        public GenericResult DeleteClient(
            [FromBody] DeleteClient deleteClient,
            [FromServices] ClientHandler handler)
        {
            return (GenericResult)handler.Handle(deleteClient);
        }
    }
}