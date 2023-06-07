using HotelListing.API.Contracts;
using HotelListing.API.Data;

namespace HotelListing.API.Repository
{
	public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
	{
		private readonly HotelListingDbContext _context;

		public HotelsRepository(HotelListingDbContext context) : base(context)
        {
			_context = context;
		}
        public async Task<Hotel> GetDetails(int id)
		{
			return await _context.Hotels.FindAsync(id);
		}
	}
}
