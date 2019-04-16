using System;
namespace SmartSkinCare.DataAccessLayer.Abstractions
{
    public interface IRepositoryWrapper
    {
        ICreamRepository CreamRepository { get; }
        IHumidityRepository HumidityRepository { get; }
        IManufacturerRepository ManufacturerRepository { get; }
        IOilinessRepository OilinessRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
