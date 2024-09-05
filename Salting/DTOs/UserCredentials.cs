namespace Salting.Api
{
    public class UserCredentials
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string saltedPassword { get; set; }
        public string base64Salt { get; set; }

        public UserCredentials(int user_id, string email, string encryptedPassword, string encryptedSalt)
        {
            this.user_id = user_id;
            this.email = email;
            this.saltedPassword = encryptedPassword;
            this.base64Salt = encryptedSalt;
        }
    }
}
