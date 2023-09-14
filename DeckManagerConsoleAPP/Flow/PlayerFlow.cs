using DeckManagerConsoleAPP.Entities;
using DeckManagerConsoleAPP.Services;
using DeckManagerConsoleAPP.Utils;

namespace DeckManagerConsoleAPP.Flow
{
    public class PlayerFlow
    {
        private Player player;
        private string option;
        private bool loop;
        private bool waiting;
        
        public PlayerFlow(Player p)
        {
            player = p;
            waiting = true;
            loop = true;
            Menu();
        }

        private void Menu()
        {
            loop = true;
            while(loop)
            {
                waiting = true;

                Console.Clear();
                Layout.PlayerMenu();
                option = Console.ReadLine();
                if (!string.IsNullOrEmpty(option))
                {
                    switch(option)
                    {
                        case "1":
                            CollectionMenu();
                            loop = true;
                            break;

                        case "2":
                            DeckMenu();
                            loop = true;
                            break;

                        case "0":
                            loop = false;
                            waiting = false;
                            break;

                        default:
                            Console.WriteLine("Selecionte uma opção!");
                            PressEnter();
                            break;
                    }

                    while (waiting) ;
                }
            }
        }

        private void CollectionMenu()
        {
            loop = true;
            while (loop)
            {
                waiting = true;

                Console.Clear();
                Layout.PlayerCollectionMenu();
                option = Console.ReadLine();
                if (!string.IsNullOrEmpty(option))
                {
                    switch (option)
                    {
                        case "1":
                            GetAllCards();
                            break;

                        case "2":
                            ListCollection();
                            break;

                        case "3":
                            RequestCardToCollection();
                            break;

                        case "0":
                            loop = false;
                            waiting = false;
                            break;

                        default:
                            Console.WriteLine("Selecionte uma opção!");
                            PressEnter();
                            break;
                    }

                    while (waiting) ;
                }
            }
        }

        private void DeckMenu()
        {
            loop = true;
            while (loop)
            {
                waiting = true;

                Console.Clear();
                Layout.PlayerDeckMenu();
                option = Console.ReadLine();
                if (!string.IsNullOrEmpty(option))
                {
                    switch (option)
                    {
                        case "1":
                            ListAllDcks();
                            break;

                        case "2":
                            ListDeck();
                            break;

                        case "3":
                            CreateDeck();
                            break;

                        case "4":
                            AddCardToDeck();
                            break;

                        case "5":
                            RmvCardFromDeck();
                            break;

                        case "6":
                            AlterNameDeck();
                            break;

                        case "7":
                            DeleteDeck();
                            break;

                        case "0":
                            loop = false;
                            waiting = false;
                            break;

                        default:
                            Console.WriteLine("Selecionte uma opção!");
                            PressEnter();
                            break;
                    }

                    while (waiting) ;
                }
            }
        }

        public async Task DeleteDeck()
        {
            Layout.PlayerAlterNameDeck();
            Console.Write("ID do deck: ");
            string idDeck = Console.ReadLine();

            if(!string.IsNullOrEmpty(idDeck))
            {
                try
                {
                    Deck existingDeck = player.Decks.FirstOrDefault(d => d.Id == int.Parse(idDeck));
                    if(existingDeck != null)
                    {
                        player.Decks.Remove(existingDeck);
                        new PlayerAPI().UpdatePlayer(player);
                        Console.WriteLine($"Deck [{existingDeck.Name}] removido!");
                    }
                    else
                    {
                        Console.WriteLine("Deck inexistente!");
                    }
                }
                catch
                {
                    Console.WriteLine("Caractere inválido!");
                }
            }
            else
            {
                Console.WriteLine("Id do deck não pode ser nulo.");
            }

            PressEnter();
        }

        public async Task AlterNameDeck()
        {
            Layout.PlayerAlterNameDeck();
            Console.Write("ID do deck: ");
            string idDeck = Console.ReadLine();

            if (!string.IsNullOrEmpty(idDeck))
            {
                Deck existingDeck = player.Decks.FirstOrDefault(d => d.Id == int.Parse(idDeck));
                if (existingDeck != null)
                {
                    Console.Write("Novo Dome do Deck: ");
                    string newName = Console.ReadLine();

                    if (!string.IsNullOrEmpty(newName))
                    {
                        int index = player.Decks.IndexOf(existingDeck);
                        player.Decks[index].Name = newName;
                        new PlayerAPI().UpdatePlayer(player);
                        Console.WriteLine("Nome Alterado!");
                    }
                    else
                    {
                        Console.WriteLine("Nome do deck não pode ser nulo");
                    }

                }
                else
                {
                    Console.WriteLine("Deck inexistente!");
                }

            }
            else
            {
                Console.WriteLine("ID do deck não pode ser nulo!");
            }

            PressEnter();
        }

        public async Task RmvCardFromDeck()
        {
            Layout.PlayerRmvCardFromDeck();
            Console.Write("ID do deck: ");
            string idDeck = Console.ReadLine();

            if (!string.IsNullOrEmpty(idDeck))
            {
                Deck existingDeck= player.Decks.FirstOrDefault(d => d.Id == int.Parse(idDeck));
                if(existingDeck != null)
                {
                    Console.Write("ID da carta: ");
                    string idCard = Console.ReadLine();

                    Card existingCard = existingDeck.Cards.FirstOrDefault(c => c.Id == int.Parse(idCard));
                    if(existingCard != null)
                    {
                        int index = player.Decks.IndexOf(existingDeck);
                        player.Decks[index].Cards.Remove(existingCard);
                        new PlayerAPI().UpdatePlayer(player);
                        Console.WriteLine($"Carta [{existingCard.Name}] removida");
                    }
                    else
                    {
                        Console.WriteLine($"Carta não existe no deck [{existingDeck.Name}]");
                    }

                }
                else
                {
                    Console.WriteLine("Deck inexistente!");
                }

            }
            else
            {
                Console.WriteLine("ID do deck não pode ser nulo!");
            }

            PressEnter();

        }

