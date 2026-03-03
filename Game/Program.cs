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

        Jogador player = new();


        MenuPrincipal menu = new(player);
        menu.Mostrar();
    }

}