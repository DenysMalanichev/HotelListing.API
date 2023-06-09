using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Contracts
{
	public interface IAuthManager
	{
		Task<IEnumerable<IdentityError>> RegisterUser(ApiUserDto userDto);
		Task<AuthResponseDto> Login(LoginUserDto userDto);
		Task<string> CreateRefreshToken();
		Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
	}
}
