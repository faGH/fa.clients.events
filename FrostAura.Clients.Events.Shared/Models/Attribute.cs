using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Attribute model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    public class Attribute
    {
        /// <summary>
        /// Unique auto-generated device identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Attribute name.
        /// </summary>
        public string Name { get; set; }
    }
}
