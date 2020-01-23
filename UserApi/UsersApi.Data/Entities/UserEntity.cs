using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsersApi.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
