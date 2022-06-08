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
                return db.Projects.ToList();
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
    }
   
}
