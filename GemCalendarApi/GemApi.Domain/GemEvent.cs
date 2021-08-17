﻿using System;

namespace GemApi.Domain
{
    public class GemEvent : GemEntityBase
    {
        public virtual int GemEventCategoryId { get; set; } 
        public virtual GemEventCategory GemEventCategory { get; set; }
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
    }
}
