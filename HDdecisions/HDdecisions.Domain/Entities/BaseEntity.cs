
namespace HDdecisions.Domain
{
    /// <summary>
    /// Base Entity, used by all other entities to provide common properties
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
    }
}
