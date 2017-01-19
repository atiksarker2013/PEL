using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class ItemJournalRepository : Repository<ItemJournal>
    {
        public string GetMaxValue()
        {
            return DbSet.Max(x => x == null ? null : x.VoucherNo);
        }
    }
}