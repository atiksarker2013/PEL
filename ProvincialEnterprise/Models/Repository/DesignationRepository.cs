using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class DesignationRepository : Repository<Designation>
    {
        public dynamic GetDesignations()
        {
            var designations = DbSet.Select(a => new
            {
                DesignationId = a.DesignationId,
                Name = a.Name,
                GradeId = a.GradeId,
                SectionId = a.SectionId,
                SectionName = a.Section.Name
            }).ToList();

            return designations;
        }

        public dynamic GetDesignationsBySection(int sectionId)
        {
            var designations = DbSet.Where(x => x.SectionId == sectionId).Select(a => new
            {
                DesignationId = a.DesignationId,
                Name = a.Name,
                GradeId = a.GradeId,
                SectionId = a.SectionId,
                SectionName = a.Section.Name
            }).ToList();

            return designations;
        }


        public dynamic GetDesignationById(int id)
        {
            var designation = DbSet.Where(d => d.DesignationId == id)
                .Select(x => new
                {
                    DesignationId = x.DesignationId,
                    Name = x.Name,
                    GradeId = x.GradeId,
                    SectionId = x.SectionId
                });
            return designation;
        }
        public bool GetDuplicate(int sectionId,string name)
        {
            var designation = DbSet.Where(c => c.Name.ToLower() == name.ToLower() && c.SectionId == sectionId).FirstOrDefault();
            return (designation != null) ? true : false;
        }
    }
}