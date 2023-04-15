using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloAmigo;
using Trabalho1.ClubeDaLeitura.ModuloRevista;

namespace Trabalho1.ClubeDaLeitura.ModuloEmprestimo
{
    internal class Emprestimo
    {
        public Amigo amigo;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public bool isOpen;
        public int id;

        public Emprestimo()
        {
        }

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao, bool isOpen)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.isOpen = isOpen;
        }

        public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao, bool isOpen, int id)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.isOpen = isOpen;
            this.id = id;
        }
    }
}
