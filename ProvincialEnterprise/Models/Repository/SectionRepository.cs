using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class SectionRepository : Repository<Section>
    {
        public dynamic GetSections()
        {
            var sections = DbSet.Select(s => new
            {
                SectionId = s.SectionId,
                Name = s.Name,
                BranchId = s.BranchId,
                BranchName = s.Branch.Name
            }).ToList();

            return sections;
        }

        public dynamic GetSectionsByBranch(int branchId)
        {
            var sections = DbSet.Where(x=>x.BranchId == branchId).Select(s => new
            {
                SectionId = s.SectionId,
                Name = s.Name,
                BranchId = s.BranchId,
                BranchName = s.Branch.Name
            }).ToList();

            return sections;
        }

        public dynamic GetSectionById(int id)
        {
            var section = DbSet.Where(s => s.SectionId == id)
                .Select(x => new
                {
                    SectionId = x.SectionId,
                    Name = x.Name,
                    BranchId = x.BranchId
                });
            return section;
        }
        public bool GetDuplicate(int branchId,string name)
        {
            var section = DbSet.Where(c => c.Name.ToLower() == name.ToLower() && c.BranchId == branchId).FirstOrDefault();
            return (section != null) ? true : false;
        }
    }
}