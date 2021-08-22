using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using todofc.Functions.functions;
using todofc.Test.Helpers;
using Xunit;

namespace todofc.Test.Test
{
    public class ScheduleFunctionTest
    {

        [Fact]
        public void ScheduleFunction_Showlg_log_Message()
        {
            // Arrange, preparar prueba unitaria
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreacconunt1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.list);

            // Act, ejecutar como tal
            ScheduleFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];

            // Assert, verificacion de resultado 
            Assert.Contains("Deleting completed", message);
        }
    }
}
