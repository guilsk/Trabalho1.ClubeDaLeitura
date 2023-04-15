using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloCaixa;

namespace Trabalho1.ClubeDaLeitura.ModuloRevista
{
    internal class Revista
    {
        public string colecao;
        public int numeroEdicao;
        public int ano;
        public Caixa caixa;
        public bool isFree = true;
        public int id;

        public Revista() { }

        public Revista(string colecao, int numeroEdicao, int ano, Caixa caixa)
        {
            this.colecao = colecao;
            this.numeroEdicao = numeroEdicao;
            this.ano = ano;
            this.caixa = caixa;
        }

        public Revista(string colecao, int numeroEdicao, int ano, Caixa caixa, int id)
        {
            this.colecao = colecao;
            this.numeroEdicao = numeroEdicao;
            this.ano = ano;
            this.caixa = caixa;
            this.id = id;
        }
    }
}
