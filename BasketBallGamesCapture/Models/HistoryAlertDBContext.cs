using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BasketBallGamesCapture.Models
{
    public class HistoryAlertDBContext : DbContext
    {
        public HistoryAlertDBContext(string dbConnectString) : base(dbConnectString)
        {
            Database.SetInitializer<HistoryAlertDBContext>(new CreateDatabaseIfNotExists<HistoryAlertDBContext>());

            // Output the sql sentence in debug mode.
            Database.Log = sql => Debug.WriteLine(sql);
        }

        public DbSet<HistoryModel> historyAlerts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}