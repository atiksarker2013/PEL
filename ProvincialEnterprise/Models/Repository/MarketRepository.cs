using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class MarketRepository : Repository<Market>
    {
        public dynamic GetMarketingPeoples()
        {
            var markets = DbSet.Select(m => new
            {
                MarketId = m.MarketId,
                MarketName = m.MarketName,
                Contact = m.Contact,
                BranchId = m.BranchId,
                Branchname = m.Branch.Name
            }).ToList();

            return markets;
        }

        public dynamic GetMarketingPeoplesByBranch(int branchId)
        {
            var markets = DbSet.Where(x=> x.BranchId == branchId).Select(m => new
            {
                MarketId = m.MarketId,
                MarketName = m.MarketName,
                Contact = m.Contact,
                BranchId = m.BranchId,
                Branchname = m.Branch.Name
            }).ToList();

            return markets;
        }


        public dynamic GetMarketingPeopleById(int id)
        {
            var market = DbSet.Where(m => m.MarketId == id)
                .Select(x => new
                {
                    MarketId = x.MarketId,
                    MarketName = x.MarketName,
                    Contact = x.Contact,
                    BranchId = x.BranchId,
                    Branchname = x.Branch.Name
                });
            return market;
        }
        public bool GetDuplicate(int branchId,string name)
        {
            var market = DbSet.Where(c => c.MarketName.ToLower() == name.ToLower() && c.BranchId == branchId).FirstOrDefault();
            return (market != null) ? true : false;
        }
    }
}