using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIT.Models.Repository
{
    public class UnitRepository : Repository<Unit>
    {
        public dynamic GetUnits()
        {
            var units = DbSet.OrderBy(u => u.UnitId).Select(u => new
                {
                    u.UnitId,
                    u.UnitName,
                    u.BranchId,
                }).ToList();
            return units;        
        }

        public dynamic GetUnitById(int unitId)
        {
            var unit = DbSet.Where(u => u.UnitId == unitId).Select(u => new
                {
                    u.UnitId,
                    u.UnitName,
                    u.BranchId,
                });
            return unit;
        }

        //public bool GetDuplicateUnit(string uname, int branchId)
        //{
        //    var units = DbSet.OrderBy(u => u.UnitId).ToList();
        //    foreach (Unit u in units)
        //    {
        //        if (u.UnitName == uname && u.BranchId==branchId)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public bool GetDuplicateUnit(string uname, int branchId)
        {
            var units = DbSet.Where(c => c.UnitName.ToLower() == uname.ToLower() && c.BranchId == branchId).FirstOrDefault();
            return (units != null) ? true : false;
        }
    }
}