using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Or logic model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("OrLogic")]
    public class OrLogic : BaseEntity 
    {
        /// <summary>
        /// The display name for the or logic.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the or logic.")]
        public string Name { get; set; }
        /// <summary>
        /// Collection of or logics assigned to this condition.
        /// </summary>
        public virtual ICollection<OrLogicCondition> OrLogicConditions { get; set; } = new List<OrLogicCondition>();
        /// <summary>
        /// Collection of or logics grouped together.
        /// </summary>
        public virtual ICollection<OrLogicIfLogicGroup> OrLogicIfLogicGroups { get; set; } = new List<OrLogicIfLogicGroup>();
    }
}
