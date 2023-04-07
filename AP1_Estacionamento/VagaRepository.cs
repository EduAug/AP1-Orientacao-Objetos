using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP1_Estacionamento
{
    public class VagaRepository
    {
        private List<Vaga> vagaRep;

        public VagaRepository(int qtd_vagas){
            
            vagaRep = new List<Vaga>(qtd_vagas);
            for (int i = 0; i < qtd_vagas; i++){

                vagaRep.Add(new Vaga(i+1));
            }
        }

        public List<Vaga> ListVagas(){

            return vagaRep;
        }

        public Vaga CheckVaga(int numVaga){

            return vagaRep.Find(a => a.VagaNum == numVaga);
        }

        public Vaga AcharDisponivel(){

            return vagaRep.Find(b => !b.EstaUsada);
        }

        public void Ocupar(Veiculo maq){

            var vagaOccupy = AcharDisponivel();
            if (vagaOccupy == null){

                Console.WriteLine("Todas as vagas estão ocupadas!");
            }else if(UnicidadePlaca(maq.Placa)){

                Console.WriteLine("Já existe um veículo estacionado com a placa "+maq.Placa);
                return;
            }else{

                vagaOccupy.Estacionar(maq);
            }
        }

        public void Ocupar(Veiculo maq, int nroVaga){

            var vagaOccupy = vagaRep.Find(c => c.VagaNum == nroVaga);
            if (vagaOccupy == null){

                Console.WriteLine("A vaga requisitada não existe");
                return;
            }
            if (UnicidadePlaca(maq.Placa)){

                Console.WriteLine("Já existe um veícul estacionado com a placa "+maq.Placa);
                return;
            }
            if (vagaOccupy.EstaUsada){

                Console.WriteLine("A vaga requisitada já está ocupada");
                return;
            }
            
            vagaOccupy.Estacionar(maq);
        }

        public void Desocupar(Veiculo maq, int minEstacionados){

            var vagaOccupy = vagaRep.Find(d => d.Estacionado == maq);
            if (vagaOccupy == null){

                Console.WriteLine("Não foi possível encontrar o veículo informado");
            }else{

                vagaOccupy.Esvaziar();
                Console.WriteLine("O valor total pelo uso do estacionamento é R$"+(maq.ValorEstacionamento()*(minEstacionados/60)));
            }
        }

        public bool UnicidadePlaca(string placa){

            return vagaRep.Any(e => e.Estacionado != null && e.Estacionado.Placa == placa);
        }
    }
}