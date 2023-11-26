using SeniorChallenge.Entities;
using SeniorChallenge.Repositories;
using SeniorChallenge.Utilities;

namespace SeniorChallenge.Services
{
    /// <summary>
    /// The service to manage persons operations.
    /// </summary>
    public class PersonService
    {
        private static readonly PersonRepository repo = new();

        /// <summary>
        /// Register a new object in the virtual repository (the id is managed in repo).
        /// </summary>
        /// <param name="person">The object that will be saved.</param>
        /// <returns>The saved object with id updated.</returns>
        public Person Insert(Person person)
        {
            person.Cpf.CheckCPFIsValid();
            return repo.Insert(person);
        }

        /// <summary>
        /// Update a object selected by id in the virtual repository.
        /// </summary>
        /// <param name="person">The object that will be saved.</param>
        /// <returns>The updated object.</returns>
        public Person Update(Person person)
        {
            person.Cpf.CheckCPFIsValid();
            return repo.Update(person);
        }

        /// <summary>
        /// Get the object with corresponding id.
        /// </summary>
        /// <param name="id">The id from target object.</param>
        /// <returns>The object registered with id infornmed.</returns>
        public Person GetSingle(int id)
        {
            return repo.GetById(id);
        }

        /// <summary>
        /// Gets all items already registered in the repository filtered by the person's UF.
        /// </summary>
        /// <param name="uf">The acronym of the person's state.</param>
        /// <returns>The list of registered items filtered by the person's UF.</returns>
        public List<Person> GetByUf(string uf)
        {
            return repo.GetByUf(uf);
        }

        /// <summary>
        /// Gets all items already registered in the repository
        /// </summary>
        /// <returns>The list of registered items.</returns>
        public List<Person> GetAll()
        {
            return repo.GetAll();
        }

        /// <summary>
        /// Remove a object from the virtual repository by id.
        /// </summary>
        /// <param name="id">The id from target object.</param>
        /// <returns>The object that will be deleted.</returns>
        /// <exception cref="ArgumentException">Throw a ArgumentException when delete more than one item.</exception>
        public bool Delete(int id)
        {
            return repo.Remove(id);
        }
    }
}
