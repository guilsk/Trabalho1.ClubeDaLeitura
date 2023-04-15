using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloAmigo;
using Trabalho1.ClubeDaLeitura.ModuloCaixa;

namespace Trabalho1.ClubeDaLeitura.ModuloRevista
{
    internal class TelaRevista
    {
        public CRUDRevista controleRevista;
        CRUDCaixa listaCaixas;

        public TelaRevista(CRUDCaixa listaCaixas)
        {
            this.listaCaixas = listaCaixas;
            this.controleRevista = new CRUDRevista(this.listaCaixas);
        }

        public void CadastroAutomatico()
        {
            Revista r = new Revista("Turma da Mônica", 64, 2016, listaCaixas.SelecionarCaixaPorId(1));
            controleRevista.CadastrarRevista(r);
            r = new Revista("Saga do Infinito - MARVEL", 13, 2014, listaCaixas.SelecionarCaixaPorId(3));
            controleRevista.CadastrarRevista(r);
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Remover");
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
                controleRevista.CadastrarRevista();
            else if (x == 2)
            {
                controleRevista.VisualizarRevistas();
                Console.ReadLine();
            }
            else if (x == 3)
            {
                controleRevista.VisualizarRevistas();
                Console.WriteLine("Informe o id da revista que quer editar:");
                int id = Convert.ToInt32(Console.ReadLine());
                controleRevista.EditarRevista(id);
                Console.WriteLine("Caixa editada com sucesso!");
            }
            else if (x == 4)
            {
                controleRevista.VisualizarRevistas();
                Console.WriteLine("Informe o id da revista que quer remover:");
                int id = Convert.ToInt32(Console.ReadLine());
                controleRevista.RemoverRevista(id);
                Console.WriteLine("Caixa removida com sucesso!");
            }
            Menu();
        }
    }
}
