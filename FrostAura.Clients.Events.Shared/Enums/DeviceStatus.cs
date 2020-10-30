namespace FrostAura.Clients.Events.Shared.Enums
{
    /// <summary>
    /// Device statuses.
    /// </summary>
    public enum DeviceStatus
    {
        /// <summary>
        /// When the device has no recorded history.
        /// </summary>
        Inactive = 3,
        /// <summary>
        /// When the device has very recent history.
        /// </summary>
        Online = 1,
        /// <summary>
        /// When the device has older history.
        /// </summary>
        Offline = 2
    }
}
