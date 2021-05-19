using System;
using System.Collections.Generic;
using CRUD.Domain.Entities.Client;
using CRUD.Domain.Entities.Generics;
using CRUD.Domain.Handlers.Contracts;
using CRUD.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRUD.Domain.Tests.HandlerTests
{
    [TestClass]
    public class DeleteClientHandlerTests
    {
        private readonly DeleteClient _invalidCommand = new DeleteClient();
        private readonly DeleteClient _validCommand = new DeleteClient(1);
        private readonly List<ClientItem> _clientList = new List<ClientItem>();
        private readonly ClientItem _client1 = new ClientItem("Willian", "willian.kaeru@gmail.com", "123456789", DateTime.Now);
        private readonly ClientItem _client2 = new ClientItem("Willian", "willian.kaeru@gmail.com", "123456789", DateTime.Now);
        private readonly ClientItem _client3 = new ClientItem("Willian", "willian.kaeru@gmail.com", "123456789", DateTime.Now);

        private readonly ClientHandler _handler = new ClientHandler(new FakeClientRepository());
        private GenericResult _validResult = new GenericResult();
        private GenericResult _invalidResult = new GenericResult();

        public DeleteClientHandlerTests()
        {
            _clientList.Add(_client1);
            _clientList.Add(_client2);
            _clientList.Add(_client3);

            _invalidResult = (GenericResult)_handler.Handle(_invalidCommand);
            _validCommand.Id = _client2.Id;
            _validResult = (GenericResult)_handler.Handle(_validCommand);
        }

        [TestMethod]
        public void Given_a_invalid_command_must_stop_running()
        {
            Assert.AreEqual(_invalidResult.Success, false);
        }
        [TestMethod]
        public void Given_a_valid_command_must_create_todo()
        {
            Assert.AreEqual(_validResult.Success, true);
        }
    }
}