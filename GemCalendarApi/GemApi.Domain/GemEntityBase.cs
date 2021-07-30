using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemApi.Domain
{
    public class GemEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
