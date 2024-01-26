using app.Leiloeira.Pessoas;

namespace app.CurrentSession
{
    public class CurrentUser 
    {
        public static Pessoa? user = null;
        public static bool isLogged = false;
        public static bool isAdmin = false;
        public static decimal? saldo = 0;

        public CurrentUser() { }

        public static void setCurrentUser(Pessoa user)
        {
            if(user.getTipo() == TipoDePessoa.Utilizador){
                CurrentUser.user = user;
                CurrentUser.isLogged = true;
                CurrentUser.isAdmin = false;
                CurrentUser.saldo = user.getSaldo();
            }
            else if(user.getTipo() == TipoDePessoa.Administrador){
                CurrentUser.user = user;
                CurrentUser.isLogged = true;
                CurrentUser.isAdmin = true;
            }
        }

        public static Pessoa getCurrentUser()
        {
            return CurrentUser.user;
        }

        public static void logout()
        {
            CurrentUser.user = null;
            CurrentUser.isLogged = false;
            CurrentUser.isAdmin = false;
        }
    }
}