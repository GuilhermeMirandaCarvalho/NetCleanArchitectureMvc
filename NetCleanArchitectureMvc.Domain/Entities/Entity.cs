using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCleanArchitectureMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
       /* public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }*/

    }
}
