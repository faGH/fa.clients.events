using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Operator model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Operators")]
    public class Operator : BaseEntity 
    {
        /// <summary>
        /// The display name for the operator.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the opeartor.")]
        public string Name { get; set; }
        /// <summary>
        /// Collection of if logics this is assigned to.
        /// </summary>
        public virtual ICollection<IfLogic> IfLogic { get; set; } = new List<IfLogic>();
    }
}
