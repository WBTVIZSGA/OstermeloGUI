using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ostermelo.Data.Models
{
    public partial class DeliveryModel: IModelWithId
    {
        public int Id { get; set; }
        public virtual JuiceModel Juice { get; set; } = null!;
        public virtual PartnerModel Partner { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int Pack { get; set; }

        public int JuiceId{ get; set; }
        public int PartnerId { get; set; }

        [NotMapped]
        public DateTime BindedDate
        {
            get => new DateTime(this.Date.Year, this.Date.Month, this.Date.Day);
            set => this.Date = DateOnly.FromDateTime(value);
        }
    }
}
