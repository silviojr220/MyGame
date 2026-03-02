namespace Game.Interface;

class BarraDeProgresso
{
    public void BarraDeCarregamento()
    {
        int progresso = 0;
        int total = 100;

        Console.WriteLine("Iniciando carregamento...\n");

        // Loop while para simular o progresso
        while (progresso <= total)
        {
            // Calcula a porcentagem

            Console.Write("\r[");

            int barraCompleta = 20; // Tamanho total da barra em caracteres
            int carregado = (int)((double)progresso / total * barraCompleta);

            // Desenha a barra preenchida e vazia
            for (int i = 0; i < barraCompleta; i++)
            {
                if (i < carregado)
                {
                    Console.Write("\x1b[38;5;46m█\x1b[0m");
                }
                else
                {
                    Console.Write("\x1b[38;5;2m░\x1b[0m");

                }
            }

            // Exibe a porcentagem

            Console.Write($"] {progresso}%");

            // Atualiza o progresso
            progresso += 5;

            // Pausa de 100ms para simular trabalho
            Thread.Sleep(100);
        }
        Console.WriteLine("\n");
        Console.WriteLine("\nCarregamento concluído!\n");
    }

}