        public async Task AddCardToDeck()
        {
            Layout.PlayerAddCardToDeck();
            Console.Write("ID da carta na coleção: ");
            string idCarta = Console.ReadLine();

            if(!string.IsNullOrEmpty(idCarta))
            {

                Card existingCard= player.Colection.FirstOrDefault(c => c.Id == int.Parse(idCarta));
                if(existingCard != null)
                {
                    Console.Write("ID do deck destino: ");
                    string idDeck = Console.ReadLine();

                    if(!string.IsNullOrEmpty(idDeck))
                    {
                        Deck existingDeck = player.Decks.FirstOrDefault(d => d.Id == int.Parse(idDeck));
                        if(existingDeck != null)
                        {
                            int index = player.Decks.IndexOf(existingDeck);
                            existingDeck.Cards.Add(existingCard);
                            player.Decks[index] = existingDeck;
                            new PlayerAPI().UpdatePlayer(player);
                            Console.WriteLine($"Card [{existingCard.Name}] adicionada ao deck [{existingDeck.Name}].");
                        }
                        else
                        {
                            Console.WriteLine("Deck inexistente!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID do deck não pode ser nulo!");
                    }
                }
                else
                {
                    Console.WriteLine("Carta não está na sua coleção!");
                }

            }
            else
            {
                Console.WriteLine("ID da carta não pode ser nulo!");
            }

            PressEnter();
        }

        public async Task CreateDeck()
        {
            Layout.PlayerCreateDeck();
            Console.Write("Nome do deck: ");
            string option = Console.ReadLine();
            if (!string.IsNullOrEmpty(option))
            {
                Deck existingDeck = null;
                try
                {
                    existingDeck = player.Decks.FirstOrDefault(d => d.Name == option);
                    if (existingDeck == null)
                    {
                        existingDeck = new Deck();
                        existingDeck.Id = GetNextId();
                        existingDeck.Name = option;
                        existingDeck.Cards = new List<Card>();
                        player.Decks.Add(existingDeck);
                        new PlayerAPI().UpdatePlayer(player);
                        Console.WriteLine("Deck adicionado!");
                    }
                    else
                    {
                        Console.WriteLine("Deck com mesmo nome já existe!");
                    }
                }
                catch
                {
                    Console.WriteLine("Erro na criação do deck!");
                }
            }
            else
            {
                Console.WriteLine("Não é possível criar um deck sem nome!");
            }

            PressEnter();
        }

        public async Task GetAllCards()
        {
            Layout.AdministratorGetAllCard();
            List<Card> cards = new List<Card>();
            CardAPI cardAPI = new CardAPI();
            cards = await cardAPI.GetAllCards();

            foreach (Card c in cards)
            {
                PrintCard(c);
            }
            PressEnter();
        }

        public void ListCollection()
        {
            Layout.PlayerColection();

            foreach (Card c in player.Colection)
            {
                PrintCard(c);
            }

            PressEnter() ;
        }

        public void ListAllDcks()
        {
            Layout.PlayerAllDecks();

            foreach(Deck d in player.Decks)
            {
                PrintDeck(d);
            }

            PressEnter();
        }

        public void ListDeck()
        {
            Layout.PlayerDeck();
            Console.Write("ID: ");
            string option = Console.ReadLine();
            if (!string.IsNullOrEmpty(option))
            {
                Deck existingDeck = null;
                try
                {
                    existingDeck = player.Decks.FirstOrDefault(d => d.Id == int.Parse(option));
                    if (existingDeck != null)
                    {
                        PrintDeck(existingDeck);
                    }
                    else
                    {
                        Console.WriteLine("Deck inexistente!");
                    }
                }
                catch
                {
                    Console.WriteLine("Erro ao inserir o ID.");
                }
            }

            PressEnter();

        }

        public async void RequestCardToCollection()
        {
            Layout.PlayerRequestCardToCollection();

            Console.Write("ID: ");
            string option = Console.ReadLine();
            if(!string.IsNullOrEmpty(option))
            {
                CardAPI cardAPI = new CardAPI();
                Card card = new Card();
                card = await cardAPI.GetCard(int.Parse(option));

                if(card != null)
                {
                    player.Colection.Add(card);
                    new PlayerAPI().UpdatePlayer(player);
                    Console.WriteLine("Carta adicionada à sua coleção!");
                }
                else
                {
                    Console.WriteLine("Carta inexistente! Impossível adicionar.");
                }
                
            }

            PressEnter();
        }

        private void PressEnter()
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            waiting = false;
        }

        private void PrintCard(Card card)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("ID   : " + card.Id);
            Console.WriteLine("NOME : " + card.Name);
            Console.WriteLine("PODER: " + card.Power);
            Console.WriteLine("RESIS: " + card.Toughness);
        }

        private void PrintDeck(Deck d)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Id  : " + d.Id);
            Console.WriteLine("Nome: " + d.Name);
            if(d.Cards.Count > 0)
            {
                foreach (Card c in d.Cards)
                {
                    PrintCard(c);
                }
            }
            else
            {
                Console.WriteLine("Deck vazio!");
            }
        }

        private int GetNextId()
        {
            int maxId = player.Decks.Count > 0 ? player.Decks.Max(c => c.Id) : 0;
            return maxId + 1;
        }

    }
}
