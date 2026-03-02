using Game.Entidades.Player;
namespace Game.Interface.Menus;

public class MenuPrincipal
{
    public void MostrarMenu()
    {
        bool sair = false;

        while (!sair)
        {
            
            Console.WriteLine("\n==- Menu Principal -==\n");
            Console.WriteLine("1 - Status Geral");
            Console.WriteLine("2 - Inventário");
            Console.WriteLine("3 - Sair");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine()!;
            bool isNumber = int.TryParse(opcao, out int opcaoNumber);

            if (!isNumber)
            {
                Console.WriteLine("Por favor, digite um número válido.");
                EsperarContinuar();
                continue;
            }

            switch (opcaoNumber)
            {
                case 1:
                    Console.Clear();
                    MenuStatus menuStatus = new MenuStatus();
                    menuStatus.StatusGeral();
                    break;

                case 2:
                    Console.Clear();
                    MenuInventario menuInventario = new MenuInventario();
                    menuInventario.Inventario();
                    break;

                case 3:
                    sair = true;
                    Console.WriteLine("Saindo do jogo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    EsperarContinuar();
                    break;
            }
        }
    }

    public void EsperarContinuar()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
