using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RH_Life.Entities;
using RH_Life.Entities.Enums;


namespace RH_Life
{
    class Program
    {
        public static void Main(string[] args)
        {
            Banco banco = new Banco();
            escolha(banco);
            while (Console.ReadLine() != "10")
            {
                escolha(banco);
            }
            
        }

        public static void escolha(Banco banco)
        {
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
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        banco.AddFuncionario();
                        break;
                    case 2:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.AlteraSalario();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 3:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.DesligarFuncionario();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 4:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.FolhaDePagamento();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 5:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.ListarFuncionario();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 6:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.TotalPorSexo();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 7:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.FuncMaisNovo();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 8:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.FuncMaisVelho();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 9:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.FuncIdade();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    case 10:
                        if (opcao == 1)
                        {
                            Console.Clear();
                            banco.FuncNascionalidade();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("===============================");
                            Console.WriteLine("|    Não seja espertinho      |");
                            Console.WriteLine("| Inicie o sistema na opção 1 |");
                            Console.WriteLine("===============================");
                        }
                        break;
                    default:
                        Environment.Exit(11);
                        break;
                }
        }
    }
}
