using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Limit model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Limits")]
    public class Limit : BaseEntity 
    {
        /// <summary>
        /// The display name for the day.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the limit.")]
        public string Name { get; set; }
        /// <summary>
        /// Whether to apply tags inclusively or exclusively.
        /// </summary>
        [Required]
        public bool ApplyTagsInclusively { get; set; }
        /// <summary>
        /// Id for the linked duration.
        /// </summary>
        [Required]
        public int DurationId { get; set; }
        /// <summary>
        /// Linked duration object.
        /// </summary>
        [ForeignKey(nameof(DurationId))]
        public virtual Duration Duration { get; set; }
        /// <summary>
        /// Collection of booking limits for the limit.
        /// </summary>
        public virtual ICollection<SpaceLimit> SpaceLimits { get; set; } = new List<SpaceLimit>();
        /// <summary>
        /// Collection of tags for the limit.
        /// </summary>
        public virtual ICollection<LimitTag> LimitTags { get; set; } = new List<LimitTag>();
    }
}
