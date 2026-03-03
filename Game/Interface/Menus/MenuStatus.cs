using Game.Entidades.Player;

namespace Game.Interface.Menus;

public class MenuStatus : MenuBase
{
    private readonly Jogador _jogador;

    public MenuStatus(Jogador jogador)
    {
        _jogador = jogador;
    }

    public override void Mostrar()
    {
        Console.Clear();
        _jogador.MostrarStatusAtributos();

        EsperarContinuar();
    }
}