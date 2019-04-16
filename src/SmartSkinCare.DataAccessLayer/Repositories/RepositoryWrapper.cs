using System;
using SmartSkinCare.DataAccessLayer.Abstractions;

namespace SmartSkinCare.DataAccessLayer
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationContext _appContext;
        private ICreamRepository _creamRepository;
        private IHumidityRepository _humidityRepository;
        private IManufacturerRepository _manufacturerRepository;
        private IOilinessRepository _oilinessRepository;
        private IUserRepository _userRepository;

        public ICreamRepository CreamRepository
        {
            get
            {
                if (_creamRepository == null)
                {
                    _creamRepository = new CreamRepository(_appContext);
                }

                return _creamRepository;
            }
        }

        public IHumidityRepository HumidityRepository
        {
            get
            {
                if (_humidityRepository == null)
                {
                    _humidityRepository = new HumidityRepository(_appContext);
                }

                return _humidityRepository;
            }
        }

        public IManufacturerRepository ManufacturerRepository
        {
            get
            {
                if (_manufacturerRepository == null)
                {
                    _manufacturerRepository = new ManufacturerRepository(_appContext);
                }

                return _manufacturerRepository;
            }
        }

        public IOilinessRepository OilinessRepository
        {
            get
            {
                if (_oilinessRepository == null)
                {
                    _oilinessRepository = new OilinessRepository(_appContext);
                }

                return _oilinessRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_appContext);
                }

                return _userRepository;
            }
        }

        public RepositoryWrapper(ApplicationContext context,
            ICreamRepository creamRepository,
            IHumidityRepository humidityRepository,
            IManufacturerRepository manufacturerRepository,
            IOilinessRepository oilinessRepository,
            IUserRepository userRepository)
        {
            _appContext = context;
            _creamRepository = creamRepository;
            _humidityRepository = humidityRepository;
            _manufacturerRepository = manufacturerRepository;
            _oilinessRepository = oilinessRepository;
            _userRepository = userRepository;
        }

    }
}
