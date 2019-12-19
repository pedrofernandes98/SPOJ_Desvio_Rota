using System;
using System.Collections;
using System.Collections.Generic;

namespace Desvio
{
    class Program
    {
        //Declaração de Variáveis Globais
        static int n, m, c, k;
        static int[,] grafo = new int[1010, 1010];
        static int[] custo = new int[1010];
        static int inf = 99999;
        static Queue<int> fila = new Queue<int>();

        //Algoritmo de Dijkstra
        static int dijkstra(int origem, int destino)
        {
            custo[origem] = 0;
            fila.Enqueue(origem);
            while(fila.Count != 0)
            {
                int i = fila.Dequeue();
                for(int j=0; j < n; j++)
                {
                    if(grafo[i,j] != inf && custo[j] > custo[i] + grafo[i,j])
                    {
                        custo[j] = custo[i] + grafo[i, j];
                        fila.Enqueue(j);
                    }
                }
            }

            return custo[destino];
        }


        static void Main(string[] args)
        {
            do
            {
                //Leitura de Dados de Entrada
                string entrada = Console.ReadLine();
                n = int.Parse(entrada.Split(' ')[0]);
                m = int.Parse(entrada.Split(' ')[1]);
                c = int.Parse(entrada.Split(' ')[2]);
                k = int.Parse(entrada.Split(' ')[3]);

                //Verifica se é fim de entrada
                if (n != 0 && m != 0 && c != 0 && k != 0)
                {


                    //Atribui Custo Infinito à todas as posições do Grafo
                    for (int i = 0; i <= n; i++)
                    {
                        custo[i] = inf;

                        for (int j = 0; j <= n; j++)
                        {
                            grafo[i, j] = inf;
                        }
                    }

                    //Percorre as estradas do país(arestas)
                    for (int i = 1; i <= m; i++)
                    {
                        //Leitura dos dados de Entrada que indicam as interligações entre cada cidade e o custo do Pedágio
                        int u, v, p;
                        string entradaAresta = Console.ReadLine();
                        u = int.Parse(entradaAresta.Split(' ')[0]);
                        v = int.Parse(entradaAresta.Split(' ')[1]);
                        p = int.Parse(entradaAresta.Split(' ')[2]);

                        //Tratamento da Restrição de obedecer a Rota de Serviço original
                        if (u >= c && v >= c)
                        {
                            grafo[u, v] = p;
                            grafo[v, u] = p;
                        }

                        if (u >= c && v < c)
                        {
                            grafo[u, v] = p;
                        }

                        if (u < c && v >= c)
                        {
                            grafo[v, u] = p;
                        }

                        if (u < c && v < c && Math.Abs(u - v) == 1)
                        {
                            grafo[u, v] = p;
                            grafo[v, u] = p;
                        }



                    }

                    //Envia os dados para o algorito de Dijkstra calcular o Custo Mínimo
                    int resultado = dijkstra(k, c - 1);
                    
                    //Impressão do Resultado na Tela
                    Console.WriteLine(resultado);
                }
            } while (n != 0 && m != 0 && c != 0 && k != 0);

            //Console.ReadKey();
        }
    }


}