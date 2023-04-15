using Trabalho1.ClubeDaLeitura.ModuloAmigo;
using Trabalho1.ClubeDaLeitura.ModuloCaixa;
using Trabalho1.ClubeDaLeitura.ModuloRevista;
using Trabalho1.ClubeDaLeitura.ModuloEmprestimo;
using System.Security.Cryptography.X509Certificates;

namespace Trabalho1.ClubeDaLeitura
{
    internal class Program
    {
        /*O que falta:
            Tela do Empréstimo
            Ajeitar Visualizar do Empréstimo
            Perguntar se é necessária a remoção uma de revista que utilize uma caixa caso a caixa seja removida
            Se sim, implementar a mesma operação para o Empréstimo envolvendo o amigo e a revista
            (Isso seria complicado pois acarretaria na exclusão do empréstimo se a caixa utilizada pela revista emprestada fosse removida)
            Fazer ajustes finais e se estiver com tempo tratamento de erro
            Por último parar de reclamar que é muito difícil, realmente ficou mais fácil de trabalhar a interface assim após todas as classes terem sido criadas
        */

        //Conferir se a caixa tem revista, se sim ele não pode excluir


        public static int MenuPrincipal(TelaCaixa tc, TelaRevista tr, TelaAmigo ta ,TelaEmprestimo te)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1 - Caixa");
            Console.WriteLine("2 - Revista");
            Console.WriteLine("3 - Amigo");
            Console.WriteLine("4 - Empréstimo");
            Console.WriteLine("Digite qualquer coisa para sair");
            Console.WriteLine("\nEscolha o que quer fazer:");
            string x = Console.ReadLine();
            if (x == "1") tc.Menu();
            else if (x == "2") tr.Menu();
            else if (x == "3") ta.Menu();
            else if (x == "4") te.Menu();
            else return 0;
            return 1;
        }

        static void Main(string[] args)
        {
            TelaCaixa tc = new TelaCaixa();
            TelaRevista tr = new TelaRevista(tc.controleCaixas);
            TelaAmigo ta = new TelaAmigo();
            TelaEmprestimo te = new TelaEmprestimo(tr.controleRevista, ta.controleAmigo);

            tc.CadastroAutomatico();
            tr.CadastroAutomatico();
            ta.CadastroAutomatico();
            te.CadastroAutomatico();
            int x = -1;
            while (x != 0)
            {
                x = MenuPrincipal(tc, tr, ta, te);
            }
            Console.WriteLine("Até mais!");
        }
    }
}