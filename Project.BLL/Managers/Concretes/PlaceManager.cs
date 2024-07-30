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
    public class PlaceManager : BaseManager<Place>, IPlaceManager
    {
        readonly IPlaceRepository _placeRepository;
        public PlaceManager(IPlaceRepository placeRepository) : base(placeRepository) 
        {
            _placeRepository = placeRepository;
        }
    }
}
