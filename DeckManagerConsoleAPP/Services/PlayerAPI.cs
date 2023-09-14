using DeckManagerConsoleAPP.Entities;
using Newtonsoft.Json;
using System.Text;

namespace DeckManagerConsoleAPP.Services
{
    public class PlayerAPI
    {
        private readonly string BaseURL = "https://localhost:44333/player-manager-api/";
        private readonly string GetPlayerURL;
        private readonly string UpdatePlayerURL;

        public PlayerAPI()
        {
            GetPlayerURL = BaseURL + "get-player/";
            UpdatePlayerURL = BaseURL + "update-player";
        }

        public async Task<Player> GetPlayer(string login)
        {
            try
            {
                string apiUrl = GetPlayerURL + login;
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                Player player = null;
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    player = JsonConvert.DeserializeObject<Player>(json);
                }
                return player;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return null;
            }
        }

        public async Task UpdatePlayer(Player player)
        {
            string playerJson = JsonConvert.SerializeObject(player);
            HttpClient httpClient = new HttpClient();

            HttpContent content = new StringContent(playerJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(UpdatePlayerURL, content);
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
