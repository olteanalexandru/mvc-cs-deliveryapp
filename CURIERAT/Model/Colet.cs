
namespace Curierat.Model
{
    public class Colet
    {
    private uint cod_col;
    private string locatie;
    private string curier;
    private string traseuoptim;
        public Colet(int cod_col)
        {
            this.cod_col = 0;
            this.locatie = "";
            this.curier = "";
            this.traseuoptim = "";

        }
        public Colet(uint cod_col, string locatie, string curier, string traseuoptim)
        {
            this.cod_col = cod_col;
            this.locatie = locatie;
            this.curier = curier;
            this.traseuoptim = traseuoptim;
        
        }

        public uint AccesCodColet()
        {
            return this.cod_col;
        }
        public string AccesLocatie()
        {
            return this.locatie;
        }

        public string AccesTraseuoptim()
        {
            return this.traseuoptim;
        }

        public string AccesCurier()
        {
            return this.curier;
        }
     
     
      
        public void ActualizareCodColet(uint cod_col)
        {
            this.cod_col = cod_col;
        }
        public void ActualizareLocatie(string locatie)
        {
            this.locatie = locatie;
        }
        public void ActualizareCurier(string curier)
        {
            this.curier = curier;
        }
     
    
        
        public override string ToString()
        {

            return this.cod_col.ToString() + ";" + this.locatie + ";" + this.curier ;
        }
    }
}
