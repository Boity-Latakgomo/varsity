using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace varsity.EntityFrameworkCore
{
    public static class varsityDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<varsityDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<varsityDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
