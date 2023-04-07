using AP1_Estacionamento;

VagaRepository VagaRepo = new VagaRepository(6);
CarroRepository CarRepo = new CarroRepository(VagaRepo);
MotoRepository BikRepo = new MotoRepository(VagaRepo);

Carro Car1 = new Carro("UDT123","Mod1",17);
Carro Car2 = new Carro("QCS456","Mod2",8);
Carro Car3 = new Carro("SON789","Mod3",5);
Moto Bike1 = new Moto("JAE941","SMod",9);
Moto Bike2 = new Moto("UDT123","ZMod",6);

CarRepo.CadastrarCarro(Car1);
CarRepo.CadastrarCarro(Car2);
CarRepo.CadastrarCarro(Car3);
BikRepo.CadastrarMoto(Bike1);
BikRepo.CadastrarMoto(Bike2);
foreach (Carro car in CarRepo.ConferirTodosCarros()){

    Console.WriteLine("Carro "+car.Placa+" Modelo "+car.Modelo+" Tanque "+car.Combustivel);
}
foreach (Moto bike in BikRepo.ConferirTodasMotos()){

    Console.WriteLine("Moto "+bike.Placa+" Modelo "+bike.Modelo+" Tanque "+bike.Combustivel);
}

VagaRepo.Ocupar(Car1);
VagaRepo.Ocupar(Car2,4);
VagaRepo.Ocupar(Car3);
VagaRepo.Ocupar(Bike1,6);
VagaRepo.Ocupar(Bike2);
foreach (Vaga vei in VagaRepo.ListVagas()){
    
    if(vei.EstaUsada){

        Console.WriteLine("Vaga "+vei.VagaNum+": "+vei.Estacionado.GetType().Name+" | "+vei.Estacionado.Modelo+" | "+vei.Estacionado.Placa);
    }
}

var checarCarroIndividual = CarRepo.ConferirCarro("UDT123");
if (checarCarroIndividual != null){
    Console.WriteLine("Carro encontrado");
    Console.WriteLine("Placa: "+checarCarroIndividual.Placa+" | Modelo: "+checarCarroIndividual.Modelo+" | Tanque: "+checarCarroIndividual.Combustivel);
}
checarCarroIndividual = null;

checarCarroIndividual = CarRepo.ConferirCarro("DOD012");
if (checarCarroIndividual != null){
    Console.WriteLine("Carro encontrado");
    Console.WriteLine("Placa: "+checarCarroIndividual.Placa+" | Modelo: "+checarCarroIndividual.Modelo+" | Tanque: "+checarCarroIndividual.Combustivel);
}
checarCarroIndividual = null;
var checarMotoIndividual = BikRepo.ConferirMoto("JAE941");
if (checarMotoIndividual != null){
    Console.WriteLine("Moto encontrada");
    Console.WriteLine("Placa: "+checarMotoIndividual.Placa+" | Modelo: "+checarMotoIndividual.Modelo+" | Tanque: "+checarMotoIndividual.Combustivel);
}
checarMotoIndividual = null;

CarRepo.AtualizarCarro("BOB518","BIB181","18",81);
BikRepo.AtualizarMoto("JAE941","BIB181","18",81);
CarRepo.ConferirCarro("TQQ345");

CarRepo.RemoverCarro("TQQ345", 30);
CarRepo.RemoverCarro("DOD012", 180);
BikRepo.RemoverMoto("UDT123", 60);
foreach (Carro car in CarRepo.ConferirTodosCarros()){

    Console.WriteLine("Carro "+car.Placa+" Modelo "+car.Modelo+" Tanque "+car.Combustivel);
}
foreach (Moto bike in BikRepo.ConferirTodasMotos()){

    Console.WriteLine("Moto "+bike.Placa+" Modelo "+bike.Modelo+" Tanque "+bike.Combustivel);
}


foreach (Vaga vei in VagaRepo.ListVagas()){
    
    if(vei.EstaUsada){

        Console.WriteLine("Vaga "+vei.VagaNum+": "+vei.Estacionado.GetType().Name+" | "+vei.Estacionado.Modelo+" | "+vei.Estacionado.Placa);
    }
}