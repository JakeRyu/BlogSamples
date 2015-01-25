using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamperProof.Models
{
    public class UserRepository : IEnumerable<User>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<User> GetEnumerator()
        {
            return Users.GetEnumerator();
        }

        public List<User> Users
        {
            get
            {
                return new List<User>{
                    new User { Id = 1, Name = "Chris Mole", Salary = 50000},
                    new User { Id = 2, Name = "James Lloyd", Salary = 60000},
                    new User { Id = 3, Name = "Jake Ryu", Salary = 70000}
                };
            }
        }
    }
}