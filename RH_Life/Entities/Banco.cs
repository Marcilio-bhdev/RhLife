using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using RH_Life.Entities.Enums;

namespace RH_Life.Entities
{
    public class Banco
    {
        public List<Funcionarios> listRh = new List<Funcionarios>();
        public void AddFuncionario() 
        {
            listRh.Add(new Funcionarios(listRh));
        }

        public void FolhaDePagamento()
        {
            double total = 0;
            double totalComImposto = 0;
            for (int i = 0; i < listRh.Count; i++)
            {
                double percento = ((listRh[i].salario * 0.55)+listRh[i].salario);
                Console.WriteLine("===================================");
                Console.WriteLine("|        Folha de Pagamento       |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine($"Nome funcionario: {listRh[i].nome}");
                Console.WriteLine($"Cargo Funcionario: {listRh[i].cargo}");
                Console.WriteLine($"Salario sem imposto: {listRh[i].salario.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Salario com imposto: {percento.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine("===================================");
                total += listRh[i].salario;
                totalComImposto += percento;
            }
            Console.WriteLine();
            Console.WriteLine("=========================================");
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("|     Total com e sem imposto     |");
            Console.WriteLine("===================================");
            Console.WriteLine($"Total sem imposto: {total.ToString("F2",CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Total com Imposto: {totalComImposto.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine("===================================");

        }

        public void AlterarSalario()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|        Alterando Salario        |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.Write("Digitar o CPF do Empregado: ");
            string CPFAntigo = Console.ReadLine();
            var mudaSalario = listRh.FirstOrDefault(x => CPFAntigo == x.cpf);
            while (mudaSalario.status != 0 || mudaSalario.status == Status.Desligado)
            {
                Console.WriteLine("funcionários desligados não recebem alteração de salário!!! ");
                Console.Write("Digite outro CPF: ");
                CPFAntigo = Console.ReadLine();
                mudaSalario = listRh.FirstOrDefault(x => CPFAntigo == x.cpf);
            }
            Console.Write("Digita o novo cargo: ");
            mudaSalario.cargo = Console.ReadLine();
            Console.Write("Altere o salario: ");
            mudaSalario.salario = double.Parse(Console.ReadLine());
        }

        public void DesligarFuncionario() 
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|        Desligando Empregado     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.Write("Digitar o CPF do Empregado: ");
            string cpfAntigo = Console.ReadLine();
            var mudaStatus= listRh.FirstOrDefault(x => cpfAntigo == x.cpf);
            Status status = (Status)Enum.Parse(typeof(Status), "Desligado"); // Usei o conversor do tipo Status para String
            mudaStatus.status = status;//atribui o Status do banco do status da funcção, 
            Console.WriteLine($"Funcionario {mudaStatus.nome} foi desligado com sucesso ");
            
        }
    }
}
