using System;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace LerLinhas
{
    class Program
    {
        static void Main(string[] args)
        {

            //variáveis 
            int contador = -1;
            int contadorxslx = -1;
            string ndiretorio = @"C:\Users\jonathan.hora\Desktop\pasta";
            DirectoryInfo diretorio = new DirectoryInfo(ndiretorio);
            FileInfo[] arquivo = diretorio.GetFiles("*.txt");
            FileInfo[] xslx = diretorio.GetFiles("*.xlsx");
            int quantixslx = xslx.Length;
            int quantidade = arquivo.Length;
            string[] nome = new string[quantidade];
            string[] nomexslx = new string[quantixslx];
            int[] ncont = new int[quantidade];
            int[] ncontxslx = new int[quantixslx];
            int total = 0;
            int totalxslx = 0;
            int i= 0;


            if (quantidade > 0)
            {
                try
                {
                    //pegando o nome do arquivo e alocando no array nome
                    foreach (FileInfo fileInfo in arquivo)
                    {

                        nome[i] = Path.GetFileName(Convert.ToString(arquivo[i]));
                        //Console.WriteLine(nome[i]);
                        i++;

                    }


                    //contando o número de linhas por arquivo 
                    for (int j = 0; j < quantidade; j++)
                    {
                        TextReader Ler = new StreamReader(ndiretorio + nome[j], true);
                        //contando o número de linhas 
                        while (Ler.Peek() != -1)
                        {
                            contador++;

                            Ler.ReadLine();
                        }

                        Console.WriteLine(nome[j] + ";" + contador);
                        ncont[j] = contador;
                        total = total + ncont[j];
                        contador = -1;

                        Ler.Close();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
                finally
                {
                    Console.WriteLine(quantidade+" Arquivos .txt Localizados");
                }
            }
            else
            {
                Console.WriteLine("Arquivos .txt não localizados");
            }

            //criando o arquivo
            StreamWriter saida;
            String caminho = @"C:\Users\jonathan.hora\Desktop\pasta\retorno\retorno.csv";

            saida = File.CreateText(caminho);


            //escrevendo no arquivo
            if (quantidade > 0)
            {
                try
                {
                    saida.WriteLine("arquivo;quatidade");

                    for (int a = 0; a < quantidade; a++)

                    {
                        saida.WriteLine(nome[a] + ";" + ncont[a]);
                    }

                    saida.WriteLine("total;" + total);

                    saida.WriteLine();
                    saida.WriteLine();

                    saida.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Arquivos .txt carregados com sucesso");
                }
            }
            else
            {
                Console.WriteLine("Não é possível carregar os arquivos .txt");
            }

            System.Console.ReadLine();
    

           
           
        }
    }
}
