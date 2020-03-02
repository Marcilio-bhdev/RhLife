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
            while (Console.ReadLine() != "5")
            {
                escolha(banco);
            }

        }

        public static void escolha(Banco banco)
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("     Sistema RHLife       ");
            Console.WriteLine("     Seja Bem vindo       ");
            Console.WriteLine("===========================");
            Console.WriteLine("1 - Cadastrar Funcionario:");
            Console.WriteLine("2 - Alterar Salário: ");
            Console.WriteLine("3 - Desligar  Funcionario  ");
            Console.WriteLine("4 - Emitir Folha de pagamento");
            Console.WriteLine("5 - Sair");
            Console.Write("Entre Com uma das Opções: ");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    banco.AddFuncionario();
                    break;
                case 2:
                    banco.AlteraSalario();
                    
                    break;
                case 3:
                    banco.DesligarFuncionario();
                    
                    break;
                case 4:
                    banco.FolhaDePagamento();
                    
                    break;
                default:
                    Environment.Exit(5);
                    break;
            }
        }
    }
}
