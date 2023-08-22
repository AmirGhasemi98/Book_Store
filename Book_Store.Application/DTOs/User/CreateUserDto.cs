using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.DTOs.User
{
    public class CreateUserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public byte[] Avatar { get; set; }
    }
}
