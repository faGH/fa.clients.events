using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Tags allowed to make repeated bookings model.
    /// </summary>
    [Table("VenueAllowedBookingsForTags")]
    public class VenueAllowedBookingForTag : BaseEntity
    {
        /// <summary>
        /// Linked venue id.
        /// </summary>
        [Required]
        public int VenueId { get; set; }
        /// <summary>
        /// Linked tag id.
        /// </summary>
        [Required]
        public int TagId { get; set; }
        /// <summary>
        /// Linked venue object.
        /// </summary>
        [ForeignKey(nameof(VenueId))]
        public virtual Venue Venue { get; set; }
        /// <summary>
        /// Linked tag object.
        /// </summary>
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
    }
}
