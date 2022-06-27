using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Core.Models
{
    public class FestivalUpdateModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string TicketUrl { get; set; }
    }
}
