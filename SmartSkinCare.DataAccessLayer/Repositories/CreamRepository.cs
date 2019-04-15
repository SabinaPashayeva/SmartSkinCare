using System;
using System.Linq;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.DataAccessLayer
{
    public class CreamRepository : RepositoryBase<Cream>, ICreamRepository
    {
        public CreamRepository(ApplicationContext context)
            : base(context)
        { }

        public override void Delete(Cream entity)
        {
            base.Delete(FindByCondition(c => c.CreamId == entity.CreamId).FirstOrDefault());
        }
    }
}
