using FrostAura.Libraries.Data.Models.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which conditions belong to or logic groups.
    /// </summary>
    [Table("OrLogicConditions")]
    public class OrLogicCondition : BaseEntity
    {
        /// <summary>
        /// Linked or logic id.
        /// </summary>
        [Required]
        public int OrLogicId { get; set; }
        /// <summary>
        /// Linked condition id.
        /// </summary>
        [Required]
        public int ConditionId { get; set; }
        /// <summary>
        /// Linked or logic object.
        /// </summary>
        [ForeignKey(nameof(OrLogicId))]
        public virtual OrLogic OrLogic { get; set; }
        /// <summary>
        /// Linked condition object.
        /// </summary>
        [ForeignKey(nameof(ConditionId))]
        public virtual Condition Condition { get; set; }
        /// <summary>
        /// Start time of the condition.
        /// </summary>
        [Required(ErrorMessage = "A valid start time is required.")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// End time of the condition.
        /// </summary>
        [Required(ErrorMessage = "A valid start time is required.")]
        public DateTime EndTime { get; set; }
    }
}
