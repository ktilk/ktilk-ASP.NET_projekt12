namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetitionID = c.Int(nullable: false, identity: true),
                        CompetitionName = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(),
                    })
                .PrimaryKey(t => t.CompetitionID);
            
            CreateTable(
                "dbo.Participations",
                c => new
                    {
                        ParticipationID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        CompetitionID = c.Int(nullable: false),
                        Score = c.Int(),
                    })
                .PrimaryKey(t => t.ParticipationID)
                .ForeignKey("dbo.Competitions", t => t.CompetitionID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.CompetitionID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Height = c.Int(),
                        Weight = c.Int(),
                        BirthDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        ContactTypeID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.ContactTypeID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeID = c.Int(nullable: false, identity: true),
                        ContactTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ContactTypeID);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanID = c.Int(nullable: false, identity: true),
                        PlanName = c.String(),
                        Rating = c.Int(),
                        Description = c.String(),
                        Instructions = c.String(),
                        PlanTypeID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateClosed = c.DateTime(),
                        Duration = c.String(),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanID)
                .ForeignKey("dbo.PlanTypes", t => t.PlanTypeID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PlanTypeID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.PlanTypes",
                c => new
                    {
                        PlanTypeID = c.Int(nullable: false, identity: true),
                        PlanTypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PlanTypeID);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        WorkoutID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Duration = c.String(),
                        PlanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkoutID)
                .ForeignKey("dbo.Plans", t => t.PlanID, cascadeDelete: true)
                .Index(t => t.PlanID);
            
            CreateTable(
                "dbo.ExerciseInWorkouts",
                c => new
                    {
                        ExerciseInWorkoutID = c.Int(nullable: false, identity: true),
                        ExerciseID = c.Int(nullable: false),
                        WorkoutID = c.Int(nullable: false),
                        Sets = c.Int(),
                        Repetitions = c.Int(),
                        Time = c.Int(),
                        Weight = c.Int(),
                    })
                .PrimaryKey(t => t.ExerciseInWorkoutID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseID, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => t.WorkoutID, cascadeDelete: true)
                .Index(t => t.ExerciseID)
                .Index(t => t.WorkoutID);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false, identity: true),
                        ExerciseTypeID = c.Int(nullable: false),
                        ExerciseName = c.String(),
                        Description = c.String(),
                        Instructions = c.String(),
                        VideoUrl = c.String(),
                        Rating = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseID)
                .ForeignKey("dbo.ExerciseTypes", t => t.ExerciseTypeID, cascadeDelete: true)
                .Index(t => t.ExerciseTypeID);
            
            CreateTable(
                "dbo.ExerciseTypes",
                c => new
                    {
                        ExerciseTypeID = c.Int(nullable: false, identity: true),
                        ExerciseTypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExerciseTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "PersonID", "dbo.People");
            DropForeignKey("dbo.Workouts", "PlanID", "dbo.Plans");
            DropForeignKey("dbo.ExerciseInWorkouts", "WorkoutID", "dbo.Workouts");
            DropForeignKey("dbo.Exercises", "ExerciseTypeID", "dbo.ExerciseTypes");
            DropForeignKey("dbo.ExerciseInWorkouts", "ExerciseID", "dbo.Exercises");
            DropForeignKey("dbo.Plans", "PlanTypeID", "dbo.PlanTypes");
            DropForeignKey("dbo.Participations", "PersonID", "dbo.People");
            DropForeignKey("dbo.Contacts", "PersonID", "dbo.People");
            DropForeignKey("dbo.Contacts", "ContactTypeID", "dbo.ContactTypes");
            DropForeignKey("dbo.Participations", "CompetitionID", "dbo.Competitions");
            DropIndex("dbo.Exercises", new[] { "ExerciseTypeID" });
            DropIndex("dbo.ExerciseInWorkouts", new[] { "WorkoutID" });
            DropIndex("dbo.ExerciseInWorkouts", new[] { "ExerciseID" });
            DropIndex("dbo.Workouts", new[] { "PlanID" });
            DropIndex("dbo.Plans", new[] { "PersonID" });
            DropIndex("dbo.Plans", new[] { "PlanTypeID" });
            DropIndex("dbo.Contacts", new[] { "PersonID" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeID" });
            DropIndex("dbo.Participations", new[] { "CompetitionID" });
            DropIndex("dbo.Participations", new[] { "PersonID" });
            DropTable("dbo.ExerciseTypes");
            DropTable("dbo.Exercises");
            DropTable("dbo.ExerciseInWorkouts");
            DropTable("dbo.Workouts");
            DropTable("dbo.PlanTypes");
            DropTable("dbo.Plans");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.People");
            DropTable("dbo.Participations");
            DropTable("dbo.Competitions");
        }
    }
}
