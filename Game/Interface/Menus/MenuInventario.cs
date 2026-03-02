namespace Game.Interface.Menus;

class MenuInventario : MenuPrincipal
{
    public void Inventario()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n==- Inventario -==\n");
            Console.WriteLine("1- Checar itens");
            Console.WriteLine("2- Craftar itens");
            Console.WriteLine("3- Reparar equipamento/itens");
            Console.WriteLine("4- Sair");
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
                    CraftarItens();
                    break;
                case 3:
                    RepararItens();
                    break;
                case 4:
                    sair = true;
                    Console.WriteLine("Saindo do inventário...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (!sair)
            {
                EsperarContinuar();
            }
        }
    }

    private void ChecarItens()
    {
        Console.WriteLine("Checando itens...");
        // Lógica para mostrar os itens do inventário
    }

    private void CraftarItens()
    {
        Console.WriteLine("Craftando itens...");
        // Lógica de crafting
    }

    private void RepararItens()
    {
        Console.WriteLine("Reparando equipamento/itens...");
        // Lógica de reparo
    }
}