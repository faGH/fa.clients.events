using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Booking window model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("BookingWindows")]
    public class BookingWindow : BaseEntity 
    {
        /// <summary>
        /// Whether to apply the tags filter inclusively or exclusively.
        /// </summary>
        [Required]
        [Description("Exclusive Tags")]
        public bool ApplyTagsInclusively { get; set; }
        /// <summary>
        /// How many hours in advance a booking is allowed.
        /// </summary>
        [Required]
        [Description("Allowed Advance Booking in Hours")]
        public bool HoursInAdvanceBookingsAllowed { get; set; }
        /// <summary>
        /// Collection of booking windows for a space.
        /// </summary>
        public virtual ICollection<SpaceBookingWindow> SpaceBookingWindows { get; set; } = new List<SpaceBookingWindow>();
        /// <summary>
        /// Collection of booking windows tags.
        /// </summary>
        public virtual ICollection<BookingWindowTag> BookingWindowTags { get; set; } = new List<BookingWindowTag>();
    }
}
