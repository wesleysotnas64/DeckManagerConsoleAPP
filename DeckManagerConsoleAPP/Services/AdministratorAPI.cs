using DeckManagerConsoleAPP.Entities;
using Newtonsoft.Json;
using System.Text;

namespace DeckManagerConsoleAPP.Services
{
    public class AdministratorAPI
    {
        private readonly string BaseURL = "https://localhost:44333/administrator-manager-api/";
        private readonly string GetAdministratorURL;
        private readonly string UpdateAdministratorURL;

        public AdministratorAPI()
        {
            GetAdministratorURL = BaseURL + "get-administrator/";
            UpdateAdministratorURL = BaseURL + "update-administrator";
        }

        public async Task<Administrator> GetAdministrator(string login)
        {
            try
            {
                string apiUrl = GetAdministratorURL + login;
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                Administrator administrator = null;
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    administrator = JsonConvert.DeserializeObject<Administrator>(json);
                }
                return administrator;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return null;
            }
        }

        public async Task UpdateAdministrator(Administrator administrator)
        {
            string administratorJson = JsonConvert.SerializeObject(administrator);
            HttpClient httpClient = new HttpClient();

            HttpContent content = new StringContent(administratorJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(UpdateAdministratorURL, content);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                // Processar o responseBody aqui, se necessário
            }
            else
            {
                Console.WriteLine($"Erro: {response.StatusCode}");
            }
        }
    }
}
