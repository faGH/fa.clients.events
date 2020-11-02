using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which conditions have specified availability.
    /// </summary>
    [Table("ConditionPeriods")]
    public class ConditionPeriod : BaseEntity
    {
        /// <summary>
        /// Linked period id.
        /// </summary>
        [Required]
        public int PeriodId { get; set; }
        /// <summary>
        /// Linked condition id.
        /// </summary>
        [Required]
        public int ConditionId { get; set; }
        /// <summary>
        /// Linked periode object.
        /// </summary>
        [ForeignKey(nameof(PeriodId))]
        public virtual Period Period { get; set; }
        /// <summary>
        /// Linked condition object.
        /// </summary>
        [ForeignKey(nameof(ConditionId))]
        public virtual Condition Condition { get; set; }
    }
}
