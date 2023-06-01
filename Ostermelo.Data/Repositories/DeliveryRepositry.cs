using Microsoft.EntityFrameworkCore;
using Ostermelo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostermelo.Data.Repositories
{
    public class DeliveryRepositry: GenericRepository<DeliveryModel>
    {
        public IEnumerable<DeliveryModel> Search(DeliverySearchModel searchModel)
        {
            return this.dbContext.Set<DeliveryModel>()
                                 .Include(d => d.Juice)
                                 .Include(d => d.Partner)
                                 .Where(d =>    (searchModel.JuiceId == null || d.JuiceId == searchModel.JuiceId)
                                             && (searchModel.PartnerId == null || d.PartnerId == searchModel.PartnerId)
                                             && (searchModel.FromDate == null || d.Date >= DateOnly.FromDateTime((DateTime)searchModel.FromDate))
                                             && (searchModel.ToDate == null || d.Date <= DateOnly.FromDateTime((DateTime)searchModel.ToDate))
                                       );
        }

        public override DeliveryModel Insert(DeliveryModel model)
        {
            if (dbContext.Set<DeliveryModel>().Any())
            {
                var maxId = dbContext.Set<DeliveryModel>().Max(d => d.Id);
                model.Id = maxId + 1;
            }
            else
            {
                model.Id = 1;
            }
            dbContext.Set<DeliveryModel>().Add(model);
            dbContext.SaveChanges();
            return this.dbContext.Set<DeliveryModel>()
                                 .Include(d => d.Juice)
                                 .Include(d => d.Partner)
                                 .First(d => d.Id == model.Id);

        }
    }
}

