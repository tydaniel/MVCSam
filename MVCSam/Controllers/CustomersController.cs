using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MVCSam.Models;
using MVCSam.ViewModels;

namespace MVCSam.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           
            return View(customers);
        }


        public ActionResult New()
        {
            var membershiptype = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershiptype
            };
            return View("CustomerForm",newCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var customerViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            }; 

            return View("CustomerForm", customerViewModel);
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "John Smith" },
        //        new Customer { Id = 2, Name = "Mary Williams" }
        //    };
        //}
    }
}