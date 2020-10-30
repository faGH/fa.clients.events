using FrostAura.Clients.Events.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace FrostAura.Clients.Events.Data.Extensions
{
    /// <summary>
    /// Extensions for the Device type.
    /// </summary>
    public static class DeviceExtensions
    {
        /// <summary>
        /// Return a device with only distinct attributes.
        /// </summary>
        /// <param name="device">Device context.</param>
        /// <returns>Updated device context.</returns>
        public static Device WithDistinctAttributes(this Device device)
        {
            device.Attributes.Nodes = GetDistinctAttributes(device.Attributes.Nodes);

            return device;
        }

        /// <summary>
        /// Return a device with only distinct attributes.
        /// </summary>
        /// <param name="device">Device context.</param>
        /// <returns>Updated device context.</returns>
        public static Device WithLatestAttributesFirst(this Device device)
        {
            // TODO: Move this to the query instead as we support ordering in the GraphQL layer.
            device.Attributes.Nodes = device
                .Attributes
                .Nodes
                .OrderByDescending(a => a.TimeStamp)
                .ToList();

            return device;
        }

        /// <summary>
        /// Filter out older duplicate attributes.
        /// </summary>
        /// <param name="originalList">Original attribute list.</param>
        /// <returns>Filtered list.</returns>
        private static List<DeviceAttribute> GetDistinctAttributes(List<DeviceAttribute> originalList)
        {
            var response = new Dictionary<string, DeviceAttribute>();

            foreach (var attr in originalList)
            {
                if (response.ContainsKey(attr.Attribute.Name)) continue;

                response[attr.Attribute.Name] = attr;
            }

            return response
                .Select(a => a.Value)
                .OrderBy(a => a.Attribute.Name)
                .ToList();
        }
    }
}
