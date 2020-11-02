using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Control type model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("ControlTypes")]
    public class ControlType : BaseEntity 
    {
        /// <summary>
        /// The display name for the control type.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the control type.")]
        public string Name { get; set; }
        /// <summary>
        /// Collection of linked to control types.
        /// </summary>
        public virtual ICollection<LogicKey> LogicKeys { get; set; } = new List<LogicKey>();
    }
}
