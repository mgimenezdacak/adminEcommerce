using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
namespace EcommerceUaa
{
    public class Usuario
    {
        public string email { get; set; }
        public string password { get; set; }

        

        public static async Task<bool> VerificarLogin(Usuario u)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44375/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respuesta = await client.PostAsJsonAsync("Account/Login", new { email = u.email, password = u.password, rememberMe = false });
                if (respuesta.IsSuccessStatusCode)
                    return true;
                else
                   return false;
            }

        }

        public override string ToString()
        {
            return email;
        }

        
    }
}
