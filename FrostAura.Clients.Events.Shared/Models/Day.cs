using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Day model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Days")]
    public class Day : BaseEntity 
    {
        /// <summary>
        /// The display name for the day.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the day.")]
        public string Name { get; set; }
        /// <summary>
        /// Collection for which tags are allowed to access which spaces.
        /// </summary>
        public virtual ICollection<SpaceAvailability> SpaceAvailability { get; set; } = new List<SpaceAvailability>();
        /// <summary>
        /// Collection for which period days.
        /// </summary>
        public virtual ICollection<PeriodDay> PeriodDays { get; set; } = new List<PeriodDay>();
    }
}
