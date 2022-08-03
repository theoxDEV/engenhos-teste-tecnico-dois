namespace engenhos_teste_tecnico_dois
{
    public class Bateria
    {
        public int Carga { get; set; }

        public int TrocarDeBateria()
        {
            return this.Carga = 100;
        }
    }
}
