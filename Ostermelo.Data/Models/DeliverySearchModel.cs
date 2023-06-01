using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostermelo.Data.Models
{
    public class DeliverySearchModel
    {
        public int? JuiceId { get; set; }
        public int? PartnerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
