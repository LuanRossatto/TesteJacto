namespace ProjetoJacto.Utilitarios
{
    public class Utilitarios
    {
        public static bool VerificaValorNulo<T>(T obj)
        {
            return typeof(T).GetProperties().All(a => a.GetValue(obj) != null);
     
        }

        public static bool ValidaHash(string hash)
        {
            if(hash == "1x-_MTXVukyN-fo7eKRfnQ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

