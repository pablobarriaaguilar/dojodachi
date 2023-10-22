public class Pet{
    public int Felicidad { get; set;}
    public int Saciedad { get; set; }
    public int Energia { get; set; }
    public int Comida { get; set; }

    public Pet (){

        Felicidad = 20;
        Saciedad = 20;
        Energia = 50;
        Comida = 3;

    }
    public int probabilidad(){
        Random rnd = new Random();
        int num = rnd.Next(1,5);
        return num;
    }

    public string Alimentar( Pet _pet){

        if(probabilidad() == 1 ){
            _pet.Comida = _pet.Comida - 1;
            return "tu mascota no quiso comer, pierdes 1 comida!";

        }else{
            _pet.Comida = _pet.Comida - 1;
            Random rnd = new Random();
            int rand = rnd.Next(5,10);
            _pet.Saciedad = _pet.Saciedad+ rand;
            return "tu mascota a comido, su saciedad aumento!";
        }
        
        
    }

    public string Jugar(){
         if(probabilidad() == 1 ){
        Energia = Energia -5;
        return "tu mascota no quizo jugar , perdio energia!";
         }else{
        Random rnd = new Random();
        int rand = rnd.Next(5,10);
        Energia = Energia - 5;
        Felicidad = Felicidad + rand;
        return "tu mascota jugo contigo y aumento su felicidad, disminuyo su energia";
         }
       
    }

    public string Trabajar(){
        Random rnd = new Random();
        int rand = rnd.Next(1,3);
        Energia = Energia - 5; 
        Comida = Comida + rand;
        return "Tu mascota fue a trabajar y gano comida!";
    }

    public string Dormir (){
        Energia = Energia + 15;
        Saciedad = Saciedad - 5;
        Felicidad = Felicidad - 5;
        return "Tu mascota se puso a dormir y descanso!";
    }

    public String ComprobarGanar( Pet _pet){
        if (_pet.Felicidad >= 100 && _pet.Saciedad >=100){
            return "Ganaste";
        }else{
            return "No Ganaste";
        }
    }

    public String ComprobarPerder(){
        if (Energia <=0 || Saciedad <=0){
            return "Perdiste";
        }else{
            return "No Perdiste";
        }
    }
}