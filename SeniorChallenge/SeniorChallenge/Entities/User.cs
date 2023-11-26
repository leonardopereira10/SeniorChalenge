using SeniorChallenge.Consts;
using SeniorChallenge.Utilities;

namespace SeniorChallenge.Entities
{
    /// <summary>
    /// The user informations.
    /// </summary>
    public class User : ObjectWithId
    {
        /// <summary>
        /// The email from user.
        /// </summary>
        public string Mail { get; set; }


        /// <summary>
        /// The password from user).
        /// </summary>
        public string Password { private get; set; }

        /// <summary>
        /// The permissions desgnated to this user
        /// </summary>
        public EnumPermissionRoles[] Permissions { get; set; }

        /// <summary>
        /// The hash used to expose the password.
        /// </summary>
        public string HashPass => UtilEncrypter.Encrypt(Mail + Password);
    }
}
