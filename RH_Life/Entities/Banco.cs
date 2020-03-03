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
            for (int i = 0; i < listRh.Count; i++)
            {
                double percento = (listRh[i].Salario * 55)/100;
                double rendimento = listRh[i].Salario * 12;
                Console.WriteLine("===================================");
                Console.WriteLine("|        Folha de Pagamento       |");
                Console.WriteLine("===================================");
                Console.WriteLine();
                Console.WriteLine($"Nome funcionario: {listRh[i].Nome}");
                Console.WriteLine($"Cargo Funcionario: {listRh[i].Cargo}");
                Console.WriteLine($"Salario unitario  {listRh[i].Salario.ToString("F2", CultureInfo.InvariantCulture)} Rendimento anual sem imposto: {rendimento.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Salario unitario {listRh[i].Salario.ToString("F2", CultureInfo.InvariantCulture)} Rendimento anual com imoposto {(rendimento.ToString("F2", CultureInfo.InvariantCulture) + percento)}");
                Console.WriteLine("===================================");
            } 
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
            Console.WriteLine("Digitar o CPF do Empregado: ");
            string CPFAntigo = Console.ReadLine();
            var mudaStatus= listRh.FirstOrDefault(x => CPFAntigo == x.CPF);
            Status status = (Status)Enum.Parse(typeof(Status), "2"); // Usei o conversor do tipo Status para String
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
                Console.WriteLine("===============");
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Salario);
                Console.WriteLine(item.Sexo);
                Console.WriteLine("===============");
            }
        }

        public void FuncMaisVelho()
        {
        
        }
        public void FuncMaisNovo()
        {

        }
        public void FuncIdade()
        {

        }

        public void FuncNascionalidade()
        {

        }
    }
}
