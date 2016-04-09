namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratsioon1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Competitions", "CompetitionName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Contacts", "Value", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ContactTypes", "ContactTypeName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Exercises", "VideoUrl", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "VideoUrl", c => c.String());
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String());
            AlterColumn("dbo.ContactTypes", "ContactTypeName", c => c.String());
            AlterColumn("dbo.Contacts", "Value", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            AlterColumn("dbo.Competitions", "CompetitionName", c => c.String());
        }
    }
}
