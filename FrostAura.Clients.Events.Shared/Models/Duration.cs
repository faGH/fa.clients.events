using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Duration model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Durations")]
    public class Duration : BaseEntity 
    {
        /// <summary>
        /// The display name for the duration.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the duration.")]
        public string Name { get; set; }
        /// <summary>
        /// The value in minutes of the duration.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "A valid name is required for the duration.")]
        public int Minutes { get; set; }
        /// <summary>
        /// Collection of if logics this is assigned to.
        /// </summary>
        public virtual ICollection<IfLogic> IfLogic { get; set; } = new List<IfLogic>();
    }
}
