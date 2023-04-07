using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP1_Estacionamento
{
    public class Carro : Veiculo{

        public Carro(string placa,string modelo,double tanque) 
            : base (placa,modelo,tanque){}

            // Apesar de não ser a melhor prática permitir que sejam
            // alterados placa e modelo
        public override void reSetPlaca(string newPlaca){

            this.Placa = newPlaca;
        }
        public override void reSetModelo(string newModelo){

            this.Modelo = newModelo;
        }
        public override double ValorEstacionamento(){
            // Se for um carro, há de pagar R$ 5,00 a hora
            return 5;
        }
    }
}