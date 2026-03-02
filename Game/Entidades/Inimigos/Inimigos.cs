namespace Game.Entidades.Inimigos;

public class Inimigo
{
    public string Nome { get; set; }
    public int VidaAtual { get; set; }
    public int VidaMax { get; set; }
    public int DanoMin { get; set; }
    public int DanoMax { get; set; }

    private static Random rng = new Random();

    public Inimigo(string nome, int vidaMax, int danoMin, int danoMax)
    {
        Nome = nome;
        VidaMax = vidaMax;
        VidaAtual = vidaMax;
        DanoMin = danoMin;
        DanoMax = danoMax;
    }

    public int Atacar()
    {
        return rng.Next(DanoMin, DanoMax + 1);
    }

    public void ReceberDano(int dano)
    {
        VidaAtual -= dano;
        if (VidaAtual < 0) VidaAtual = 0;
        Console.WriteLine($"{Nome} recebeu {dano} de dano! Vida atual: {VidaAtual}/{VidaMax}");
    }

    public bool EstaVivo()
    {
        return VidaAtual > 0;
    }
}