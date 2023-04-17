using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloAmigo;
using Trabalho1.ClubeDaLeitura.ModuloRevista;

namespace Trabalho1.ClubeDaLeitura.ModuloEmprestimo
{
    internal class ControleEmprestimo
    {
        int contadorEmprestimos = 1;
        ArrayList listaEmprestimos = new ArrayList();
        CRUDAmigo listaAmigos;
        CRUDRevista listaRevista;
        ArrayList historicoEmprestimos = new ArrayList();

        public ControleEmprestimo(CRUDAmigo listaAmigos, CRUDRevista listaRevista)
        {
            this.listaAmigos = listaAmigos;
            this.listaRevista = listaRevista;
        }

        public ControleEmprestimo(int contadorEmprestimos, ArrayList listaEmprestimos, CRUDAmigo listaAmigos, CRUDRevista listaRevista, ArrayList historicoEmprestimos)
        {
            this.contadorEmprestimos = contadorEmprestimos;
            this.listaEmprestimos = listaEmprestimos;
            this.listaAmigos = listaAmigos;
            this.listaRevista = listaRevista;
            this.historicoEmprestimos = historicoEmprestimos;
        }

        public void RealizarEmprestimo()
        {
            Emprestimo emprestimo = new Emprestimo();

            emprestimo.id = contadorEmprestimos;

            listaAmigos.VisualizarAmigo();
            Console.WriteLine("Informe o id do amigo:");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            emprestimo.amigo = listaAmigos.SelecionarAmigoPorId(idAmigo);
            while (!emprestimo.amigo.isFree)
            {
                Console.WriteLine("Este amigo já está com uma revista!");
                listaAmigos.VisualizarAmigo();
                Console.WriteLine("Informe o id de outro amigo:");
                idAmigo = Convert.ToInt32(Console.ReadLine());
                emprestimo.amigo = listaAmigos.SelecionarAmigoPorId(idAmigo);
            }
            emprestimo.amigo.isFree = false;

            Console.WriteLine();
            listaRevista.VisualizarRevistas();
            Console.WriteLine("Informe o id da revista:");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            emprestimo.revista = listaRevista.SelecionarRevistaPorId(idRevista);
            while (!emprestimo.revista.isFree)
            {
                Console.WriteLine("Esta revista já está com um amigo!");
                listaRevista.VisualizarRevistas();
                Console.WriteLine("Informe o id da revista:");
                idRevista = Convert.ToInt32(Console.ReadLine());
                emprestimo.revista = listaRevista.SelecionarRevistaPorId(idRevista);
            }
            emprestimo.revista.isFree = false;

            emprestimo.dataEmprestimo = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("Digite a data de devolução:");
            string dataDevolucao = Console.ReadLine();
            DateTime date = DateTime.Parse(dataDevolucao);
            emprestimo.dataDevolucao = date;

            emprestimo.isOpen = true;
            listaEmprestimos.Add(emprestimo);
            historicoEmprestimos.Add(emprestimo);
            contadorEmprestimos++;
            Console.WriteLine("Empréstimo realizado!");
        }

        public void RealizarEmprestimo(Emprestimo e)
        {
            e.id = contadorEmprestimos;
            listaEmprestimos.Add(e);
            historicoEmprestimos.Add(e);
            contadorEmprestimos++;
        }

        public void VisualizarEmprestimosAbertos()
        {
            if (listaEmprestimos != null)
            {
                Console.WriteLine("ID | {0, -20} | {1, -30} | Data de Emprestimo | Data de Devolução", "Amigo", "Revista");
                foreach (Emprestimo e in listaEmprestimos)
                {
                    if (e.isOpen)
                    {
                        var de = string.Format("{0:dd/MM/yyyy}", e.dataEmprestimo);
                        var dd = string.Format("{0:dd/MM/yyyy}", e.dataDevolucao);
                        Console.WriteLine($"{e.id, -2} | {e.amigo.nome, -20} | {e.revista.colecao, -30} | {de, -18} | {dd}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhuma empréstimo encontrado!");
            }
        }

        public void VisualizarHistoricoEmprestimo()
        {
            if (historicoEmprestimos != null)
            {
                Console.WriteLine("ID | {0, -20} | {1, -30} | Data de Emprestimo | Data de Devolução | Situação", "Amigo", "Revista");
                foreach (Emprestimo e in historicoEmprestimos)
                {
                    string situacao;
                    var de = string.Format("{0:dd/MM/yyyy}", e.dataEmprestimo);
                    var dd = string.Format("{0:dd/MM/yyyy}", e.dataDevolucao);
                    if (e.isOpen)
                        situacao = "Aberto";
                    else
                        situacao = "Fechado";
                    Console.WriteLine($"{e.id, -2} | {e.amigo.nome, -20} | {e.revista.colecao, -30} | {de, -18} | {dd, -17} | {situacao}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum empréstimo encontrado!");
                Thread.Sleep(1000);
            }
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            Emprestimo e = null;
            foreach (Emprestimo emprestimo in listaEmprestimos)
                if (emprestimo.id == id)
                    return emprestimo;
            return e;
        }

        public void FecharEmprestimo(int id)
        {
            foreach (Emprestimo e in listaEmprestimos)
            {
                if (e.id == id)
                {
                    e.isOpen = false;
                    e.amigo.isFree = true;
                    e.revista.isFree = true;
                    e.revista.caixa.temRevista = false;
                }
                    
            }
        }

    }
}
