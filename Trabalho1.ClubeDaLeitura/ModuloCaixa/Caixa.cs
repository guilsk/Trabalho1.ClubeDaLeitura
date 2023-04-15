using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1.ClubeDaLeitura.ModuloCaixa
{
    internal class Caixa
    {
        public string cor;
        public string etiqueta;
        public int numero;
        public bool temRevista = false;
        public int id;

        public Caixa() { }

        public Caixa(string cor, string etiqueta, int numero)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
        }

        public Caixa(string cor, string etiqueta, int numero, int id)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
            this.id = id;
        }

    }
}
