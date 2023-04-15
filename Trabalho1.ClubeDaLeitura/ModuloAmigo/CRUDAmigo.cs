using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho1.ClubeDaLeitura.ModuloCaixa;

namespace Trabalho1.ClubeDaLeitura.ModuloAmigo
{
    internal class CRUDAmigo
    {
        public int contadorAmigo = 1;
        public ArrayList listaAmigos = new ArrayList();

        public CRUDAmigo() { }

        public CRUDAmigo(int contadorAmigo, ArrayList listaAmigo)
        {
            this.contadorAmigo = contadorAmigo;
            listaAmigos = listaAmigo;
        }

        public void CadastrarAmigo()
        {
            Amigo amigo = new Amigo();
            amigo.id = contadorAmigo;
            Console.WriteLine("Digite o nome do amigo:");
            amigo.nome = Console.ReadLine();
            Console.WriteLine("Digite o nome do responsável:");
            amigo.nomeResponsavel = Console.ReadLine();
            Console.WriteLine("Digite o telefone do amigo:");
            amigo.telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereço do amigo:");
            amigo.endereco = Console.ReadLine();
            listaAmigos.Add(amigo);
            contadorAmigo++;
            Console.WriteLine("Amigo adquirido com sucesso!");
        }

        public void CadastrarAmigo(Amigo amigo)
        {
            amigo.id = contadorAmigo;
            listaAmigos.Add(amigo);
            contadorAmigo++;
        }

        public void VisualizarAmigo()
        {
            if (listaAmigos != null)
            {
                Console.WriteLine("Id | {0, -20} | {1, -20} | {2, -15} | Endereço", "Nome", "Nome do Responsável", "Telefone");
                Console.WriteLine("------------------------------------------------------------------------------------------");
                foreach (Amigo amigo in listaAmigos)
                {
                    Console.WriteLine($"{amigo.id, -2} | {amigo.nome, -20} | {amigo.nomeResponsavel, -20} | {amigo.telefone} | {amigo.endereco}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum amigo encontrado!");
            }
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            Amigo a = null;
            foreach (Amigo amigo in listaAmigos)
                if (amigo.id == id)
                    return amigo;
            return a;
        }

        public void EditarAmigo(int id)
        {
            Amigo amigo = SelecionarAmigoPorId(id);
            if (amigo == null)
            {
                Console.WriteLine("ID inválido");
            }
            else
            {
                Console.WriteLine("Digite o novo nome do amigo:");
                amigo.nome = Console.ReadLine();
                Console.WriteLine("Digite o novo nome do responsável:");
                amigo.nomeResponsavel = Console.ReadLine();
                Console.WriteLine("Digite o novo telefone do amigo:");
                amigo.telefone = Console.ReadLine();
                Console.WriteLine("Digite o novo endereço do amigo:");
                amigo.endereco = Console.ReadLine();
                Console.WriteLine("Amigo editado com sucesso!");
            }
        }

        public void RemoverAmigo(int id)
        {
            if (listaAmigos.Count >= 1)
            {
                Amigo amigo = SelecionarAmigoPorId(id);
                // if (caixa.temRevista == false) listaCaixas.RemoveAt(id - 1);
                //else Console.WriteLine("Você não pode excluir essa caixa!");
                if (amigo != null)
                    if (amigo.isFree == true)
                    {
                        listaAmigos.Remove(amigo);
                        Console.WriteLine("Amigo perdido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Você não pode desfazer essa amizade!\nEle ainda não te devolveu a revista >:(");
                    }
                else
                    Console.WriteLine("Nenhum amigo com esse ID encontrado!");
            }
            else
            {
                Console.WriteLine("Nenhum amigo encontrado!");
            }

        }

    }

}
