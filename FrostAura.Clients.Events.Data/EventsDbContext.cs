using FrostAura.Clients.Events.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FrostAura.Clients.Events.Data
{
    /// <summary>
    /// Events database context.
    /// </summary>
    public class EventsDbContext : DbContext
    {
        /// <summary>
        /// Construct and allow for passing options.
        /// </summary>
        /// <param name="options">Db creation options.</param>
        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Space> Spaces { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<VenueAllowedRepeatedBookingForTag> VenueAllowedRepeatedBookingsForTags { get; set; }
        public virtual DbSet<VenueAllowedBookingForTag> VenueAllowedBookingsForTags { get; set; }
        public virtual DbSet<SpaceVisibleToTag> SpacesVisibleToTags { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<PeriodDay> PeriodDays { get; set; }
    }
}
