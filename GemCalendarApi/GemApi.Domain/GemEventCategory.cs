using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemApi.Domain
{
    public class GemEventCategory : GemEntityBase
    {
        public string CategoryName { get; set; }
        public string CatogoryColor { get; set; }
        public List<GemEvent> GemEvents { get; private set; }
    }
}
