using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Trabalho1.ClubeDaLeitura.ModuloCaixa
{
    internal class TelaCaixa
    {
        public CRUDCaixa controleCaixas = new CRUDCaixa();

        public TelaCaixa(){}

        public void CadastroAutomatico()
        {
            Caixa caixa = new Caixa("Vermelha", "Etiqueta 1", 100);
            controleCaixas.CadastrarCaixa(caixa);
            caixa = new Caixa("Verde", "Etiqueta 2", 200);
            controleCaixas.CadastrarCaixa(caixa);
            caixa = new Caixa("Azul", "Etiqueta 3", 300);
            controleCaixas.CadastrarCaixa(caixa);
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
            {
                controleCaixas.CadastrarCaixa();
                Console.ReadLine();
            }
            else if (x == 2)
            {
                controleCaixas.VisualizarCaixa();
                Console.ReadLine();
            }
            else if (x == 3)
            {
                controleCaixas.VisualizarCaixa();
                Console.WriteLine("Informe o id da caixa que quer editar:");
                int id = Convert.ToInt32(Console.ReadLine());
                controleCaixas.EditarCaixa(id);
                Console.ReadLine();
            }
            else if (x == 4)
            {
                controleCaixas.VisualizarCaixa();
                Console.WriteLine("Informe o id da caixa que quer remover:");
                int id = Convert.ToInt32(Console.ReadLine());
                controleCaixas.RemoverCaixa(id);
                Console.ReadLine();
            }
            Menu();
        }

    }
}
