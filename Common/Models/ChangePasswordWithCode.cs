namespace Raique.Authenticate.Common.Models
{
    public class ChangePasswordWithCode
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
