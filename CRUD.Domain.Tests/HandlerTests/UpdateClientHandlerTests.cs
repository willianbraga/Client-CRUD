using System;
using CRUD.Domain.Entities.Client;
using CRUD.Domain.Entities.Generics;
using CRUD.Domain.Handlers.Contracts;
using CRUD.Domain.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRUD.Domain.Tests.HandlerTests
{
    [TestClass]
    public class UpdateClientHandlerTests
    {
        private readonly UpdateClient _invalidCommand = new UpdateClient(new Guid(), "", "", "", DateTime.Now);
        private readonly UpdateClient _validCommand = new UpdateClient(new Guid(), "Willian", "willian.kaeru@gmail.com", "123456789", DateTime.Now);
        private readonly ClientHandler _handler = new ClientHandler(new FakeClientRepository());
        private GenericResult _validResult = new GenericResult();
        private GenericResult _invalidResult = new GenericResult();

        public UpdateClientHandlerTests()
        {
            _invalidResult = (GenericResult)_handler.Handle(_invalidCommand);
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