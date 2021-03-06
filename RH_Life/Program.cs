﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RH_Life.Entities;
using RH_Life.Entities.Controller;
using RH_Life.Entities.Enums;


namespace RH_Life
{
    class Program
    {
        public static void Main(string[] args)
        {
            Banco banco = new Banco();
            Menu(banco);
            while (Console.ReadLine() != "10")
            {
                Menu(banco);
            }
            
        }
        public static void Menu(Banco banco)
        {
            Metodos metodos = new Metodos();
            int opcao = 0;
                Console.Clear();
                Console.WriteLine("|==========================================|");
                Console.WriteLine("|             Sistema RHLife               |");
                Console.WriteLine("|             Seja Bem vindo               |");
                Console.WriteLine("============================================");
                Console.WriteLine("|1 - Cadastrar Funcionario:                |");
                Console.WriteLine("|2 - Alterar Salário:                      |");
                Console.WriteLine("|3 - Desligar  Funcionario:                |");
                Console.WriteLine("|4 - Emitir Folha de pagamento:            |");
                Console.WriteLine("|5 - Lista de funcionarios cadasrtrados:   |");
                Console.WriteLine("|6 - Lita Total de salario por sexo:       |");
                Console.WriteLine("|7 - Buscar Funcionario mais Novo:         |");
                Console.WriteLine("|8 - Buscar Funcionario mais Velho:        |");
                Console.WriteLine("|9 - Buscar Funcionario por idade:         |");
                Console.WriteLine("|10- Buscar Funcionario por nacionalidade: |");
                Console.WriteLine("|11 -Sair                                  |");
                Console.WriteLine("============================================");
                Console.WriteLine();
                Console.Write("Entre Com uma das Opções: ");
                opcao = int.Parse(Console.ReadLine());
            while(opcao > 11)
            {
                Console.WriteLine("Favor digitar somente os itens do menu");
                Console.Write("Entre Com uma das Opções: ");
                opcao = int.Parse(Console.ReadLine());
            }
                switch (opcao)
                {
                    case 1:
                            Console.Clear();
                        banco.AddFuncionario();
                       break;
                    case 2:
                            Console.Clear();
                            banco.AlterarSalario();
                        break;
                    case 3:
                           Console.Clear();
                            banco.DesligarFuncionario();
                        break;
                    case 4:
                            Console.Clear();
                            banco.FolhaDePagamento();
                        break;
                    case 5:
                            Console.Clear();
                            metodos.ListarFuncionario(banco);
                        break;
                    case 6:
                            Console.Clear();
                            metodos.ListaPorSexo(banco);
                        break;
                    case 7:
                          Console.Clear();
                          metodos.ListarMaisVelho(banco);
                        break;
                    case 8:
                           Console.Clear();
                           metodos.ListarMaisNovo(banco);
                        break;
                    case 9:
                            Console.Clear();
                            metodos.ListarPorIdade(banco);
                        break;
                    case 10:
                           Console.Clear();
                            metodos.ListarPorNascionalidade(banco);
                        break;
                    default:
                           Environment.Exit(11);
                        break;
                }
        }
    }
}

