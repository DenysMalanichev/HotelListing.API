using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Users
{
	public class ApiUserDto : LoginUserDto
	{
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }        
    }
}
