using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Api.Controllers
{
    /// <summary>
    ///     Тестовый контроллер
    /// </summary>
    [ApiController]
    [Route("todo")]
    public class TodoController : ControllerBase
    {
        /// <summary>
        ///     Создание контроллера
        /// </summary>
        public TodoController(ILogger<TodoController> logger)
        {
            Logger = logger;
        }

        private ILogger<TodoController> Logger { get; }
        
        /// <summary>
        ///     Тестовый запрос
        /// </summary>
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }
    }
}