using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using CompositeGUI.Data;
using System.Data.Entity;

namespace CompositeGUI
{
    public static class DB
    {
        public static Project CreateProject(string Name)
        {
            using (DataContext db = new DataContext())
            {
                Project p = db.Projects.Add(new Project() { Name = Name });
                Main.ProjectList.Add(p);
                db.SaveChanges();
                return p;
            }
        }

        public static List<Project> GetProjects()
        {
            using (DataContext db = new DataContext())
            {
                return db.Projects.OrderByDescending(p => p.ProjectId).ToList();
            }
        }

        public static Project GetProject(int id)
        {
            using (DataContext db = new DataContext())
            {
                Project project = db.Projects.Where(p => p.ProjectId == id)
                    .Include(p => p.Composites)
                    .Include(p => p.MatrixMaterial)
                    .Include(p => p.FiberMaterial)
                    .Include(p => p.Limits)
                    .Include(p => p.GA_Settings)
                    .FirstOrDefault();

                //project.Composites.OrderByDescending(c => c.ShieldingEfficiency);
                return project;
            }
        }

        public static Project EditProject(Project project)
        {
            using (DataContext db = new DataContext())
            {
                Project newP = db.Projects.FirstOrDefault(p => p.ProjectId == project.ProjectId);

                newP.Name = project.Name;
                newP.FiberMaterialId = project.FiberMaterialId;
                newP.MatrixMaterialId = project.MatrixMaterialId;
                newP.MinFrequency = project.MinFrequency;
                newP.MaxFrequency = project.MaxFrequency;
                newP.HasMetalGrid = project.HasMetalGrid;
                newP.LimitsId = project.LimitsId;
                newP.GaSettingsId = project.GaSettingsId;

                db.Entry(newP).State = EntityState.Modified;
                db.SaveChanges();
                return newP;
            }
        }

        public static List<Material> GetMaterials()
        {
            using (DataContext db = new DataContext())
            {
                return db.Materials.ToList();
            }
        }

        public static Material AddMaterial(Material material)
        {
            using (DataContext db = new DataContext())
            {
                Material m = db.Materials.Add(material);
                db.SaveChanges();
                return m;
            }
        }

        public static Material EditMaterial(Material material)
        {
            using (DataContext db = new DataContext())
            {
                Material newM = db.Materials.FirstOrDefault(m => m.MaterialId == material.MaterialId);

                newM.Name = material.Name;
                newM.ElecCond = material.ElecCond;
                newM.MagCond = material.MagCond;
                newM.ThermalCond = material.ThermalCond;
                newM.Density = material.Density;

                db.Entry(newM).State = EntityState.Modified;
                db.SaveChanges();
                return newM;
            }
        }

        public static void DeleteMaterial(int id)
        {
            using (DataContext db = new DataContext())
            {
                Material material = new Material() { MaterialId = id };
                foreach (Project p in db.Projects.Where(p => p.MatrixMaterialId == id))
                    p.MatrixMaterialId = null;

                foreach (Project p in db.Projects.Where(p => p.FiberMaterialId == id))
                    p.FiberMaterialId = null;

                db.Materials.Attach(material);
                db.Materials.Remove(material);
                db.SaveChanges();
            }
        }

        public static List<Limits> GetLimits()
        {
            using (DataContext db = new DataContext())
            {
                return db.Limits.ToList();
            }
        }

        public static Limits AddLimits(Limits limits)
        {
            using (DataContext db = new DataContext())
            {
                Limits l = db.Limits.Add(limits);
                db.SaveChanges();
                return l;
            }
        }

        public static Limits EditLimits(Limits limits)
        {
            using (DataContext db = new DataContext())
            {
                Limits newL = db.Limits.FirstOrDefault(l => l.LimitsId == limits.LimitsId);
                newL.MinLayerCount = limits.MinLayerCount;
                newL.MaxLayerCount = limits.MaxLayerCount;
                newL.MinFiberWidth = limits.MinFiberWidth;
                newL.MaxFiberWidth = limits.MaxFiberWidth;
                newL.MinFiberThickness = limits.MinFiberThickness;
                newL.MaxFiberThickness = limits.MaxFiberThickness;
                newL.MinFiberSpaceBetween = limits.MinFiberSpaceBetween;
                newL.MaxFiberSpaceBetween = limits.MaxFiberSpaceBetween;

                db.Entry(newL).State = EntityState.Modified;
                db.SaveChanges();
                return newL;
            }
        }

        public static void DeleteLimits(int id)
        {
            using (DataContext db = new DataContext())
            {
                Limits limits = new Limits() { LimitsId = id };
                foreach (Project p in db.Projects.Where(p => p.LimitsId == id))
                    p.LimitsId = null;

                db.Limits.Attach(limits);
                db.Limits.Remove(limits);
                db.SaveChanges();
            }
        }

        public static List<GA_Settings> GetGaSetings()
        {
            using (DataContext db = new DataContext())
            {
                return db.GA_Settings.ToList();
            }
        }

        public static GA_Settings AddGaSetings(GA_Settings settings)
        {
            using (DataContext db = new DataContext())
            {
                GA_Settings s = db.GA_Settings.Add(settings);
                db.SaveChanges();
                return s;
            }
        }

        public static GA_Settings EditGaSettings(GA_Settings settings)
        {
            using (DataContext db = new DataContext())
            {
                GA_Settings newS = db.GA_Settings.FirstOrDefault(l => l.GaSettingsId == settings.GaSettingsId);
                newS.PopulationSize = settings.PopulationSize;
                newS.MaxGenerations = settings.MaxGenerations;
                newS.SelectionTourneySize = settings.SelectionTourneySize;

                db.Entry(newS).State = EntityState.Modified;
                db.SaveChanges();
                return newS;
            }
        }

        public static void DeleteGaSettings(int id)
        {
            using (DataContext db = new DataContext())
            {
                GA_Settings settings = new GA_Settings() { GaSettingsId = id };
                foreach (Project p in db.Projects.Where(p => p.GaSettingsId == id))
                    p.GaSettingsId = null;

                db.GA_Settings.Attach(settings);
                db.GA_Settings.Remove(settings);
                db.SaveChanges();
            }
        }

        public static void SaveComposites(List<Composite> composites)
        {
            using (DataContext db = new DataContext())
            {
                db.Composites.AddRange(composites);
                db.SaveChanges();
            }
        }

        public static void DeleteProjectResults(int ProjectId)
        {
            using (DataContext db = new DataContext())
            {
                db.Composites.RemoveRange(db.Composites.Where(c => c.ProjectId == ProjectId));
                db.SaveChanges();
            }
        }

        public static List<CstResult> GetCompositeResults(int CompositeId)
        {
            using (DataContext db = new DataContext())
            {
                return db.CstResults.Where(r => r.CompositeId == CompositeId).ToList();
            }
        }

        public static void DeleteProject(int id)
        {
            using (DataContext db = new DataContext())
            {
                Project p = new Project() { ProjectId = id };

                db.Projects.Attach(p);
                db.Projects.Remove(p);
                db.SaveChanges();
            }
        }
    }
   
}
