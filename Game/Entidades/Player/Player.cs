using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Entidades.Player
{
    public class Jogador
    {
        // =========================
        // STATUS
        // =========================
        public int VidaAtual { get; private set; }
        public int VidaMax { get; private set; }
        public int EnergiaAtual { get; private set; }
        public int EnergiaMax { get; private set; }
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public int ExpMax { get; private set; }
        public int Dano { get; private set; }

        // =========================
        // ATRIBUTOS BASE
        // =========================
        public int Forca { get; private set; }
        public int Destreza { get; private set; }
        public int Inteligencia { get; private set; }
        public int Sabedoria { get; private set; }
        public int Carisma { get; private set; }

        // ATRIBUTOS DERIVADOS
        public int Percepcao => Inteligencia;
        public int Velocidade => Destreza;

        // =========================
        // PONTOS PARA DISTRIBUIR AO SUBIR DE LEVEL
        // =========================
        public int PontosStatus { get; private set; }

        // =========================
        // BARRAS CONFIGURÁVEIS
        // =========================
        private readonly Dictionary<string, int> TamanhosBarras = new()
        {
            { "Vida", 20 },
            { "Energia", 15 },
            { "Dano", 10 },
            { "Level", 10 },
            { "Exp", 25 },
            { "Força", 15 }, 
            { "Destreza", 15 },
            { "Inteligencia", 15 },
            { "Sabedoria", 15 },
            { "Carisma", 15 },
            { "Percepcao", 15 },
            { "Velocidade", 15 }
        };

        // =========================
        // MÁXIMOS PERSONALIZÁVEIS
        // =========================
        private readonly Dictionary<string, int> Maximos = new();

        public Jogador()
        {
            // Status base
            VidaMax = 100; VidaAtual = 100;
            EnergiaMax = 50; EnergiaAtual = 50;
            Level = 1; Exp = 0; ExpMax = 100;
            Dano = 10;

            // Atributos base
            Forca = 5; Destreza = 5; Inteligencia = 5; Sabedoria = 5; Carisma = 5;

            // Define os máximos iniciais
            Maximos["Vida"] = VidaMax;
            Maximos["Energia"] = EnergiaMax;
            Maximos["Level"] = 100;
            Maximos["Exp"] = ExpMax;

            Maximos["Força"] = 100;
            Maximos["Destreza"] = 100;
            Maximos["Inteligencia"] = 100;
            Maximos["Sabedoria"] = 100;
            Maximos["Carisma"] = 100;

            Maximos["Percepcao"] = 100;
            Maximos["Velocidade"] = 100;

            PontosStatus = 0;
        }

        // =========================
        // MECÂNICAS
        // =========================
        public void ReceberDano(int dano)
        {
            VidaAtual -= dano;
            if (VidaAtual < 0) VidaAtual = 0;
        }

        public void Curar(int cura)
        {
            VidaAtual += cura;
            if (VidaAtual > VidaMax) VidaAtual = VidaMax;
        }

        public bool EstaVivo() => VidaAtual > 0;

        // =========================
        // GANHAR XP E SUBIR DE NÍVEL
        // =========================
        public void GanharXP(int xp)
        {
            Exp += xp;
            while (Exp >= ExpMax)
            {
                Exp -= ExpMax;
                SubirNivel();
            }
        }

        private void SubirNivel()
        {
            Level++;
            // A cada level aumenta XP necessário em 50% (progressivo)
            ExpMax = (int)(ExpMax * 1.5);

            // Dá 5 pontos de status para distribuir
            PontosStatus += 5;

            // Aumenta Vida e Energia máximas ao subir de nível
            VidaMax += 10;
            EnergiaMax += 5;

            // Restaura Vida e Energia
            VidaAtual = VidaMax;
            EnergiaAtual = EnergiaMax;

            Console.WriteLine($"\n=== PARABÉNS! Você subiu para o Level {Level}! ===");
            Console.WriteLine($"Você ganhou 5 pontos de status para distribuir.");
            Console.WriteLine($"Vida e Energia restauradas.\n");
        }

        // =========================
        // DISTRIBUIÇÃO DE PONTOS DE STATUS
        // =========================
        public bool DistribuirPonto(string atributo)
        {
            if (PontosStatus <= 0)
            {
                Console.WriteLine("Você não possui pontos de status disponíveis.");
                return false;
            }

            switch (atributo)
            {
                case "Forca": Forca++; break;
                case "Destreza": Destreza++; break;
                case "Inteligencia": Inteligencia++; break;
                case "Sabedoria": Sabedoria++; break;
                case "Carisma": Carisma++; break;
                default:
                    Console.WriteLine("Atributo inválido.");
                    return false;
            }

            PontosStatus--;
            Console.WriteLine($"Ponto distribuído em {atributo}. Pontos restantes: {PontosStatus}");
            return true;
        }

        // =========================
        // BARRAS VISUAIS
        // =========================
        private string GerarBarra(int atual, int max, int tamanhoBarra, int corPreenchido, int corVazio)
        {
            if (max <= 0) return "";
            int preenchido = (int)Math.Round((double)atual / max * tamanhoBarra);
            preenchido = Math.Clamp(preenchido, 0, tamanhoBarra);
            int vazio = tamanhoBarra - preenchido;

            string parteCheia = new string('█', preenchido);
            string parteVazia = new string('░', vazio);

            if (corPreenchido > 0) parteCheia = $"\u001b[38;5;{corPreenchido}m{parteCheia}\u001b[0m";
            if (corVazio > 0) parteVazia = $"\u001b[38;5;{corVazio}m{parteVazia}\u001b[0m";

            return parteCheia + parteVazia;
        }

        private void MostrarAtributo(string nome, int valorAtual, int corPreenchido, int corVazio)
        {
            int tamanhoBarra = TamanhosBarras.ContainsKey(nome) ? TamanhosBarras[nome] : 20;
            int maxReferencia = Maximos.ContainsKey(nome) ? Maximos[nome] : Math.Max(valorAtual, 1);

            Console.WriteLine($"{nome}: {valorAtual}/{maxReferencia}");
            Console.WriteLine($"[{GerarBarra(valorAtual, maxReferencia, tamanhoBarra, corPreenchido, corVazio)}]\n");
        }

        // =========================
        // HUD
        // =========================
        public void MostrarStatusBarra()
        {
            string barraVida = GerarBarra(VidaAtual, Maximos["Vida"], TamanhosBarras["Vida"], 10, 1);
            string barraEnergia = GerarBarra(EnergiaAtual, Maximos["Energia"], TamanhosBarras["Energia"], 20, 4);
            string barraExp = GerarBarra(Exp, Maximos["Exp"], TamanhosBarras["Exp"], 226, 3);

            Console.WriteLine("==- Status -==\n");
            Console.Write($"[ {barraVida} HP {VidaAtual}/{Maximos["Vida"]} | ");
            Console.Write($"{barraEnergia} EN {EnergiaAtual}/{Maximos["Energia"]} | ");
            Console.Write($"{barraExp} ] EXP {Exp}/{Maximos["Exp"]} - ");
            Console.WriteLine($"LEVEL: \u001b[38;5;226m{Level}\u001b[0m\n");
            Console.WriteLine(new string('=', 60));
        }

        public void MostrarStatusAtributos()
        {
            Console.Clear();
            Console.WriteLine("==- Status & Atributos -==");

            // Status principais
            Console.WriteLine("\n==- Status -==\n");
            MostrarAtributo("Vida", VidaAtual, 10, 1);
            MostrarAtributo("Energia", EnergiaAtual, 20, 4);
            MostrarAtributo("Dano", Dano, 196, 8);
            MostrarAtributo("Level", Level, 226, 3);
            MostrarAtributo("Exp", Exp, 226, 8);

            // Atributos base
            Console.WriteLine("\n==- Atributos Base -==\n");
            MostrarAtributo("Força", Forca, 208, 8);
            MostrarAtributo("Destreza", Destreza, 39, 8);
            MostrarAtributo("Inteligencia", Inteligencia, 93, 8);
            MostrarAtributo("Sabedoria", Sabedoria, 141, 8);
            MostrarAtributo("Carisma", Carisma, 213, 8);

            // Atributos derivados
            Console.WriteLine("\n==- Atributos Derivados -==\n");
            MostrarAtributo("Percepcao", Percepcao, 45, 8);
            MostrarAtributo("Velocidade", Velocidade, 51, 8);

            // Pontos disponíveis
            Console.WriteLine($"\nPontos de status disponíveis: {PontosStatus}");
        }

        // =========================
        // CONFIGURAÇÃO DINÂMICA
        // =========================
        public void SetMaximo(string atributo, int max) => Maximos[atributo] = max;

        public void SetValor(string atributo, int valor)
        {
            switch (atributo)
            {
                case "Vida": VidaAtual = Math.Clamp(valor, 0, Maximos["Vida"]); break;
                case "Energia": EnergiaAtual = Math.Clamp(valor, 0, Maximos["Energia"]); break;
                case "Dano": Dano = Math.Max(valor, 0); break;
                case "Level": Level = Math.Max(valor, 0); break;
                case "Exp": Exp = Math.Clamp(valor, 0, Maximos["Exp"]); break;
                case "Força": Forca = Math.Clamp(valor, 0, Maximos["Forca"]); break;
                case "Destreza": Destreza = Math.Clamp(valor, 0, Maximos["Destreza"]); break;
                case "Inteligencia": Inteligencia = Math.Clamp(valor, 0, Maximos["Inteligencia"]); break;
                case "Sabedoria": Sabedoria = Math.Clamp(valor, 0, Maximos["Sabedoria"]); break;
                case "Carisma": Carisma = Math.Clamp(valor, 0, Maximos["Carisma"]); break;
            }
        }
    }
}