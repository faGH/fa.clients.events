using System.Collections.Generic;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Base for a node list.
    /// </summary>
    /// <typeparam name="TItemType">Type of the items the node list will hold.</typeparam>
    public class NodeList<TItemType>
    {
        /// <summary>
        /// Collection of nodes.
        /// </summary>
        public List<TItemType> Nodes { get; set; } = new List<TItemType>();
    }
}
