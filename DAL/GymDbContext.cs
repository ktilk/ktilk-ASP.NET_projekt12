using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class GymDbContext : DbContext, IDbContext
    {
        public GymDbContext() : base("DbConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GymDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GymDbContext, MigrationConfiguration>());
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        public IDbSet<Person> Persons { get; set; }
        public IDbSet<Competition> Competitions { get; set; }
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<ContactType> ContactTypes { get; set; }
        public IDbSet<Exercise> Exercises { get; set; }
        public IDbSet<ExerciseInWorkout> ExercisesInWorkouts { get; set; }
        public IDbSet<ExerciseType> ExerciseTypes { get; set; }
        public IDbSet<Participation> Participations { get; set; }
        public IDbSet<Plan> Plans { get; set; }
        public IDbSet<PlanType> PlanTypes { get; set; }
        public IDbSet<Workout> Workouts { get; set; }

        // Identity tables, PK - int
        //public IDbSet<RoleInt> RolesInt { get; set; }
        //public IDbSet<UserClaimInt> UserClaimsInt { get; set; }
        //public IDbSet<UserLoginInt> UserLoginsInt { get; set; }
        //public IDbSet<UserInt> UsersInt { get; set; }
        //public IDbSet<UserRoleInt> UserRolesInt { get; set; }
    }
}
