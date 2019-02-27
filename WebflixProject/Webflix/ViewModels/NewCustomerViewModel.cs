using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webflix.Models;

namespace Webflix.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}