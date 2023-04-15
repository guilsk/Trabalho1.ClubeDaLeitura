using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloCaixa;

namespace Trabalho1.ClubeDaLeitura.ModuloAmigo
{
    internal class TelaAmigo
    {
        public CRUDAmigo controleAmigo = new CRUDAmigo();

        public TelaAmigo(){}

        public void CadastroAutomatico()
        { 
            Amigo amigo = new Amigo("Jorel", "Pai do Joãozinho", "(49)9.9999-9999", "Rua do Joãozinho");
            controleAmigo.CadastrarAmigo(amigo);
            amigo = new Amigo("Pedrinho", "Pai do Pedrinho", "(48)8.8888-8888", "Rua do Pedrinho");
            controleAmigo.CadastrarAmigo(amigo);
            amigo = new Amigo("Irmão do Joãozinho", "Pai do Joãozinho", "(49)9.9999-9999", "Rua do Joãozinho");
            controleAmigo.CadastrarAmigo(amigo);
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
                return;
            
            EscolherOperacao(x);
        }
        public void EscolherOperacao(int x)
        {
            Console.Clear();
            if (x == 1)
            {
                controleAmigo.CadastrarAmigo();
                Console.ReadLine();
            }
            else if (x == 2)
            {
                controleAmigo.VisualizarAmigo();
                Console.ReadLine();
            }
            else if (x == 3)
            {
                controleAmigo.VisualizarAmigo();
                Console.WriteLine("Informe o id do amigo que quer editar:");
                int id = Convert.ToInt32(Console.ReadLine());
                controleAmigo.EditarAmigo(id);
                Console.ReadLine();
            }
            else if (x == 4)
            {
                controleAmigo.VisualizarAmigo();
                Console.WriteLine("Informe o id do amigo que desfazer a amizade:");
                int id = Convert.ToInt32(Console.ReadLine());
                controleAmigo.RemoverAmigo(id);
                Console.ReadLine();
            }
            Menu();
        }
    }
}
