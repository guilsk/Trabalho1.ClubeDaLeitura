using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1.ClubeDaLeitura.ModuloAmigo
{
    internal class Amigo
    {
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public bool isFree = true;
        public int id;

        public Amigo()
        {
        }

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco, int id)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
            this.id = id;
        }
    }
}
