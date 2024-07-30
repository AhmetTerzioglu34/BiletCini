using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class CityManager : BaseManager<City> ,ICityManager
    {
        readonly ICityRepository _cityRepository;
        public CityManager(ICityRepository cityRepository) : base(cityRepository) 
        {
            _cityRepository = cityRepository;
        }
    }
}
