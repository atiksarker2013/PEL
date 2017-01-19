using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class PaymentModeRepository : Repository<PaymentMode>
    {
        public dynamic GetAllPaymentMode()
        {
            var paymentModes = DbSet.Select(p => new
            {
                PaymentModeId = p.PaymentModeId,
                PaymentType = p.PaymentType
            }).ToList();

            return paymentModes;
        }
    }
}