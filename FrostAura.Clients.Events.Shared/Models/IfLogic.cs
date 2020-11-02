using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// If logic model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("IfLogic")]
    public class IfLogic : BaseEntity 
    {
        /// <summary>
        /// The display name for the if logic.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the if logic.")]
        public string Name { get; set; }
        /// <summary>
        /// Linked duration id.
        /// </summary>
        public int? DurationId { get; set; }
        /// <summary>
        /// Linked operator id.
        /// </summary>
        [Required]
        public int OperatorId { get; set; }
        /// <summary>
        /// Linked logic key id.
        /// </summary>
        [Required]
        public int LogicKeyId { get; set; }
        /// <summary>
        /// Linked duration object.
        /// </summary>
        [ForeignKey(nameof(DurationId))]
        public virtual Duration Duration { get; set; }
        /// <summary>
        /// Linked operator object.
        /// </summary>
        [ForeignKey(nameof(OperatorId))]
        public virtual Operator Operator { get; set; }
        /// <summary>
        /// Linked logic key object.
        /// </summary>
        [ForeignKey(nameof(LogicKeyId))]
        public virtual LogicKey LogicKey { get; set; }
        /// <summary>
        /// Collection of tags for if logic.
        /// </summary>
        public virtual ICollection<IfLogicTag> IfLogicTags { get; set; } = new List<IfLogicTag>();
        /// <summary>
        /// Collection of or logics grouped together.
        /// </summary>
        public virtual ICollection<OrLogicIfLogicGroup> OrLogicIfLogicGroups { get; set; } = new List<OrLogicIfLogicGroup>();
    }
}
