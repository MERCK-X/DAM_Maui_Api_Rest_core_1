using CapaEntidad;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebCliente.Clases;

namespace WebCliente.Controllers
{
    public class PersonaController : Controller
    {
        private string urlBase;
        private string cadena;
        private readonly IHttpClientFactory _httpClientFactory; 

        public PersonaController(IConfiguration configuracion,IHttpClientFactory httpClientFactory)
        {
            urlBase = configuracion["baseurl"];
            _httpClientFactory = httpClientFactory;
        }

        //Data como string
        //Listar personas
        public async Task<List<PersonaCLS>> listarPersonas(string url)
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlBase);

            //string cadena = await cliente.GetStringAsync("api/Persona");
            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return lista;

            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory, urlBase, "/api/Persona");

        }

        public async Task<List<PersonaCLS>> filtrarPersonas(string nombrecompleto, string url)
        {
            //var cliente = _httpClientFactory.CreateClient();
            //cliente.BaseAddress = new Uri(urlBase);
            //string cadena = await cliente.GetStringAsync("api/Persona/" + nombrecompleto);
            //string cadena = await cliente.GetStringAsync("api/Persona/" + nombrecompleto);
            //List<PersonaCLS> lista = JsonSerializer.Deserialize<List<PersonaCLS>>(cadena);
            //return lista;

            return await ClientHttp.GetAll<PersonaCLS>(_httpClientFactory,urlBase,"/api/Persona/"+nombrecompleto);
        }

        public async Task<PersonaCLS> RecuperarPersona(int id)
        {

            return await ClientHttp.Get<PersonaCLS>(_httpClientFactory, urlBase, "/api/Persona/recuperarPersona" + id);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
