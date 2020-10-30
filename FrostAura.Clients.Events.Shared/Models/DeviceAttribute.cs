using System;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Device attribute model.
    /// </summary>
    [DebuggerDisplay("Name: {Attribute.Name}, Value: {Value}")]
    public class DeviceAttribute
    {
        /// <summary>
        /// Attribute context.
        /// </summary>
        public Venue Attribute { get; set; }
        /// <summary>
        /// Attribute value.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Timestamp of when the value was recorded.
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
