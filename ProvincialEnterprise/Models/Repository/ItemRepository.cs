using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class ItemRepository : Repository<Item>
    {
        public dynamic GetItems()
        {
            var items = DbSet.Select(i => new
            {
                ItemId = i.ItemId,
                ItemName = i.ItemName,
                BranchId = i.BranchId
            }).ToList();

            return items;
        }

        public dynamic GetItemById(int id)
        {
            var item = DbSet.Where(i => i.ItemId == id).Select(i => new
            {
                ItemId = i.ItemId,
                ItemName = i.ItemName,
                BranchId = i.BranchId
            }).FirstOrDefault();

            return item;
        }

        public dynamic GetItemsByBranch(int id)
        {
            var items = DbSet.Where(i => i.BranchId == id).Select(i => new
            {
                ItemId = i.ItemId,
                ItemName = i.ItemName,
                BranchId = i.BranchId
            }).ToList();

            return items;
        }
        public Item GetById(int id)
        {
            Item item = DbSet.Where(m => m.ItemId == id).FirstOrDefault();
            return item;
        }
        public bool GetDuplicate(int branchId,string name)
        {
            var item = DbSet.Where(c => c.ItemName.ToLower() == name.ToLower() && c.BranchId == branchId).FirstOrDefault();
            return (item != null) ? true : false;
        }
    }
}