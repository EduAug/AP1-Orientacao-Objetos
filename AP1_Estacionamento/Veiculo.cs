using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP1_Estacionamento
{
    public abstract class Veiculo
    {
        public string Placa {get; protected set;}
        public string Modelo {get; protected set;}
        public double Combustivel {get;set;}

        public Veiculo(string placa, string modelo, double combustivel){

            this.Placa = placa;
            this.Modelo = modelo;
            this.Combustivel = combustivel;
        }

        // Método abstrato de valor para o veículo estacionado
        public abstract double ValorEstacionamento();

        // Métodos abstratos para que se possa atualizar placa e modelo
        // de fora das classes Moto e Carro, e Veiculo
        public abstract void reSetPlaca(string placa);

        public abstract void reSetModelo(string model);
    }
}