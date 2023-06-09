﻿using HotelListing.API.Core.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Core.Contracts
{
	public interface IAuthManager
	{
		Task<IEnumerable<IdentityError>> RegisterUser(ApiUserDto userDto);
		Task<IEnumerable<IdentityError>> RegisterAdmin(ApiUserDto userDto);
		Task<AuthResponseDto> Login(LoginUserDto userDto);
		Task<string> CreateRefreshToken();
		Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
	}
}
