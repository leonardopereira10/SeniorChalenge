namespace SeniorChallenge.Entities
{
    /// <summary>
    /// Class used to specify values to filter on generic repository.
    /// </summary>
    public abstract class ObjectWithId
    {
        /// <summary>
        /// The id used to automate the cration of the repository.
        /// </summary>
        public int Id { get; set; }
    }
}