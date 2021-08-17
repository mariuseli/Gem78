using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemApi.Application.Common.Models
{
    public class GemEventDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GemEventName { get; set; }
        public string GemEventDescription { get; set; }
        public string GemEventUrl { get; set; }
        public string GemEventLocation { get; set; }
        public string GemEventImage { get; set; }
        //public byte[] GemEventImage { get; set; }
        public string RawData { get; set; }
        public bool IsAllDayLong { get; set; }

    public Domain.GemEvent ToDb()
    {
            return new Domain.GemEvent
            {
                CreatedOn = DateTime.Now,
                EndDate = this.EndDate,
                GemEventDescription = this.GemEventDescription,
                GemEventImage = this.GemEventImage,
                GemEventLocation = this.GemEventLocation,
                GemEventName = this.GemEventName,
                GemEventUrl = this.GemEventUrl,
                IsAllDayLong = this.IsAllDayLong,
                RawData = this.RawData,
                StartDate = this.StartDate
            };
    }
    }
}
