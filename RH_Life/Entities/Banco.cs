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
            double Total = 0;
            double TotalComImposto = 0;
            for (int i = 0; i < listRh.Count; i++)
            {
                double percento = ((listRh[i].Salario * 0.55)+listRh[i].Salario);
                
                Console.WriteLine("===================================");
                Console.WriteLine("|        Folha de Pagamento       |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine($"Nome funcionario: {listRh[i].Nome}");
                Console.WriteLine($"Cargo Funcionario: {listRh[i].Cargo}");
                Console.WriteLine($"Salario sem imposto: {listRh[i].Salario.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Salario com imposto: {percento.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine("===================================");
                Total += listRh[i].Salario;
                TotalComImposto += listRh[i].Salario;
            }
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("|     Total com e sem imposto     |");
            Console.WriteLine("===================================");
            Console.WriteLine($"Total sem imposto: {Total.ToString("F2",CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Total com Imposto: {TotalComImposto.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine("===================================");

        }

        public void AlteraSalario()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|        Alterando Salario        |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.Write("Digitar o CPF do Empregado: ");
            string CPFAntigo = Console.ReadLine();
            var mudaSalario = listRh.FirstOrDefault(x => CPFAntigo == x.CPF);
            
            while (mudaSalario.Status != 0 || mudaSalario.Status == Status.Desligado)
            {
                Console.WriteLine("funcionários desligados não recebem salário!!! ");
                Console.Write("Digite outro CPF: ");
                CPFAntigo = Console.ReadLine();
                mudaSalario = listRh.FirstOrDefault(x => CPFAntigo == x.CPF);
            }
            Console.Write("Digita o novo cargo: ");
            mudaSalario.Cargo = Console.ReadLine();
            Console.Write("Altere o salario: ");
            mudaSalario.Salario = double.Parse(Console.ReadLine());
        }

        public void DesligarFuncionario() 
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|        Desligando Empregado     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.Write("Digitar o CPF do Empregado: ");
            string CPFAntigo = Console.ReadLine();
            var mudaStatus= listRh.FirstOrDefault(x => CPFAntigo == x.CPF);
            Status status = (Status)Enum.Parse(typeof(Status), "Desligado"); // Usei o conversor do tipo Status para String
            mudaStatus.Status = status;//atribui o Status do banco do status da funcção, 
            Console.WriteLine($"Funcionario {mudaStatus.Nome} foi desligado com sucesso ");
            
        }

        public void ListarFuncionario()
        {
            for (int i = 0; i < listRh.Count; i++)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("|        Lista Funcionario        |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine($"Nome funcionario: {listRh[i].Nome}");
                Console.WriteLine($"Data de Nascimento: {listRh[i].Data_Nasc}");
                Console.WriteLine($"CPF: {listRh[i].CPF}");
                Console.WriteLine($"SEXO: {listRh[i].Sexo}");
                Console.WriteLine($"Nascinalidade: {listRh[i].Nacionalidade}");
                Console.WriteLine($"Salario: {listRh[i].Salario}");
                Console.WriteLine($"Cargo: {listRh[i].Cargo}");
                Console.WriteLine($"Status: {listRh[i].Status}");
                Console.WriteLine("===================================");
            }
        }
        public void FuncioSexo() 
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|        Listando por sexo       |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var sex = listRh.OrderBy(x => x.Sexo);
            foreach (var item in sex)
            {
                Console.WriteLine("======================");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Salario: {item.Salario.ToString("F2",CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Sexo: {item.Sexo}");
                Console.WriteLine("======================");
            }
        }

        public void FuncMaisVelho()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Mais Novo     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var maisVelho = listRh.OrderBy(x => x.Data_Nasc).FirstOrDefault();
            Console.WriteLine($"Nome: {maisVelho.Nome}");
            Console.WriteLine($"Data de Nascimento: {maisVelho.Data_Nasc}");
            Console.WriteLine("===================================");
        }
        public void FuncMaisNovo()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Mais Velho     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var MaisNovo = listRh.OrderByDescending(x => x.Data_Nasc).FirstOrDefault();
            Console.WriteLine($"Nome: {MaisNovo.Nome}");
            Console.WriteLine($"Data de Nascimento: {MaisNovo.Data_Nasc}");
            Console.WriteLine("===================================");

        }
        public void FuncIdade()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Por Idade     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var idade = listRh.OrderBy(x => x.Data_Nasc);
            foreach (var item in idade)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Idade: {DateTime.Now.Year - item.Data_Nasc.Year} anos");
                Console.WriteLine("===================================");
            }
            
        }

        public void FuncNascionalidade()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|  Funcionario Por Nacionalidade  |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var nacao = listRh.OrderBy(x => x.Data_Nasc);
            foreach (var item in nacao)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Nacionalidade: {item.Nacionalidade}");
                Console.WriteLine("===================================");
            }

        }
    }
}
