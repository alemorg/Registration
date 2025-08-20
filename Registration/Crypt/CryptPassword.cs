using System.Text;

namespace Registration.Crypt
{
    public class CryptPassword
    {
        public string Encode (string password)
        {
            try
            {
                byte[] bytesPassword = new byte[password.Length];
                bytesPassword = Encoding.UTF8.GetBytes (password);
                return Convert.ToBase64String (bytesPassword);
            }
            catch (Exception ex) 
            {
                throw new Exception("Error in encode" + ex.Message);
            }
        }

        public string Decrypt(string password)
        {
            try
            {
                byte[] bytesPassword = Convert.FromBase64String(password);
                return Encoding.UTF8.GetString(bytesPassword);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in decrypt" + ex.Message);
            }
        }
    }
}
