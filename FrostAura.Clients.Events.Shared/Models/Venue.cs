using FrostAura.Libraries.Data.Models.EntityFramework;
using FrostAura.Standard.Components.Razor.Attributes.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Venue model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Venues")]
    public class Venue : BaseEntity 
    {
        /// <summary>
        /// The display name for the venue.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the venue.")]
        public string Name { get; set; }
        /// <summary>
        /// Whether the venue is open to the public.
        /// </summary>
        [Required]
        [Description("Publically Visible")]
        public bool IsPublic { get; set; }
        /// <summary>
        /// Whether to display the booker's details on a booking
        /// </summary>
        [Required]
        [Description("Show Booker's Details on Bookings")]
        public bool ShareBookerDetails { get; set; }
        /// <summary>
        /// Collection of linked spaces.
        /// </summary>
        [FieldIgnore]
        public virtual ICollection<Space> Spaces { get; set; } = new List<Space>();
        /// <summary>
        /// Collection of linked tag allowed to make bookings.
        /// </summary>
        [FieldIgnore]
        public virtual ICollection<VenueAllowedBookingForTag> VenueAllowedBookingsForTags { get; set; } = new List<VenueAllowedBookingForTag>();
        /// <summary>
        /// Collection of linked tags allowed to make repeated bookings.
        /// </summary>
        [FieldIgnore]
        public virtual ICollection<VenueAllowedRepeatedBookingForTag> VenueAllowedRepeatedBookingsForTags { get; set; } = new List<VenueAllowedRepeatedBookingForTag>();
    }
}
