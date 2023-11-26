namespace SeniorChallenge.Entities
{
    /// <summary>
    /// the entity "Person" requested by the challenge 
    /// </summary>
    public class Person : ObjectWithId
    {
        /// <summary>
        /// The CPF from this person.
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// The name of this person.
        /// </summary>
        public string Name { get; set; }

        private string uf;

        /// <summary>
        /// The acronym of the person's state
        /// </summary>
        public string UF
        {
            get => uf;
            set => uf = value.ToUpper();
        }

    }
}
