using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using todofc.Common.Models;
using todofc.Functions.functions;
using todofc.Test.Helpers;
using Xunit;

namespace todofc.Test.Test
{
    public class TodoApiTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        // primer prueba unitaria
        [Fact]
        public async void CreateTodo_Should_Return_200()
        {
            // Arrange, preparar prueba unitaria
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreacconunt1/reports"));
            Todo todoRequest = TestFactory.GetTodoRquest();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoRequest);

            // Act, ejecutar como tal
            IActionResult response = await TodoApi.CreateTodo(request, mockTodos, logger);

            // Assert, verificacion de resultado 
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async void UpdateTodo_Should_Return_200()
        {
            // Arrange, preparar prueba unitaria
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreacconunt1/reports"));
            Todo todoRequest = TestFactory.GetTodoRquest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoRequest);

            // Act, ejecutar como tal
            IActionResult response = await TodoApi.UpdateTodo(request, mockTodos, todoId.ToString(), logger);

            // Assert, verificacion de resultado 
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
