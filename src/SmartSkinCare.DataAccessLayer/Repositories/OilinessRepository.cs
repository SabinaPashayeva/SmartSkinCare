using System;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.DataAccessLayer
{
    public class OilinessRepository : RepositoryBase<SkinOiliness>, IOilinessRepository
    {
        public OilinessRepository(ApplicationContext context)
            : base(context)
        { }
    }
}
