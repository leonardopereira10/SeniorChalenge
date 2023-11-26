namespace SeniorChallenge.Consts
{
#pragma warning disable CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
    public sealed class TypeSafeEnumPermissionRoles
    {
        public static readonly TypeSafeEnumPermissionRoles CreatePerson = new(EnumPermissionRoles.CREATE_PERSON, ConstRoles.CREATE_PERSON);
        public static readonly TypeSafeEnumPermissionRoles ReadPerson = new(EnumPermissionRoles.READ_PERSON, ConstRoles.READ_PERSON);
        public static readonly TypeSafeEnumPermissionRoles UpdatePerson = new(EnumPermissionRoles.UPDATE_PERSON, ConstRoles.UPDATE_PERSON);
        public static readonly TypeSafeEnumPermissionRoles DeletePerson = new(EnumPermissionRoles.DELETE_PERSON, ConstRoles.DELETE_PERSON);

        public EnumPermissionRoles Role { get; }
        public string Description { get; }

        private TypeSafeEnumPermissionRoles(EnumPermissionRoles enumRole, string roleDescription)
        {
            Role = enumRole;
            Description = roleDescription;
        }

        /// <summary>
        /// Get the permission role dictionary from the enum.
        /// </summary>
        /// <param name="enumRole">the enum that will be obtained</param>
        /// <returns>a type safe containing enum and description of the requested content.</returns>
        public static TypeSafeEnumPermissionRoles GetPermissionByEnum(EnumPermissionRoles enumRole)
        {
            return enumRole switch
            {
                EnumPermissionRoles.DELETE_PERSON => DeletePerson,
                EnumPermissionRoles.READ_PERSON => ReadPerson,
                EnumPermissionRoles.CREATE_PERSON => CreatePerson,
                EnumPermissionRoles.UPDATE_PERSON => UpdatePerson,
                _ => null,
            };
        }
    }
#pragma warning restore CS1591 // O comentário XML ausente não foi encontrado para o tipo ou membro visível publicamente
}
