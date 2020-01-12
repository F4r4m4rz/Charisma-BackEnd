using Charisma.Core.Data;
using Charisma.Core.Model.Base;
using Charisma.Core.Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charisma.MVC.Models
{
    public class GenericMenuModel<T1, T2, T3> where T1 : class, ICharismaObject<T2> 
        where T2 : class, ICharismaObject<T3>
        where T3 : class
    {
        public readonly int id;
        public readonly int ownerId;
        public readonly IRepository<T1> repository;

        public T1 Owner { get; set; }
        public T2 ActiveSubType { get; set; }
        public List<T2> SubTypes { get; set; }

        public GenericMenuModel(IRepository<T1> repository, int ownerId)
        {
            this.repository = repository;
            this.ownerId = ownerId;
            Instanciate();
            SubTypes = Owner.Members;
        }

        public GenericMenuModel(IRepository<T1> repository, int id, int ownerId)
            : this(repository, ownerId)
        {
            this.id = id;
            GetActiveItem();
        }

        public void Instanciate()
        {
            Owner = repository.GetFull("Members")
                .Where(c => c.Id == ownerId)
                .Select(c => c)
                .FirstOrDefault();
        }

        public void GetActiveItem()
        {
            ActiveSubType = Owner.Members
                .Where(c => c.Id == id)
                .Select(c => c)
                .FirstOrDefault();
        }
    }
}
