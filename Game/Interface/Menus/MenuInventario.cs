using Game.Entidades.Player;

namespace Game.Interface.Menus;

public class MenuInventario : MenuBase
{
    private readonly Jogador _jogador;

    public MenuInventario(Jogador jogador)
    {
        _jogador = jogador;
    }

    public override void Mostrar()
    {
        bool sair = false;

        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("==- Inventário -==\n");
            Console.WriteLine("1 - Checar Itens");
            Console.WriteLine("2 - Usar Poção (cura 20)");
            Console.WriteLine("3 - Craftar Itens");
            Console.WriteLine("4 - Reparar Equipamentos");
            Console.WriteLine("5 - Voltar");
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
                    ChecarItens();
                    break;

                case 2:
                    UsarPocao();
                    break;

                case 3:
                    CraftarItens();
                    break;

                case 4:
                    RepararItens();
                    break;

                case 5:
                    sair = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    EsperarContinuar();
                    break;
            }
        }
    }

    private void ChecarItens()
    {
        Console.WriteLine("\nItens no inventário:");
        Console.WriteLine("- Espada de Ferro");
        Console.WriteLine("- Poção de Cura (x1)");
        EsperarContinuar();
    }

    private void UsarPocao()
    {
        _jogador.Curar(20);
        Console.WriteLine("\nVocê usou uma Poção de Cura!");
        EsperarContinuar();
    }

    private void CraftarItens()
    {
        Console.WriteLine("\nSistema de crafting ainda não implementado.");
        EsperarContinuar();
    }

    private void RepararItens()
    {
        Console.WriteLine("\nSistema de reparo ainda não implementado.");
        EsperarContinuar();
    }
}