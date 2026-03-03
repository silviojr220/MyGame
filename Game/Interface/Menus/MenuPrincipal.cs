using Game.Entidades.Player;

namespace Game.Interface.Menus;

public class MenuPrincipal : MenuBase
{
    private readonly Jogador _jogador;

    public MenuPrincipal(Jogador jogador)
    {
        _jogador = jogador;
    }

    public override void Mostrar()
    {
        bool sair = false;

        while (!sair)
        {
            Console.Clear();

            _jogador.MostrarStatusBarra();

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
                    new MenuStatus(_jogador).Mostrar();
                    break;

                case 2:
                    new MenuInventario(_jogador).Mostrar();
                    break;

                case 3:
                    sair = true;
                    Console.WriteLine("\nSaindo do jogo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    EsperarContinuar();
                    break;
            }
        }
    }
}