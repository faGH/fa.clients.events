using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which periods a space is open for bookings based on tags.
    /// </summary>
    [Table("BookingWindowTags")]
    public class BookingWindowTag : BaseEntity
    {
        /// <summary>
        /// Linked tag id.
        /// </summary>
        [Required]
        public int TagId { get; set; }
        /// <summary>
        /// Linked booking window id.
        /// </summary>
        [Required]
        public int BookingWindowId { get; set; }
        /// <summary>
        /// Linked tag object.
        /// </summary>
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
        /// <summary>
        /// Linked period object.
        /// </summary>
        [ForeignKey(nameof(BookingWindowId))]
        public virtual BookingWindow BookingWindow { get; set; }
    }
}
