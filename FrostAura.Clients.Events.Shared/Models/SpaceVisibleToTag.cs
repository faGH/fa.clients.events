using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which tags are allowed to access which spaces.
    /// </summary>
    [Table("SpacesVisibleToTags")]
    public class SpaceVisibleToTag : BaseEntity
    {
        /// <summary>
        /// Linked space id.
        /// </summary>
        [Required]
        public int SpaceId { get; set; }
        /// <summary>
        /// Linked tag id.
        /// </summary>
        [Required]
        public int TagId { get; set; }
        /// <summary>
        /// Linked space object.
        /// </summary>
        [ForeignKey(nameof(SpaceId))]
        public virtual Space Space { get; set; }
        /// <summary>
        /// Linked tag object.
        /// </summary>
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
    }
}
