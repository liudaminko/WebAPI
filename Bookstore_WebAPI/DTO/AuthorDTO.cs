﻿namespace Bookstore_WebAPI.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Biography { get; set; }
    }
}
