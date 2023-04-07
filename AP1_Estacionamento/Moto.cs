using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP1_Estacionamento
{
    public class Moto : Veiculo{

        public Moto(string placa, string modelo, double tanque)
            : base(placa,modelo,tanque){}
            // Atualizar a placa e modelo das motos, caso ocorra algum erro
        public override void reSetPlaca(string newPlaca){

            this.Placa = newPlaca;
        }
        public override void reSetModelo(string newModelo){

            this.Modelo = newModelo;
        }
        public override double ValorEstacionamento(){
            // Se for uma moto, R$ 3,00 a hora
            return 3;
        }
    }
}