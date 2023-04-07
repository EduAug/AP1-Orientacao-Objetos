using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP1_Estacionamento
{
    public class Vaga
    {
        public int VagaNum { get;} 
        public Veiculo Estacionado {get; set;}
        public bool EstaUsada => Estacionado != null;
        // EstaUsada vai ser uma vaga que, se Estacionado não for null
        // Representa uma vaga ocupada, do contrário, se estiver null
        // Está livre
        
        public Vaga(int vagaNro){

            this.VagaNum = vagaNro;
        }

        public void Estacionar(Veiculo auto){

            if(EstaUsada){

                Console.WriteLine("Vaga já ocupada");
            }
            Estacionado = auto;
        }

        public void Esvaziar(){

            if(EstaUsada == false){

                Console.WriteLine("Vaga vazia");
            }
            Estacionado = null;
        }
    }
}