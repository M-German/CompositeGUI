namespace CompositeGUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Composites",
                c => new
                    {
                        CompositeId = c.Int(nullable: false, identity: true),
                        LayerCount = c.Int(nullable: false),
                        FiberWidth = c.Double(nullable: false),
                        FiberThickness = c.Double(nullable: false),
                        FiberSpaceBetween = c.Double(nullable: false),
                        ShieldingEfficiency = c.Double(nullable: false),
                        Diagrams = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompositeId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        HasMetalGrid = c.Boolean(nullable: false),
                        MinFrequency = c.Double(nullable: false),
                        MaxFrequency = c.Double(nullable: false),
                        Name = c.String(),
                        GaSettingsId = c.Int(),
                        MatrixMaterialId = c.Int(),
                        FiberMaterialId = c.Int(),
                        LimitsId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Materials", t => t.FiberMaterialId)
                .ForeignKey("dbo.GA_Settings", t => t.GaSettingsId)
                .ForeignKey("dbo.Limits", t => t.LimitsId)
                .ForeignKey("dbo.Materials", t => t.MatrixMaterialId)
                .Index(t => t.GaSettingsId)
                .Index(t => t.MatrixMaterialId)
                .Index(t => t.FiberMaterialId)
                .Index(t => t.LimitsId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ElecCond = c.Double(nullable: false),
                        MagCond = c.Double(nullable: false),
                        ThermalCond = c.Double(nullable: false),
                        Density = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.GA_Settings",
                c => new
                    {
                        GaSettingsId = c.Int(nullable: false, identity: true),
                        PopulationSize = c.Int(nullable: false),
                        MaxGenerations = c.Int(nullable: false),
                        SelectionTourneySize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GaSettingsId);
            
            CreateTable(
                "dbo.Limits",
                c => new
                    {
                        LimitsId = c.Int(nullable: false, identity: true),
                        MinLayerCount = c.Int(nullable: false),
                        MaxLayerCount = c.Int(nullable: false),
                        MinFiberWidth = c.Double(nullable: false),
                        MaxFiberWidth = c.Double(nullable: false),
                        MinFiberThickness = c.Double(nullable: false),
                        MaxFiberThickness = c.Double(nullable: false),
                        MinFiberSpaceBetween = c.Double(nullable: false),
                        MaxFiberSpaceBetween = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LimitsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "MatrixMaterialId", "dbo.Materials");
            DropForeignKey("dbo.Projects", "LimitsId", "dbo.Limits");
            DropForeignKey("dbo.Projects", "GaSettingsId", "dbo.GA_Settings");
            DropForeignKey("dbo.Projects", "FiberMaterialId", "dbo.Materials");
            DropForeignKey("dbo.Composites", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "LimitsId" });
            DropIndex("dbo.Projects", new[] { "FiberMaterialId" });
            DropIndex("dbo.Projects", new[] { "MatrixMaterialId" });
            DropIndex("dbo.Projects", new[] { "GaSettingsId" });
            DropIndex("dbo.Composites", new[] { "ProjectId" });
            DropTable("dbo.Limits");
            DropTable("dbo.GA_Settings");
            DropTable("dbo.Materials");
            DropTable("dbo.Projects");
            DropTable("dbo.Composites");
        }
    }
}
