using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloAmigo;
using Trabalho1.ClubeDaLeitura.ModuloRevista;

namespace Trabalho1.ClubeDaLeitura.ModuloEmprestimo
{
    internal class TelaEmprestimo
    {
        ControleEmprestimo controleEmprestimo;
        CRUDRevista listaRevistas;
        CRUDAmigo listaAmigos;

        public TelaEmprestimo(CRUDRevista listaRevistas, CRUDAmigo listaAmigos)
        {
            this.listaRevistas = listaRevistas;
            this.listaAmigos = listaAmigos;
            this.controleEmprestimo = new ControleEmprestimo(this.listaAmigos, this.listaRevistas);
        }

        public void CadastroAutomatico()
        {
            DateTime dataDevolucao = Convert.ToDateTime("12/04/2025");
            Emprestimo emprestimo = new Emprestimo(listaAmigos.SelecionarAmigoPorId(2), listaRevistas.SelecionarRevistaPorId(1), DateTime.Now, dataDevolucao, true);
            emprestimo.revista.isFree = false;
            emprestimo.amigo.isFree = false;
            controleEmprestimo.RealizarEmprestimo(emprestimo);
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Histórico");
            Console.WriteLine("4 - Fechar Empréstimo");
            Console.WriteLine("\nSelecione a operação: ");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x != 0 && x != 1 && x != 2 && x != 3 && x != 4)
            {
                Console.WriteLine("Operação inválida!");
                Console.ReadLine();
                Menu();
            }
            if (x == 0)
            {
                return;
            }
            EscolherOperacao(x);
        }

        public void EscolherOperacao(int x)
        {
            Console.Clear();
            if (x == 1)
            {
                controleEmprestimo.RealizarEmprestimo();
                Console.ReadLine();
            }
            else if (x == 2)
            {
                controleEmprestimo.VisualizarEmprestimosAbertos();
                Console.ReadLine();
            }
            else if (x == 3)
            {
                controleEmprestimo.VisualizarHistoricoEmprestimo();
                Console.ReadLine();
            }
            else if (x == 4)
            {
                controleEmprestimo.VisualizarEmprestimosAbertos();
                Console.WriteLine("Informe o id do empréstimo que quer fechar:");
                int id = Convert.ToInt32(Console.ReadLine());
                controleEmprestimo.FecharEmprestimo(id);
            }
            Menu();
        }



    }
}
