using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Logic key model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("LogicKeys")]
    public class LogicKey : BaseEntity 
    {
        /// <summary>
        /// The display name for the logic key.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the logic key.")]
        public string Name { get; set; }
        /// <summary>
        /// Id of the linked control type.
        /// </summary>
        [Required]
        public int ControlTypeId { get; set; }
        /// <summary>
        /// Linked control type object.
        /// </summary>
        [ForeignKey(nameof(ControlTypeId))]
        public virtual ControlType ControlType { get; set; }
        /// <summary>
        /// Collection of if logics this is assigned to.
        /// </summary>
        public virtual ICollection<IfLogic> IfLogic { get; set; } = new List<IfLogic>();
    }
}
