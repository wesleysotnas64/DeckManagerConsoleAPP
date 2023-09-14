using DeckManagerConsoleAPP.Entities;
using Newtonsoft.Json;
using System.Text;

namespace DeckManagerConsoleAPP.Services
{
    public class CardAPI
    {
        private readonly string BaseURL = "https://localhost:44333/card-manager-api/";
        private readonly string AddCardURL;
        private readonly string GetCardURL;
        private readonly string GetAllCardsURL;
        private readonly string UpdateCardURL;
        private readonly string DeleteCardURL;
        public CardAPI()
        {
            AddCardURL = BaseURL + "add-card";
            GetCardURL = BaseURL + "get-card/";
            GetAllCardsURL = BaseURL + "get-all-cards";
            UpdateCardURL = BaseURL + "update-card";
            DeleteCardURL = BaseURL + "delete-card/";
        }

        public async Task<Card> GetCard(int id)
        {
            try
            {
                string apiUrl = GetCardURL + id;
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                Card card = null;
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    card = JsonConvert.DeserializeObject<Card>(json);
                }
                return card;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Card>> GetAllCards()
        {
            try
            {
                string apiUrl = GetAllCardsURL;
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                List<Card> cards = new List<Card>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    cards = JsonConvert.DeserializeObject<List<Card>>(json);
                }
                return cards;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return null;
            }
        }

        public async Task AddCard(Card card)
        {
            string cardJson = JsonConvert.SerializeObject(card);
            HttpClient httpClient = new HttpClient();

            HttpContent content = new StringContent(cardJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(AddCardURL, content);
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

        public async Task UpdateCard(Card card)
        {
            string cardJson = JsonConvert.SerializeObject(card);
            HttpClient httpClient = new HttpClient();

            HttpContent content = new StringContent(cardJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(UpdateCardURL, content);
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

        public async Task DeleteCard(int id)
        {
            string apiUrl = DeleteCardURL + id;
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.DeleteAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Exclusão bem-sucedida.");
            }
            else
            {
                Console.WriteLine($"Erro: {response.StatusCode}");
            }
        }

    }
}
