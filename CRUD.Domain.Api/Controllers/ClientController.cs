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

        /// <summary>Listar todos os registros de Clientes</summary>
        /// <param name="id">ID do Cliente</param>
        /// <param name="repository">Injeção de dependencia</param>
        [Route("{id}")]
        [HttpGet]
        public ClientItem GetClientById(int id,
            [FromServices] IClientRepository repository)
        {
            return repository.GetById(id);
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
        [Route("{Id}")]
        [HttpDelete]
        public GenericResult DeleteClient(
            [FromRoute] DeleteClient deleteClient,
            [FromServices] ClientHandler handler)
        {
            return (GenericResult)handler.Handle(deleteClient);
        }
    }
}