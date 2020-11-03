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
        public virtual DbSet<SpaceAvailability> SpaceAvailability { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<PeriodDay> PeriodDays { get; set; }
        public virtual DbSet<BookingWindow> BookingWindows { get; set; }
        public virtual DbSet<SpaceBookingWindow> SpaceBookingWindows { get; set; }
        public virtual DbSet<BookingWindowTag> BookingWindowTags { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<Duration> Durations { get; set; }
        public virtual DbSet<ControlType> ControlTypes { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<OrLogic> OrLogic { get; set; }
        public virtual DbSet<LogicKey> LogicKeys { get; set; }
        public virtual DbSet<SpaceCondition> SpaceConditions { get; set; }
        public virtual DbSet<ConditionPeriod> ConditionPeriods { get; set; }
        public virtual DbSet<OrLogicCondition> OrLogicConditions { get; set; }
        public virtual DbSet<IfLogic> IfLogic { get; set; }
        public virtual DbSet<IfLogicTag> IfLogicTags { get; set; }
        public virtual DbSet<OrLogicIfLogicGroup> OrLogicIfLogicGroups { get; set; }
        public virtual DbSet<Limit> Limits { get; set; }
        public virtual DbSet<SpaceLimit> SpaceLimits { get; set; }
        public virtual DbSet<LimitTag> LimitTags { get; set; }
    }
}
