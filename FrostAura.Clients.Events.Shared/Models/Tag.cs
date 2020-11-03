using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Tag model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Tags")]
    public class Tag : BaseEntity 
    {
        /// <summary>
        /// The display name for the venue.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the tag.")]
        public string Name { get; set; }
        /// <summary>
        /// Collection of linked venues allowed to make bookings.
        /// </summary>
        public virtual ICollection<VenueAllowedBookingForTag> VenueAllowedBookingsForTags { get; set; } = new List<VenueAllowedBookingForTag>();
        /// <summary>
        /// Collection of linked venues allowed to make repeated bookings.
        /// </summary>
        public virtual ICollection<VenueAllowedRepeatedBookingForTag> VenueAllowedRepeatedBookingsForTags { get; set; } = new List<VenueAllowedRepeatedBookingForTag>();
        /// <summary>
        /// Collection for which tags are allowed to access which spaces.
        /// </summary>
        public virtual ICollection<SpaceVisibleToTag> SpacesVisibleToTags { get; set; } = new List<SpaceVisibleToTag>();
        /// <summary>
        /// Collection of tags for booking windows.
        /// </summary>
        public virtual ICollection<BookingWindowTag> BookingWindowTags { get; set; } = new List<BookingWindowTag>();
        /// <summary>
        /// Collection of tags for if logic.
        /// </summary>
        public virtual ICollection<IfLogicTag> IfLogicTags { get; set; } = new List<IfLogicTag>();
        /// <summary>
        /// Collection of tags for limits.
        /// </summary>
        public virtual ICollection<LimitTag> LimitTags { get; set; } = new List<LimitTag>();
    }
}
