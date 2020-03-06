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

        public void AlteraSalario()
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

        public void ListarFuncionario()
        {
            for (int i = 0; i < listRh.Count; i++)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("|        Lista Funcionario        |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine($"Nome funcionario: {listRh[i].nome}");
                Console.WriteLine($"Data de Nascimento: {listRh[i].data_nasc}");
                Console.WriteLine($"CPF: {listRh[i].cpf}");
                Console.WriteLine($"SEXO: {listRh[i].sexo}");
                Console.WriteLine($"Nascinalidade: {listRh[i].nacionalidade}");
                if (listRh[i].status.ToString() == "Desligado")
                {
                    Console.WriteLine("Salario: 0");
                }
                else
                {
                    Console.WriteLine($"Salario: {listRh[i].salario.ToString("F2",CultureInfo.InvariantCulture)}");
                }
                Console.WriteLine($"Cargo: {listRh[i].cargo}");
                Console.WriteLine($"Status: {listRh[i].status}");
                Console.WriteLine("===================================");
            }
        }

        public void ListaPorSexo() 
        {
            double totalM = 0;
            double totalF = 0;
            Console.WriteLine("===================================");
            Console.WriteLine("| Listando Total Salário por sexo |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var sexF = listRh.Where(x => x.sexo == 'F' || x.sexo == 'f');
            var sexM = listRh.Where(x => x.sexo == 'M' || x.sexo == 'm');
            foreach (var item in sexF)
            {
                totalF += item.salario;
            } foreach (var item in sexM)
            {
                totalM += item.salario;
            }
            Console.WriteLine($" O Sexo Masculino da sua empresa recebe R$: {totalM.ToString("F2",CultureInfo.InvariantCulture)} e o Sexo Feminino da sua empresa recebe R$: {totalF.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public void ListarMaisVelho()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Mais Novo     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var maisVelho = listRh.OrderBy(x => x.data_nasc).FirstOrDefault();
            Console.WriteLine($"Nome: {maisVelho.nome}");
            Console.WriteLine($"Data de Nascimento: {maisVelho.data_nasc}");
            Console.WriteLine("===================================");
        }

        public void ListarMaisNovo()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Mais Velho     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var maisNovo = listRh.OrderByDescending(x => x.data_nasc).FirstOrDefault();
            Console.WriteLine($"Nome: {maisNovo.nome}");
            Console.WriteLine($"Data de Nascimento: {maisNovo.data_nasc}");
            Console.WriteLine("===================================");
        }

        public void ListarPorIdade()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Por Idade     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var idade = listRh.OrderBy(x => x.data_nasc);
            foreach (var item in idade)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Nome: {item.nome}");
                Console.WriteLine($"Idade: {DateTime.Now.Year - item.data_nasc.Year} anos|");
                Console.WriteLine("===================================");
            }
            
        }

        public void ListarPorNascionalidade()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|  Funcionario Por Nacionalidade  |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var nacao = listRh.OrderBy(x => x.data_nasc);
            foreach (var item in nacao)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Nome: {item.nome}");
                Console.WriteLine($"Nacionalidade: {item.nacionalidade}");
                Console.WriteLine("===================================");
            }

        }
    }
}
