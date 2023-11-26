using SeniorChallenge.Entities;

namespace SeniorChallenge.Repositories
{
    /// <summary>
    /// Abstract class with the default implementations to define a persistence in memory.
    /// </summary>
    /// <typeparam name="T">The type of repository that will be deployed.</typeparam>
    public abstract class InMemoryRepo<T> where T : ObjectWithId
    {
        /// <summary>
        /// The virtual repository.
        /// </summary>
        protected static List<T> Persistence { get; private set; }

        /// <summary>
        /// The base constructor to set initial values in persistence.
        /// </summary>
        protected InMemoryRepo()
        {
            Persistence = InitialCollection();
        }

        /// <summary>
        /// Get the object with corresponding id.
        /// </summary>
        /// <param name="id">The id from target object.</param>
        /// <returns>The object registered with id infornmed.</returns>
        public T GetById(int id)
        {
            return Persistence.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Register a new object in the virtual repository (the id is managed in this method).
        /// </summary>
        /// <param name="obj">The object that will be saved.</param>
        /// <returns>The saved object with id updated.</returns>
        public T Insert(T obj)
        {
            if (Persistence.Any())
            {
                int nextId = Persistence.Max(x => x.Id) + 1;
                obj.Id = nextId;
            }
            else
            {
                obj.Id = 1;
            }

            Persistence.Add(obj);
            return obj;
        }

        /// <summary>
        /// Remove a object from the virtual repository by id.
        /// </summary>
        /// <param name="id">The id from target object.</param>
        /// <returns>The object that will be deleted.</returns>
        /// <exception cref="ArgumentException">Throw a ArgumentException when delete more than one item.</exception>
        public bool Remove(int id)
        {
            int rowCount = Persistence.RemoveAll(x => x.Id == id);

            return rowCount > 1
                ? throw new ArgumentException("Unexpectedly the system deleted more information than requested, "
                                            + "look for a system administrator and inform them of"
                                            + " the time of the incident for appropriate treatment.")
                : rowCount == 1;
        }

        /// <summary>
        /// Update a object selected by id in the virtual repository.
        /// </summary>
        /// <param name="obj">The object that will be saved.</param>
        /// <returns>The updated object.</returns>
        public T Update(T obj)
        {
            if (Remove(obj.Id))
            {
                Persistence.Add(obj);
                return obj;
            }
            return null;
        }

        /// <summary>
        /// Gets all items already registered in the repository
        /// </summary>
        /// <returns>The list of registered items.</returns>
        public List<T> GetAll()
        {
            return Persistence;
        }

        /// <summary>
        /// The initial values on mount from the persistence.
        /// </summary>
        /// <returns>The values that must be present in the persistence.</returns>
        protected virtual List<T> InitialCollection()
        {
            return new List<T>();
        }
    }
}