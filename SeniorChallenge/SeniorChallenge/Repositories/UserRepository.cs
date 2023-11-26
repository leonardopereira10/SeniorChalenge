using SeniorChallenge.Consts;
using SeniorChallenge.Entities;

namespace SeniorChallenge.Repositories
{
    /// <summary>
    /// The repository to manage the entity User.
    /// </summary>
    public class UserRepository : InMemoryRepo<User>
    {
        /// <summary>
        /// Get the user by login information.
        /// </summary>
        /// <param name="mail">Mail from user.</param>
        /// <param name="hashPass">Encrypted value of the password with mail</param>
        /// <returns></returns>
        public User GetByLogin(string mail, string hashPass)
        {
            return Persistence.Single(x => x.Mail == mail && x.HashPass == hashPass);
        }

        /// <summary>
        /// The initial values on mount from the persistence.
        /// </summary>
        /// <returns>The values that must be present in the persistence.</returns>
        protected override List<User> InitialCollection()
        {
            string password = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") is not null && bool.Parse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER")) ? "H3s+N6tl5Zui5a0LVYFjmw==" : "bWfM5W9c4Q3b5FTknP/M/Q==";
            return new()
            {
                new User
                {
                    Mail = "admin@mail.com",
                    Password = password,
                    Id = 1,
                    Permissions = new EnumPermissionRoles[]
                    {
                        EnumPermissionRoles.CREATE_PERSON,
                        EnumPermissionRoles.READ_PERSON,
                        EnumPermissionRoles.UPDATE_PERSON,
                        EnumPermissionRoles.DELETE_PERSON
                    }
                },
                new User
                {
                    Mail = "can_read@mail.com",
                    Password = password,
                    Id = 2,
                    Permissions = new EnumPermissionRoles[]
                    {
                        EnumPermissionRoles.READ_PERSON,
                    }
                },
                new User
                {
                    Mail = "can_create@mail.com",
                    Password = password,
                    Id = 3,
                    Permissions = new EnumPermissionRoles[]
                    {
                        EnumPermissionRoles.CREATE_PERSON
                    }
                },
                new User
                {
                    Mail = "can_delete@mail.com",
                    Password = password,
                    Id = 4,
                    Permissions = new EnumPermissionRoles[]
                    {
                        EnumPermissionRoles.DELETE_PERSON
                    }
                },
                new User
                {
                    Mail = "can_update@mail.com",
                    Password = password,
                    Id = 3,
                    Permissions = new EnumPermissionRoles[]
                    {
                        EnumPermissionRoles.UPDATE_PERSON
                    }
                }
            };
        }
    }
}
