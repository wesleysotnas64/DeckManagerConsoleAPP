using DeckManagerConsoleAPP.Entities;
using DeckManagerConsoleAPP.Services;
using DeckManagerConsoleAPP.Utils;

namespace DeckManagerConsoleAPP.Flow
{
    public class LoginFlow
    {
        private bool loop;
        private bool waiting;
        private string login;
        private string password;

        public LoginFlow()
        {
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
                Layout.LoginMenu();
                Console.Write("Login: ");
                login = Console.ReadLine();
                Console.Write("Senha: ");
                password = Console.ReadLine();

                Console.WriteLine("Verificando login. Aguarde...");

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Login ou senha não informado!");
                    PressAnyKey();
                }
                else
                {
                    Login();
                }

                while (waiting);
            
            }
        }

        private async Task Login()
        {

            Player player = new Player();
            PlayerAPI playerAPI = new PlayerAPI();
            player = await playerAPI.GetPlayer(login);

            if (player != null)
            {
                if(password == player.Password)
                {
                    new PlayerFlow(player);
                }
                else
                {
                    Console.WriteLine("Login incorreto!");
                }
            }
            else
            {
                Administrator administrator = new Administrator();
                AdministratorAPI administratorAPI = new AdministratorAPI();
                administrator = await administratorAPI.GetAdministrator(login);

                if(administrator != null)
                {
                    if(password == administrator.Password)
                    {
                        new AdministratorFlow(administrator);
                    }
                    else
                    {
                        Console.WriteLine("Login incorreto!");
                    }
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado!");
                }

            }

            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            waiting = false;
        }
    }
}
