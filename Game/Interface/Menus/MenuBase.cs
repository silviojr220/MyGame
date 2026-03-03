namespace Game.Interface.Menus;

public abstract class MenuBase
{
    protected void EsperarContinuar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public abstract void Mostrar();
}