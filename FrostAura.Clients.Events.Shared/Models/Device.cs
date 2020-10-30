using System.Diagnostics;
using System;
using System.Linq;
using FrostAura.Clients.Events.Shared.Enums;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Devicemodel as it pertains to the queries we will write.
    /// </summary>
    [DebuggerDisplay("Id: {Id}, Name: {Name}")]
    public class Device
    {
        /// <summary>
        /// Unique auto-generated device identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Unique device indentifier provided by the data source.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Device attributes.
        /// </summary>
        public NodeList<DeviceAttribute> Attributes { get; set; }
        /// <summary>
        /// How many minutes qualify as a device being offline.
        /// </summary>
        private const int MINUTES_TO_OFFLINE = 15;

        /// <summary>
        /// Return the searchable string via the ToString function.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }

        /// <summary>
        /// Extended status message of the device.
        /// </summary>
        public string StatusText
        {
            get
            {
                if (Attributes == null || Attributes.Nodes.Count == 0) return "No recent updates.";

                TimeSpan timeFromLastLocation = DateTime.UtcNow - Attributes
                   .Nodes
                   .First()
                   .TimeStamp;

                if (timeFromLastLocation.TotalSeconds < 90) return $"Last seen {(timeFromLastLocation.Seconds < 0 ? timeFromLastLocation.Seconds * -1 : timeFromLastLocation.Seconds)} seconds ago.";
                if (timeFromLastLocation.TotalMinutes < 90) return $"Last seen {(timeFromLastLocation.Minutes < 0 ? timeFromLastLocation.Minutes * -1 : timeFromLastLocation.Minutes)} minutes ago.";
                if (timeFromLastLocation.TotalHours < 36) return $"Last seen {(timeFromLastLocation.Hours < 0 ? timeFromLastLocation.Hours * -1 : timeFromLastLocation.Hours)} hours ago.";

                return $"Last seen {(timeFromLastLocation.Days < 0 ? timeFromLastLocation.Days * -1 : timeFromLastLocation.Days)} days ago.";
            }
        }

        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        public DeviceStatus Status
        {
            get
            {
                if (Attributes == null || Attributes.Nodes.Count == 0) return DeviceStatus.Inactive;

                TimeSpan timeFromLastLocation = DateTime.UtcNow - Attributes
                   .Nodes
                   .First()
                   .TimeStamp;

                // If the last location is more recent than 15 minutes ago, assume is't active.
                if (timeFromLastLocation.TotalMinutes <= MINUTES_TO_OFFLINE) return DeviceStatus.Online;

                return DeviceStatus.Offline;
            }
        }
    }
}
