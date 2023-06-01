using System;
using System.Collections.Generic;

namespace Ostermelo.Data.Models
{
    public partial class PartnerModel: IModelWithId
    {
        public PartnerModel()
        {
            Deliveries = new HashSet<DeliveryModel>();
        }

        public int Id { get; set; }
        public string Contact { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual ICollection<DeliveryModel> Deliveries { get; set; }

        public string Name => $"{City} ({Contact})";
    }
}
