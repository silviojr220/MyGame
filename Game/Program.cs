using Game.Entidades.Player;
using Game.Interface;
using Game.Interface.Menus;
using System.Security.Cryptography.X509Certificates;

class Principal
{
    public static void Main()
    {
        BarraDeProgresso barra = new();
        barra.BarraDeCarregamento();
        Console.Clear();

        Jogador player = new()
        {
            VidaAtual = 100,
            VidaMax = 100,

            EnergiaAtual = 60,
            EnergiaMax = 60,

            Level = 1,
            Exp = 0,

            Dano = 10
        };

       
        player.MostrarStatusBarra();
        MenuPrincipal menuPrincipal = new MenuPrincipal();
        menuPrincipal.MostrarMenu();


        MenuInventario inventario = new MenuInventario();
        inventario.Inventario();

    }

}