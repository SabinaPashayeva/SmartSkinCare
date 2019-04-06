using System;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.DataAccessLayer
{
    public class HumidityRepository : RepositoryBase<SkinHumidity>, IHumidityRepository
    {
        public HumidityRepository(ApplicationContext context)
            : base(context)
        { }
    }
}
