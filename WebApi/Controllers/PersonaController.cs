using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using WebApi.Models;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        [HttpGet]
        public List<PersonaCLS> ListaPersona()
        {
            List<PersonaCLS> listaPersona = new List<PersonaCLS>();
            
            try
            {
                using (DbAb7234BdveterinariaContext bd = new DbAb7234BdveterinariaContext())
                {
                    listaPersona = (from p in bd.Personas where p.Bhabilitado == 1 select new PersonaCLS
                                    {
                                        iidpersona = p.Iidpersona,
                                        nombrecompleto = p.Nombre + " " + p.Appaterno + " " + p.Apmaterno,
                                        correo = p.Correo,
                                        fechanacimientocadena = p.Fechanacimiento == null ? "" : 
                                        p.Fechanacimiento.Value.ToString("MM/dd/yyyy")
                    }).ToList();
                }

                return listaPersona;
            }
            catch(Exception)
            {
                return listaPersona;
            }
        }


        //Con filtro
        [HttpGet("{nombrecompleto}")]
        public List<PersonaCLS> ListaPersona(string nombrecompleto)
        {
            List<PersonaCLS> listaPersona = new List<PersonaCLS>();

            try
            {
                using (DbAb7234BdveterinariaContext bd = new DbAb7234BdveterinariaContext())
                {
                    listaPersona = (from p in bd.Personas
                                    where p.Bhabilitado == 1
                                    && (p.Nombre + " " + p.Appaterno + " " + p.Apmaterno).Contains(nombrecompleto)
                                    select new PersonaCLS
                                    {
                                        iidpersona = p.Iidpersona,
                                        nombrecompleto = p.Nombre + " " + p.Appaterno + " " + p.Apmaterno,
                                        correo = p.Correo,
                                        fechanacimientocadena = p.Fechanacimiento == null ? "" :
                                        p.Fechanacimiento.Value.ToString("MM/dd/yyyy")
                                    }).ToList();
                }

                return listaPersona;
            }
            catch (Exception)
            {
                return listaPersona;
            }
        }

        //Con filtro
        [HttpGet("recuperarPersonaPorId/{id}")]
        public PersonaCLS recuperarPersonaPorId(int id)
        {
            PersonaCLS oPersonaCLS = new PersonaCLS();

            try
            {
                using (DbAb7234BdveterinariaContext bd = new DbAb7234BdveterinariaContext())
                {
                    oPersonaCLS = (from p in bd.Personas
                                   where p.Bhabilitado == 1 && p.Iidpersona == id
                                   select new PersonaCLS
                                   {
                                       iidpersona = p.Iidpersona,
                                       nombre = p.Nombre,
                                       appaterno = p.Appaterno,
                                       apmaterno = p.Apmaterno,
                                       fechanacimiento = (DateTime)p.Fechanacimiento,
                                       fechanacimientocadena = p.Fechanacimiento == null ? "" :
                                       p.Fechanacimiento.Value.ToString("dd/MM/yyyy"),
                                       iisexo = (int)p.Iidsexo
                                   }).First();
                }

                return oPersonaCLS;
            }
            catch (Exception)
            {
                return oPersonaCLS;
            }
        }
    }
}
