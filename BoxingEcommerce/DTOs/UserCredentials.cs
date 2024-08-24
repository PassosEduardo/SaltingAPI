namespace Salting.Api
{
    public class UserCredentials
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string encryptedPassword { get; set; }
        public string encryptedSalt { get; set; }

        public UserCredentials(int user_id, string email, string encryptedPassword, string encryptedSalt)
        {
            this.user_id = user_id;
            this.email = email;
            this.encryptedPassword = encryptedPassword;
            this.encryptedSalt = encryptedSalt;
        }
    }
}
