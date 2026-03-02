namespace Game.Entidades.Player;

public class Jogador
{
    public int VidaAtual { get; set; }
    public int VidaMax { get; set; }
    public int EnergiaAtual { get; set; }
    public int EnergiaMax { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }
    public int ExpMax { get; set; } = 100;

    public int Dano { get; set; } // ← Nova propriedade de dano

    public void ReceberDano(int dano)
    {
        VidaAtual -= dano;
        if (VidaAtual < 0) VidaAtual = 0;
        Console.WriteLine($"Você recebeu {dano} de dano! Vida atual: {VidaAtual}/{VidaMax}");
    }

    public void Curar(int cura)
    {
        VidaAtual += cura;
        if (VidaAtual > VidaMax) VidaAtual = VidaMax;
        Console.WriteLine($"Você foi curado em {cura}! Vida atual: {VidaAtual}/{VidaMax}");
    }

    public bool EstaVivo()
    {
        return VidaAtual > 0;
    }

    private string GerarBarra(int atual, int max, int tamanhoBarra, int? corPreenchido = null, int? corVazio = null)
    {
        if (max <= 0) return "";

        int preenchido = (int)Math.Round((double)atual / max * tamanhoBarra);
        preenchido = Math.Clamp(preenchido, 0, tamanhoBarra);

        int vazio = tamanhoBarra - preenchido;

        string parteCheia = new string('█', preenchido);
        string parteVazia = new string('░', vazio);

        if (corPreenchido.HasValue)
            parteCheia = $"\u001b[38;5;{corPreenchido}m{parteCheia}\u001b[0m";

        if (corVazio.HasValue)
            parteVazia = $"\u001b[38;5;{corVazio}m{parteVazia}\u001b[0m";

        return parteCheia + parteVazia;
    }

    public void MostrarStatusBarra()
    {
        Console.SetCursorPosition(0, 0);
        const int tamanhoBarra = 20;

        string barraVida = GerarBarra(VidaAtual, VidaMax, tamanhoBarra, 10, 1);
        string barraEnergia = GerarBarra(EnergiaAtual, EnergiaMax, tamanhoBarra, 20, 4);
        string barraExp = GerarBarra(Exp, ExpMax, tamanhoBarra, 226, 3);

        Console.Write($"[ {barraVida} HP {VidaAtual}/{VidaMax} | ");
        Console.Write($"{barraEnergia} EN {EnergiaAtual}/{EnergiaMax} | ");
        Console.Write($"{barraExp} ] EXP {Exp}/{ExpMax} - ");
        Console.WriteLine($"LEVEL: \u001b[38;5;226m{Level}\u001b[0m ]");
    }
}