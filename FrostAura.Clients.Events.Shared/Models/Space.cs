using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Space within a venue's model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Spaces")]
    public class Space : BaseEntity 
    {
        /// <summary>
        /// Linked venue id.
        /// </summary>
        [Required]
        public int VenueId { get; set; }
        /// <summary>
        /// The display name for the venue.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the space.")]
        public string Name { get; set; }
        /// <summary>
        /// Linked venue object.
        /// </summary>
        [ForeignKey(nameof(VenueId))]
        public virtual Venue Venue { get; set; }
        /// <summary>
        /// Collection for which tags are allowed to access which spaces.
        /// </summary>
        public virtual ICollection<SpaceVisibleToTag> SpacesVisibleToTags { get; set; } = new List<SpaceVisibleToTag>();
        /// <summary>
        /// Collection for which tags are allowed to access which spaces.
        /// </summary>
        public virtual ICollection<SpaceAvailability> SpaceAvailability { get; set; } = new List<SpaceAvailability>();
        /// <summary>
        /// Collection of booking windows for the space.
        /// </summary>
        public virtual ICollection<SpaceBookingWindow> SpaceBookingWindows { get; set; } = new List<SpaceBookingWindow>();
    }
}
