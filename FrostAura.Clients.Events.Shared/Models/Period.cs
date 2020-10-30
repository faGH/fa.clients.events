using FrostAura.Libraries.Data.Models.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FrostAura.Clients.Events.Shared.Models
{
    /// <summary>
    /// Time period model.
    /// </summary>
    [DebuggerDisplay("Name: {Name}")]
    [Table("Periods")]
    public class Period : BaseEntity 
    {
        /// <summary>
        /// The display name for the period.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "A valid name is required for the period.")]
        public string Name { get; set; }
        /// <summary>
        /// Collection for which period days.
        /// </summary>
        public virtual ICollection<PeriodDay> PeriodDays { get; set; } = new List<PeriodDay>();
    }
}
