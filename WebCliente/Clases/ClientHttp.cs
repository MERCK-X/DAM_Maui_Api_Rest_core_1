using System.Text.Json;

namespace WebCliente.Clases
{
    public class ClientHttp
    {
        //Lista generica para cualquier tipo de Entidad de la BD
        public static async Task<List<T>> GetAll<T>(IHttpClientFactory _httpClientFactory, string urlbase, string rutaapi)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();
                cliente.BaseAddress = new Uri(urlbase);
                string cadena = await cliente.GetStringAsync(rutaapi);
                List<T> lista = JsonSerializer.Deserialize<List<T>>(cadena);
                return lista;
            }
            catch (Exception ex)
            {

                return new List<T>(); //Retornaría una lista vacia
            }

        }
        //Método GET para un solo objeto
        public static async Task<T> Get<T>(IHttpClientFactory _httpClientFactory, string urlbase, string rutaapi)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();
                cliente.BaseAddress = new Uri(urlbase);
                string cadena = await cliente.GetStringAsync(rutaapi);
                T lista = JsonSerializer.Deserialize<T>(cadena);
                return lista;
            }
            catch (Exception ex)
            {
                return (T)Activator.CreateInstance(typeof(T)); //Retornaría una instancia vacia de tipo T
            }
        }

        //Método DELETE para un solo objeto
        public static async Task<int> Delete(IHttpClientFactory _httpClientFactory, string urlbase, string rutaapi)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient();
                cliente.BaseAddress = new Uri(urlbase);
                var response = await cliente.DeleteAsync(rutaapi);
                if (response.IsSuccessStatusCode)
                {
                    string cadena = await response.Content.ReadAsStringAsync();
                    return int.Parse(cadena);
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception ex)
            {
                return 0; //Retornaría solo cero
            }
        }
    }
}
