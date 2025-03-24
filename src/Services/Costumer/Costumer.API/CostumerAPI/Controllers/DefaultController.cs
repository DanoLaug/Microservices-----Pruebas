using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    //Añadimos el atributo ApiController para indicar que es un controlador de API y el atributo Route para indicar la ruta
    [ApiController]
    [Route("/")]
    public class DefaultController : Controller
    {
        // Definimos el método Index que devuelve un string y retorna un mensaje
        [HttpGet]
        public string Index()
        {
            return "Customer.API it's working...";
        }
    }
}