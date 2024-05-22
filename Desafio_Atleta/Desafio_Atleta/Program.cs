using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Desafio_Atleta {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("Qual a quantidade de atletas? ");
            int n = int.Parse(Console.ReadLine());

            string[] nomes = new string[n];
            string[] sexos = new string[n];
            double[] alturas = new double[n];
            double[] pesos = new double[n];

            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Digite os dados do atleta numero {i + 1}:");

                Console.Write("Nome: ");
                nomes[i] = Console.ReadLine();

                Console.Write("Sexo (F/M): ");
                sexos[i] = Console.ReadLine().ToUpper();
                while (sexos[i] != "F" && sexos[i] != "M") {
                    Console.Write("Valor invalido! Favor digitar F ou M: ");
                    sexos[i] = Console.ReadLine().ToUpper();
                }

                Console.Write("Altura: ");
                alturas[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                while (alturas[i] <= 0) {
                    Console.Write("Valor invalido! Favor digitar um valor positivo: ");
                    alturas[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                Console.Write("Peso: ");
                pesos[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                while (pesos[i] <= 0) {
                    Console.Write("Valor invalido! Favor digitar um valor positivo: ");
                    pesos[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }
            }

            
            double pesoMedio = 0;
            for (int i = 0; i < n; i++) {
                pesoMedio += pesos[i];
            }
            pesoMedio /= n;

            int indiceMaisAlto = 0;
            for (int i = 1; i < n; i++) {
                if (alturas[i] > alturas[indiceMaisAlto]) {
                    indiceMaisAlto = i;
                }
            }

       
            int totalHomens = 0;
            for (int i = 0; i < n; i++) {
                if (sexos[i] == "M") {
                    totalHomens++;
                }
            }
            double porcentagemHomens = ((double)totalHomens / n) * 100;

         
            int totalMulheres = 0;
            double alturaTotalMulheres = 0;
            for (int i = 0; i < n; i++) {
                if (sexos[i] == "F") {
                    totalMulheres++;
                    alturaTotalMulheres += alturas[i];
                }
            }

            Console.WriteLine("\nRELATÓRIO:");
            Console.WriteLine($"Peso médio dos atletas: {pesoMedio.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Atleta mais alto: {nomes[indiceMaisAlto]}");
            Console.WriteLine($"Porcentagem de homens: {porcentagemHomens.ToString("F1", CultureInfo.InvariantCulture)} %");

            if (totalMulheres > 0) {
                double alturaMediaMulheres = alturaTotalMulheres / totalMulheres;
                Console.WriteLine($"Altura média das mulheres: {alturaMediaMulheres.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            else {
                Console.WriteLine("Não há mulheres cadastradas");
            }


        }
    }
}
