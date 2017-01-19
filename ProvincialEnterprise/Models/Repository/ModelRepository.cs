using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace ProvincialEnterprise.Models.Repository
{
    public class ModelRepository : Repository<Model>
    {
        public dynamic GetModels()
        {
            var models = DbSet.Select(m => new
            {
                ModelId = m.ModelId,
                ItemId = m.ItemId,
                ItemName = m.Item.ItemName,
                ModelName = m.ModelName,
                Price = m.Price,
                Qty = m.Qty,
                SalePrice = m.SalePrice,
                ReorderQty = m.ReorderQty,
                IsWarrenty = m.IsWarranty,
                AvgCost = m.AvgCost,
                BranchId = m.BranchId,
                BranchName = m.Branch.Name
            }).ToList();

            return models;
        }

        public dynamic GetModelById(int id)
        {
            var model = DbSet.Where(x => x.ModelId == id).Select(m => new
            {
                ModelId = m.ModelId,
                ItemId = m.ItemId,
                ItemName = m.Item.ItemName,
                ModelName = m.ModelName,
                Price = m.Price,
                Qty = m.Qty,
                SalePrice = m.SalePrice,
                ReorderQty = m.ReorderQty,
                IsWarrenty = m.IsWarranty,
                AvgCost = m.AvgCost,
                BranchId = m.BranchId,
                BranchName = m.Branch.Name
            }).FirstOrDefault();


            return model;
        }

        public Model GetById(int id)
        {
            return DbSet.Where(x => x.ModelId == id).FirstOrDefault();
        }
        public bool GetDuplicate(int itemId,string name)
        {
            var modelName = DbSet.Where(c => c.ModelName.ToLower() == name.ToLower() && c.ItemId == itemId).FirstOrDefault();
            return (modelName != null) ? true : false;
        }
    }
}