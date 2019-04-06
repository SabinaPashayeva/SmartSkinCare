using System;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.DataAccessLayer
{
    public class CreamRepository : RepositoryBase<Cream>, ICreamRepository
    {
        public CreamRepository(ApplicationContext context)
            : base(context)
        { }
    }
}
