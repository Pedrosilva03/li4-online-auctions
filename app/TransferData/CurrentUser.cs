using app.Leiloeira.Pessoas;

namespace app.TransferData 
{
    public class CurrentUser 
    {
        private static Pessoa? current = null;
        private bool isLogged = false;
        private CurrentUser() { }

        public static void setCurrentUser(Pessoa user) 
        {
            CurrentUser.current = user;
        }

        public static Pessoa getCurrentUser() 
        {
            return CurrentUser.current;
        }
    }
}