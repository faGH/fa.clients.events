using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which tags are assigned to if logic.
    /// </summary>
    [Table("IfLogicTags")]
    public class IfLogicTag : BaseEntity
    {
        /// <summary>
        /// Linked if logic id.
        /// </summary>
        [Required]
        public int IfLogicId { get; set; }
        /// <summary>
        /// Linked tag id.
        /// </summary>
        [Required]
        public int TagId { get; set; }
        /// <summary>
        /// Linked if logic object.
        /// </summary>
        [ForeignKey(nameof(IfLogicId))]
        public virtual IfLogic IfLogic { get; set; }
        /// <summary>
        /// Linked tag object.
        /// </summary>
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
    }
}
