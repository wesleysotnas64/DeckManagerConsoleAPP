using DeckManagerConsoleAPP.Entities;
using DeckManagerConsoleAPP.Utils;
using DeckManagerConsoleAPP.Services;

namespace DeckManagerConsoleAPP.Flow
{

    public class AdministratorFlow
    {
        private Administrator administrator;
        private string option;
        private bool loop;
        private bool waiting;

        public AdministratorFlow(Administrator adm)
        {
            administrator = adm;
            loop = true;
            waiting = true;

            Menu();
        }

        public void Menu()
        {
            while (loop)
            {
                waiting = true;

                Console.Clear();
                Layout.AdministratorMenu();
                option = Console.ReadLine();
                if(option != "")
                {
                    switch (option)
                    {
                        case "1":
                            GetAllCards();
                            break;

                        case "2":
                            GetCard();
                            break;

                        case "3":
                            AddCard();
                            break;

                        case "4":
                            UpdateCard();
                            break;

                        case "5":
                            DeleteCard();
                            break;

                        case "0":
                            waiting = false;
                            loop = false;
                            break;
                        default:
                            loop = false;
                            break;
                    }

                    while (waiting) { }
                }
            }
        }

        private async Task GetCard()
        {
            Layout.AdministratorGetCard();

            try
            {
                int id = int.Parse(Console.ReadLine());

                Card card = new Card();
                CardAPI cardAPI = new CardAPI();
                card = await cardAPI.GetCard(id);

                PrintCard(card);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar carta!");
                Console.WriteLine(ex.Message);
            }

            PressAnyKey();
        }

        public async Task GetAllCards()
        {
            Layout.AdministratorGetAllCard();
            List<Card> cards = new List<Card>();
            CardAPI cardAPI = new CardAPI();
            cards = await cardAPI.GetAllCards();

            foreach(Card c in cards)
            {
                PrintCard(c);
            }
            PressAnyKey();
        }

        private async Task AddCard()
        {
            Layout.AdministratorAddCard();

            Card card = new Card();
            card.Id = 0;
            try
            {
                Console.Write("NOME : ");
                card.Name = Console.ReadLine();
                Console.Write("PODER: ");
                card.Power = int.Parse(Console.ReadLine());
                Console.Write("RESIS: ");
                card.Toughness = int.Parse(Console.ReadLine());

                CardAPI cardAPI = new CardAPI();
                await cardAPI.AddCard(card);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao inserir os dados!");
                Console.WriteLine(e.Message);
            }

            PressAnyKey();
        }

        private async Task UpdateCard()
        {
            Layout.AdministratorUpdateCard();
            Card card = new Card();

            try
            {
                Console.Write("ID   : ");
                card.Id = int.Parse(Console.ReadLine());
                Console.Write("NOME : ");
                card.Name = Console.ReadLine();
                Console.Write("PODER: ");
                card.Power = int.Parse(Console.ReadLine());
                Console.Write("RESIS: ");
                card.Toughness = int.Parse(Console.ReadLine());

                CardAPI cardAPI = new CardAPI();
                await cardAPI.UpdateCard(card);

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao inserir os dados!");
                Console.WriteLine(e.Message);
            }

            PressAnyKey();
        }

        private async Task DeleteCard()
        {
            Layout.AdministratorDeleteCard();

            try
            {
                int id = int.Parse(Console.ReadLine());

                CardAPI cardAPI = new CardAPI();
                await cardAPI.DeleteCard(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao inserir os dados!");
                Console.WriteLine(e.Message);
            }

            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            waiting = false;
        }

        private void PrintCard(Card card)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("ID   : " + card.Id);
            Console.WriteLine("NOME : " + card.Name);
            Console.WriteLine("PODER: " + card.Power);
            Console.WriteLine("RESIS: " + card.Toughness);
        }

    }
}
