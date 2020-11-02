using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which if logics below to a n or logic group.
    /// </summary>
    [Table("OrLogicIfLogicGroups")]
    public class OrLogicIfLogicGroup : BaseEntity
    {
        /// <summary>
        /// Linked or logic id.
        /// </summary>
        [Required]
        public int OrLogicId { get; set; }
        /// <summary>
        /// Linked if logic id.
        /// </summary>
        [Required]
        public int IfLogicId { get; set; }
        /// <summary>
        /// Linked or logic object.
        /// </summary>
        [ForeignKey(nameof(OrLogicId))]
        public virtual OrLogic OrLogic { get; set; }
        /// <summary>
        /// Linked condition object.
        /// </summary>
        [ForeignKey(nameof(IfLogicId))]
        public virtual IfLogic IfLogic { get; set; }
    }
}
