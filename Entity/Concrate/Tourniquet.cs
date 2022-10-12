using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrate
{
    public class Tourniquet : IEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime ExitDate { get; set; }
    }
}