using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which periods a space is open for bookings.
    /// </summary>
    [Table("SpaceAvailability")]
    public class SpaceAvailability : BaseEntity
    {
        /// <summary>
        /// Linked space id.
        /// </summary>
        [Required]
        public int SpaceId { get; set; }
        /// <summary>
        /// Linked period id.
        /// </summary>
        [Required]
        public int PeriodId { get; set; }
        /// <summary>
        /// Linked space object.
        /// </summary>
        [ForeignKey(nameof(SpaceId))]
        public virtual Space Space { get; set; }
        /// <summary>
        /// Linked period object.
        /// </summary>
        [ForeignKey(nameof(PeriodId))]
        public virtual Period Period { get; set; }
    }
}
