using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP1_Estacionamento
{


    public class MotoRepository
    {
        
        public static List<Moto> listMotos;
        private VagaRepository vagaRepo;
        
        public MotoRepository(VagaRepository vagaRep){
            // Adição de VagaRepository e listMoto ao construtor para permitir 
            // que seja acessado os métdos de VagaRepository, em MotoRepository
            // assim, podemos alterar os estados da moto em ambas as listas
            listMotos = new List<Moto>();
            this.vagaRepo = vagaRep;
        }


        public List<Moto> ConferirTodasMotos(){
            // Um "read" de todas as motos, a princípio retorna uma "lista crua"
            // No program é feito um foreach, for, etc. para separar
            // Cada objeto em uma "linha de retorno"
            return listMotos;
        }


        public bool UnicidadePlaca(string placa){

            return listMotos.Any(a => a.Placa == placa);
        }

        public void CadastrarMoto(Moto novaMoto){

            if (UnicidadePlaca(novaMoto.Placa)){

                Console.WriteLine("Já existe uma moto com essa placa.");
                return;
            }
            listMotos.Add(novaMoto);
        
        }

        public Moto ConferirMoto(string placa){
            
            // Um "read" de apenas um objeto, baseado na Placa
            var ResultMoto = listMotos.Find(b => b.Placa == placa);
            if (ResultMoto == null){

                Console.WriteLine("Não existe moto de placa "+placa);
            }
            return ResultMoto;
        }

        // Não sei se é certo para que o estacionamento "edite"
        // A moto, uma vez que não é, por exemplo, uma mecânica,
        // Porém pode ocorrer da placa ter sido passada errada, 
        // Tanque com volume errado, modelo faltando letra, ...
        public void AtualizarMoto(string placa, string newPlaca, string newModelo, double newGas){

            // Apesar dos valores "Placa" sendo comparados, 
            // O 'FindIndex' vai ser um valor inteiro já que,
            // na lista, o índice não é uma string, e sim
            // um inteiro, logo, onde as strings forem iguais
            // pegar o valor inteiro do índice e atualizar lá
            int checkPlaca = listMotos.FindIndex(c => c.Placa == placa);

            // Reiterando minha lógica, não é possível atualizar
            // O modelo e a placa, uma vez que originalmente estes
            // Foram settados como private e protected
            if(checkPlaca == -1){
                // O retorno de -1 indica que não foi encontrado índice
                // onde Moto.Placa == placa, logo, não há moto com essa placa

                Console.WriteLine("Não foi encontrada moto de placa "+placa);
                return;
            }
            if(UnicidadePlaca(newPlaca)){

                Console.WriteLine("Já existe uma moto de placa "+placa+" no sistema");
                return;
            }
            // Para possibilitar tal atualização, placa e modelo
            // foram transformados em propriedades protected
            // e foram criados os métodos reSetPlaca e reSetModelo
            // em Veiculo, e herdados por Carro e Moto, permitindo que
            // recebam a placa e modelo aqui informados, e alterem
            // para o novo
            listMotos[checkPlaca].reSetPlaca(newPlaca);
            listMotos[checkPlaca].reSetModelo(newModelo);
            listMotos[checkPlaca].Combustivel = newGas;

            Console.WriteLine("Moto atualizada com sucesso");
            Console.WriteLine("Placa: "+newPlaca+" | Modelo: "+newModelo+" | Tanque: "+newGas+"L");
        }

        public void RemoverMoto(string placa, int minEstacionados){

            Moto bikeRemoval = null;

            foreach(Moto bikePlaca in listMotos){

                if(bikePlaca.Placa == placa){

                    bikeRemoval = bikePlaca;
                    break;
                }
            }
            if(bikeRemoval != null){

                listMotos.Remove(bikeRemoval);
                vagaRepo.Desocupar(bikeRemoval,minEstacionados);

                Console.WriteLine("Removido do sistema moto de placa "+placa);
            }
        }
    }
}