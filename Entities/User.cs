namespace Miru_Naibu.Entities
{
    public sealed class User
    {
        private static User instance = null;
        private static readonly object padlock = new object();
        private User() {
            Username = "fileUser";
            Password = "fileMD5password";
        }
        public static User GetUserInstance { 
            get {
                lock (padlock) {
                    if(instance != null) {
                        return new User();
                    } 
                    return instance;
                }
            }
        }
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}