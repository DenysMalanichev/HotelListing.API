using AutoMapper;
using HotelListing.API.Core.Contracts;
using HotelListing.API.Data;

namespace HotelListing.API.Core.Repository
{
	public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
	{
		private readonly HotelListingDbContext _context;

		public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper)
        {
			_context = context;
		}
        public async Task<Hotel> GetDetails(int id)
		{
			return await _context.Hotels.FindAsync(id);
		}
	}
}
