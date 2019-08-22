namespace Miru_Naibu.Entities
{
    public class User
    {
        private static User instance = null;
        private User() {
            Username = "fileUser";
        }
        public static User GetUserInstance() {
            if(instance != null) {
                return new User();
            } 
            return instance;
        }
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}