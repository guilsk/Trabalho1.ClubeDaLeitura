using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloCaixa;

namespace Trabalho1.ClubeDaLeitura.ModuloRevista
{
    internal class CRUDRevista
    {
        public int contadorRevistas = 1;
        public ArrayList listaRevistas = new ArrayList();
        public CRUDCaixa listaCaixas;

        public CRUDRevista(CRUDCaixa crudCaixa)
        {
            listaCaixas = crudCaixa;
        }

        public CRUDRevista(int contadorRevistas, ArrayList listaRevistas, CRUDCaixa listaCaixas)
        {
            this.contadorRevistas = contadorRevistas;
            this.listaRevistas = listaRevistas;
            this.listaCaixas = listaCaixas;
        }

        public void CadastrarRevista()
        {
            Revista revista = new Revista();
            revista.id = contadorRevistas;
            Console.WriteLine("Digite a coleção da revista:");
            revista.colecao = Console.ReadLine();
            Console.WriteLine("Digite o número de edição da revista:");
            revista.numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o ano da revista:");
            revista.ano = Convert.ToInt32(Console.ReadLine());

            listaCaixas.VisualizarCaixa();
            Console.WriteLine("Informe o id da caixa da revista:");
            int idCaixa = Convert.ToInt32(Console.ReadLine());
            revista.caixa = listaCaixas.SelecionarCaixaPorId(idCaixa);
            revista.caixa.temRevista = true;

            listaRevistas.Add(revista);
            contadorRevistas++;
            Console.WriteLine("Revista cadastrada com sucesso!");
        }

        public void CadastrarRevista(Revista revista)
        {
            revista.id = contadorRevistas;
            listaRevistas.Add(revista);
            revista.caixa.temRevista = true;
            contadorRevistas++;
        }

        public void VisualizarRevistas()
        {
            if (listaRevistas != null)
            {
                Console.WriteLine("ID | {0, -30} | Número de Edição | Ano de Lançamento | Caixa", "Coleção");
                foreach (Revista revista in listaRevistas)
                    Console.WriteLine($"{revista.id,-2} | {revista.colecao,-30} | {revista.numeroEdicao,-16} | {revista.ano,-17} | {revista.caixa.cor}");

            }
            else
            {
                Console.WriteLine("Nenhuma revista encontrada!");
            }
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            Revista r = null;
            foreach (Revista revista in listaRevistas)
                if (revista.id == id)
                    return revista;
            return r;
        }

        public void EditarRevista(int id)
        {
            Revista revista = SelecionarRevistaPorId(id);
            if (revista == null)
            {
                Console.WriteLine("ID inválido");
            }
            else
            {
                Console.WriteLine("Digite a nova coleção da revista:");
                revista.colecao = Console.ReadLine();
                Console.WriteLine("Digite o novo número de edição da revista:");
                revista.numeroEdicao = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite o novo ano da revista:");
                revista.ano = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe o id da caixa da revista:");
                listaCaixas.VisualizarCaixa();
                Console.Write("-> ");
                int idCaixa = Convert.ToInt32(Console.ReadLine());
                revista.caixa = listaCaixas.SelecionarCaixaPorId(idCaixa);
                Console.WriteLine(revista.caixa);
            }
        }

        public void RemoverRevista(int id)
        {
            if (listaRevistas.Count >= 1)
            {
                Revista revista = SelecionarRevistaPorId(id);
                if (revista != null)
                    listaRevistas.Remove(revista);
                else
                {
                    Console.WriteLine("Nenhuma revista com esse ID encontrada!");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma revista encontrada!");
                Thread.Sleep(1000);
            }
        }
    }
}
