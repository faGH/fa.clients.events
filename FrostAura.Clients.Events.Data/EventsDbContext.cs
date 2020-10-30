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
    }
}
