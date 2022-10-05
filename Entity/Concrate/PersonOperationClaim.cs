using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate
{
    public class PersonOperationClaim
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ClaimId { get; set; }
    }
}