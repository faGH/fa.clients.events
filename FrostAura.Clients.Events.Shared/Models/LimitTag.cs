using FrostAura.Libraries.Data.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Model for which tags are configured for which limits.
    /// </summary>
    [Table("LimitTags")]
    public class LimitTag : BaseEntity
    {
        /// <summary>
        /// Linked limit id.
        /// </summary>
        [Required]
        public int LimitId { get; set; }
        /// <summary>
        /// Linked tag id.
        /// </summary>
        [Required]
        public int TagId { get; set; }
        /// <summary>
        /// Linked limit object.
        /// </summary>
        [ForeignKey(nameof(LimitId))]
        public virtual Limit Limit { get; set; }
        /// <summary>
        /// Linked tag object.
        /// </summary>
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }
    }
}
