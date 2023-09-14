namespace DeckManagerConsoleAPP.Utils
{
    public static class Layout
    {
        public static void LoginMenu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|                 Login                 |");
            Console.WriteLine("=========================================");
        }

        public static void PlayerMenu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|            Menu do Jogador            |");
            Console.WriteLine("=========================================");
            Console.WriteLine("[1] Gerenciar Coleção");
            Console.WriteLine("[2] Gerenciar Decks");
            Console.WriteLine("[0] Sair");

            Console.Write("-> ");
        }

        public static void PlayerCollectionMenu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|           Gerenciar Coleção           |");
            Console.WriteLine("=========================================");
            Console.WriteLine("[1] Listar Todas as Cartas");
            Console.WriteLine("[2] Listar Coleção");
            Console.WriteLine("[3] Solicitar Carta");
            Console.WriteLine("[0] Sair");

            Console.Write("-> ");
        }

        public static void PlayerDeckMenu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|            Gerenciar Decks            |");
            Console.WriteLine("=========================================");
            Console.WriteLine("[1] Listar Todos os Decks");
            Console.WriteLine("[2] Listar Deck");
            Console.WriteLine("[3] Criar Deck");
            Console.WriteLine("[4] Adicionar Carta ao Deck");
            Console.WriteLine("[5] Remover Carta do Deck");
            //Console.WriteLine("[6] Deletar Deck");
            Console.WriteLine("[0] Sair");

            Console.Write("-> ");
        }

        public static void PlayerColection()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|                Coleção                |");
            Console.WriteLine("=========================================");
        }

        public static void PlayerAllDecks()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|             Todos os Decks            |");
            Console.WriteLine("=========================================");
        }

        public static void PlayerDeck()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|              Listar Deck              |");
            Console.WriteLine("=========================================");
        }

        public static void PlayerRequestCardToCollection()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|            Solicitar Carta            |");
            Console.WriteLine("=========================================");

        }

        public static void PlayerCreateDeck()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|              Criar Deck               |");
            Console.WriteLine("=========================================");
        }

        public static void PlayerAddCardToDeck()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|        Adicionar Carta ao Deck        |");
            Console.WriteLine("=========================================");
        }

        public static void PlayerRmvCardFromDeck()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|         Remover Carta do Deck         |");
            Console.WriteLine("=========================================");
        }


        public static void AdministratorMenu()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("|             Administrador             |");
            Console.WriteLine("=========================================");
            Console.WriteLine("[1] Buscar Todas as Carta");
            Console.WriteLine("[2] Buscar Carta");
            Console.WriteLine("[3] Adicionar Carta");
            Console.WriteLine("[4] Atualizar Carta");
            Console.WriteLine("[5] Deletar Carta");
            Console.WriteLine("[0] Sair");
            Console.Write("-> ");
        }

        public static void AdministratorAddCard()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|            Adicionar Carta            |");
            Console.WriteLine("=========================================");
        }

        public static void AdministratorGetCard()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|             Buscar Carta              |");
            Console.WriteLine("=========================================");
            Console.Write("Id: ");
        }

        public static void AdministratorGetAllCard()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|         Buscar Todas as Cartas        |");
            Console.WriteLine("=========================================");
        }

        public static void AdministratorUpdateCard()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|            Atualizar Carta            |");
            Console.WriteLine("=========================================");
        }

        public static void AdministratorDeleteCard()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("|             Deletar Carta             |");
            Console.WriteLine("=========================================");
            Console.Write("Id: ");
        }
    }
}
