namespace WareItsMade.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "CountryId", c => c.String());
            AddColumn("dbo.AspNetUsers", "HomePage", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street2", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubdivisionId", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "SubdivisionId");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Street2");
            DropColumn("dbo.AspNetUsers", "Street1");
            DropColumn("dbo.AspNetUsers", "HomePage");
            DropColumn("dbo.AspNetUsers", "CountryId");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
