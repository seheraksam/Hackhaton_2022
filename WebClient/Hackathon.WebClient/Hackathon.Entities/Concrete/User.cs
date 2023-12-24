using Hackathon.Entities.Concrete;
using Hackathon.Entities.Interface;
using Microsoft.AspNetCore.Identity;
using System.Data.Common;

namespace Hackathon.Entities.Concrete
{
    public class User:IdentityUser
    {
        public Profile? Profile { get; set; }
        public int ProfileId { get; set; }
        public int Balance { get; set; }
    }
}
