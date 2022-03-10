using System;

namespace Instagram.HttpMessages.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string ProfileUrl { get; set; }
        public DateTime RegisterAt { get; set; }
        public bool IsActive { get; set; }
    }
}
