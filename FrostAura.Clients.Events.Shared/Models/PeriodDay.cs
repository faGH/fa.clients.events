using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for period days.
    /// </summary>
    [Table("PeriodDays")]
    public class PeriodDay : BaseEntity
    {
        /// <summary>
        /// Linked day id.
        /// </summary>
        [Required]
        public int DayId { get; set; }
        /// <summary>
        /// Linked period id.
        /// </summary>
        [Required]
        public int PeriodId { get; set; }
        /// <summary>
        /// Linked day object.
        /// </summary>
        [ForeignKey(nameof(DayId))]
        public virtual Day Day { get; set; }
        /// <summary>
        /// Linked period object.
        /// </summary>
        [ForeignKey(nameof(PeriodId))]
        public virtual Period Period { get; set; }
    }
}
