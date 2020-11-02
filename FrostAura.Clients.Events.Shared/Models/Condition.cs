using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Condition model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Conditions")]
    public class Condition : BaseEntity 
    {
        /// <summary>
        /// The display name for the condition.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the condition.")]
        public string Name { get; set; }
        /// <summary>
        /// Collection of booking conditions for the space.
        /// </summary>
        public virtual ICollection<SpaceCondition> SpaceConditions { get; set; } = new List<SpaceCondition>();
        /// <summary>
        /// Collection of periods the conditions is available for.
        /// </summary>
        public virtual ICollection<ConditionPeriod> Periods { get; set; } = new List<ConditionPeriod>();
        /// <summary>
        /// Collection of or logics this condition is assigned to.
        /// </summary>
        public virtual ICollection<OrLogicCondition> OrLogicConditions { get; set; } = new List<OrLogicCondition>();
    }
}
