using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which limits a space is open for bookings.
    /// </summary>
    [Table("SpaceLimits")]
    public class SpaceLimit : BaseEntity
    {
        /// <summary>
        /// Linked space id.
        /// </summary>
        [Required]
        public int SpaceId { get; set; }
        /// <summary>
        /// Linked limit id.
        /// </summary>
        [Required]
        public int LimitId { get; set; }
        /// <summary>
        /// Linked space object.
        /// </summary>
        [ForeignKey(nameof(SpaceId))]
        public virtual Space Space { get; set; }
        /// <summary>
        /// Linked limit object.
        /// </summary>
        [ForeignKey(nameof(LimitId))]
        public virtual Limit Limit { get; set; }
    }
}
