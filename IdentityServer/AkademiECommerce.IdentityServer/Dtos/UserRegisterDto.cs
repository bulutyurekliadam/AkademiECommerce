using System.Security.Permissions;

namespace AkademiECommerce.IdentityServer.Dtos
{
    public class UserRegisterDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname  { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }
        public string Password{ get; set; }
    }
}
