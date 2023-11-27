using SeniorChallenge.Entities;

namespace SeniorChallenge.Repositories
{
    /// <summary>
    /// The repository to manage the entity person.
    /// </summary>
    public class PersonRepository : InMemoryRepo<Person>
    {
        /// <summary>
        /// Gets all items already registered in the repository filtered by the person's UF.
        /// </summary>
        /// <param name="uf">The acronym of the person's state.</param>
        /// <returns>The list of registered items filtered by the person's UF.</returns>
        internal List<Person> GetByUf(string uf)
        {
            return Persistence.Where(x => x.UF == uf.ToUpper()).ToList();
        }
    }
}
