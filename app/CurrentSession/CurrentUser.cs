using app.Leiloeira.Pessoas;

namespace app.CurrentSession
{
    public class CurrentUser 
    {
        public static Pessoa? user = null;
        public static bool isLogged = false;

        public CurrentUser() { }

        public static void setCurrentUser(Pessoa user)
        {
            CurrentUser.user = user;
            CurrentUser.isLogged = true;
        }

        public static Pessoa getCurrentUser()
        {
            return CurrentUser.user;
        }

        public static void logout()
        {
            CurrentUser.user = null;
            CurrentUser.isLogged = false;
        }
    }
}