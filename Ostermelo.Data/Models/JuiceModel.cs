using System;
using System.Collections.Generic;

namespace Ostermelo.Data.Models
{
    public partial class JuiceModel: IModelWithId
    {
        public JuiceModel()
        {
            Deliveries = new HashSet<DeliveryModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DeliveryModel> Deliveries { get; set; }
    }
}
