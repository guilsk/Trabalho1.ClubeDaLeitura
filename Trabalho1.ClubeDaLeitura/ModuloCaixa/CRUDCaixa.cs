using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1.ClubeDaLeitura.ModuloCaixa
{
    internal class CRUDCaixa
    {
        public int contadorCaixa = 1;
        public ArrayList listaCaixas = new ArrayList();

        public CRUDCaixa() { }

        public CRUDCaixa(int contadorCaixa, ArrayList listaCaixas)
        {
            this.contadorCaixa = contadorCaixa;
            this.listaCaixas = listaCaixas;
        }

        public void CadastrarCaixa()
        {
            Caixa caixa = new Caixa();
            caixa.id = contadorCaixa;
            Console.WriteLine("Digite a cor da Caixa: ");
            caixa.cor = Console.ReadLine();
            Console.WriteLine("Digite a etiqueta da Caixa: ");
            caixa.etiqueta = Console.ReadLine();
            Console.WriteLine("Digite o numero da Caixa: ");
            caixa.numero = Convert.ToInt32(Console.ReadLine());
            listaCaixas.Add(caixa);
            contadorCaixa++;
            Console.WriteLine("Caixa cadastrada com sucesso!");
        }

        public void CadastrarCaixa(Caixa caixa)
        {
            caixa.id = contadorCaixa;
            listaCaixas.Add(caixa);
            contadorCaixa++;
        }

        public void VisualizarCaixa()
        {
            if (listaCaixas != null)
            {
                Console.WriteLine("ID | {0, -15} | {1, -15} | Numero", "Cor", "Etiqueta");
                foreach (Caixa caixa in listaCaixas)
                {
                    Console.WriteLine($"{caixa.id, -2} | {caixa.cor, -15} | {caixa.etiqueta, -15} | {caixa.numero}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma caixa encontrada!");
            }
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            Caixa c = null;
            foreach (Caixa caixa in listaCaixas)
                if (caixa.id == id)
                    return caixa;
            return c;
        }

        public void EditarCaixa(int id)
        {
            Caixa caixa = SelecionarCaixaPorId(id);
            if (caixa == null)
            {
                Console.WriteLine("ID inválido");
            }
            else
            {
                Console.WriteLine("Digite a nova cor da Caixa: ");
                caixa.cor = Console.ReadLine();
                Console.WriteLine("Digite a nova etiqueta da Caixa: ");
                caixa.etiqueta = Console.ReadLine();
                Console.WriteLine("Digite o novo numero da Caixa: ");
                caixa.numero = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Caixa editada com sucesso!");
            }
        }

        public void RemoverCaixa(int id)
        {
            if (listaCaixas.Count >= 1)
            {
                Caixa caixa = SelecionarCaixaPorId(id);
                if (caixa != null)
                    if (caixa.temRevista == false)
                    {
                        listaCaixas.Remove(caixa);
                        Console.WriteLine("Caixa removida com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Você não pode excluir essa caixa!");
                    }
                else
                {
                    Console.WriteLine("Nenhuma caixa com esse ID encontrada!");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma caixa encontrada!");
            }
        }

    }
}
