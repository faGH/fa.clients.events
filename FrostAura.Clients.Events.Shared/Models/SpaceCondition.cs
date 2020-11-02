using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which conditions a space is open for bookings.
    /// </summary>
    [Table("SpaceConditions")]
    public class SpaceCondition : BaseEntity
    {
        /// <summary>
        /// Linked space id.
        /// </summary>
        [Required]
        public int SpaceId { get; set; }
        /// <summary>
        /// Linked condition id.
        /// </summary>
        [Required]
        public int ConditionId { get; set; }
        /// <summary>
        /// Linked space object.
        /// </summary>
        [ForeignKey(nameof(SpaceId))]
        public virtual Space Space { get; set; }
        /// <summary>
        /// Linked condition object.
        /// </summary>
        [ForeignKey(nameof(ConditionId))]
        public virtual Condition Condition { get; set; }
    }
}
