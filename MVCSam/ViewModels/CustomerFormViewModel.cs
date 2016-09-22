using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCSam.Models;

namespace MVCSam.ViewModels
{
    public class CustomerFormViewModel
    {
        
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}