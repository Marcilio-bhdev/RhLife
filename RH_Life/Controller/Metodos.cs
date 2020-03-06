using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RH_Life.Entities.Enums;
using RH_Life.Entities;
using System.Globalization;

namespace RH_Life.Entities.Controller
{
   public class Metodos
    {
        Banco banco = new Banco();

        public void ListarFuncionario(Banco banco)
        {
            for (int i = 0; i < banco.listRh.Count; i++)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("|        Listar Funcionario       |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine($"Nome funcionario: {banco.listRh[i].nome}");
                Console.WriteLine($"Data de Nascimento: {banco.listRh[i].data_nasc}");
                Console.WriteLine($"CPF: {banco.listRh[i].cpf}");
                Console.WriteLine($"SEXO: {banco.listRh[i].sexo}");
                Console.WriteLine($"Nascinalidade: {banco.listRh[i].nacionalidade}");
                if (banco.listRh[i].status.ToString() == "Desligado")
                {
                    Console.WriteLine("Salario: 0");
                }
                else
                {
                    Console.WriteLine($"Salario: {banco.listRh[i].salario.ToString("F2", CultureInfo.InvariantCulture)}");
                }
                Console.WriteLine($"Cargo: {banco.listRh[i].cargo}");
                Console.WriteLine($"Status: {banco.listRh[i].status}");
                Console.WriteLine("===================================");
            }
        }
        public void ListaPorSexo(Banco banco)
        {
            double totalM = 0;
            double totalF = 0;
            Console.WriteLine("===================================");
            Console.WriteLine("| Listando Total Salário por sexo |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var sexF = banco.listRh.Where(x => x.sexo == 'F' || x.sexo == 'f');
            var sexM = banco.listRh.Where(x => x.sexo == 'M' || x.sexo == 'm');
            foreach (var item in sexF)
            {
                totalF += item.salario;
            }
            foreach (var item in sexM)
            {
                totalM += item.salario;
            }
            Console.WriteLine($" O Sexo Masculino da sua empresa recebe R$: {totalM.ToString("F2", CultureInfo.InvariantCulture)} e o Sexo Feminino da sua empresa recebe R$: {totalF.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public void ListarMaisVelho(Banco banco)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Mais Novo     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var maisVelho = banco.listRh.OrderBy(x => x.data_nasc).FirstOrDefault();
            Console.WriteLine($"Nome: {maisVelho.nome}");
            Console.WriteLine($"Data de Nascimento: {maisVelho.data_nasc}");
            Console.WriteLine("===================================");
        }

        public void ListarMaisNovo(Banco banco)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Mais Velho     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var maisNovo = banco.listRh.OrderByDescending(x => x.data_nasc).FirstOrDefault();
            Console.WriteLine($"Nome: {maisNovo.nome}");
            Console.WriteLine($"Data de Nascimento: {maisNovo.data_nasc}");
            Console.WriteLine("===================================");
        }

        public void ListarPorIdade(Banco banco)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|      Funcionario Por Idade     |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var idade = banco.listRh.OrderBy(x => x.data_nasc);
            foreach (var item in idade)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Nome: {item.nome}");
                Console.WriteLine($"Idade: {DateTime.Now.Year - item.data_nasc.Year} anos|");
                Console.WriteLine("===================================");
            }

        }

        public void ListarPorNascionalidade(Banco banco)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("|  Funcionario Por Nacionalidade  |");
            Console.WriteLine("===================================");
            Console.WriteLine();
            var nacao = banco.listRh.OrderBy(x => x.data_nasc);
            foreach (var item in nacao)
            {
                Console.WriteLine("===================================");
                Console.WriteLine($"Nome: {item.nome}");
                Console.WriteLine($"Nacionalidade: {item.nacionalidade}");
                Console.WriteLine("===================================");
            }

        }
        public bool ValidandoCpf(string CPF)
        {
            int multiplicador1 = 10;
            int multiplicador2 = 11;

            string temCPF;
            string digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;
            temCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(temCPF[i].ToString()) * (multiplicador1 - i);
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            temCPF = temCPF + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(temCPF[i].ToString()) * (multiplicador2 - i);
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }

        public bool ConfereCpfDuplicado(List<Funcionarios> listRh, string CPF)
        {
            for (int i = 0; i < listRh.Count; i++)
            {
                if (listRh[i].cpf == CPF)
                {
                    return true;
                }
            }
            return false;
        }

        public DateTime ValidandoDataNascimento(List<Funcionarios> listRh)
        {
            DateTime data_Nasc;
            var convertido = DateTime
             .TryParseExact(Console.ReadLine(),
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out data_Nasc);
            while ((convertido == false))
            {
                Console.WriteLine("Formato incorreto!!!");
                Console.Write("Favor insira data correta: ");
                convertido = DateTime
                .TryParseExact(Console.ReadLine(),
                               "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out data_Nasc);
            }
            if (data_Nasc > DateTime.Now)
            {
                Console.WriteLine("Data inválida!!!");
                Console.Write("Favor insira data correta: ");
                convertido = DateTime
                .TryParseExact(Console.ReadLine(),
                               "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out data_Nasc);
            }
            return data_Nasc;
        }
    }
}
