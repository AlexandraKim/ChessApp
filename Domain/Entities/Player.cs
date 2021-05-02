using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Rank { get; set; }

        public int MyProperty { get; set; }
    }
}
