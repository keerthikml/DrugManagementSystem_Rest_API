using DrugManagementSystemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private static List<Supplier> suppliers = new List<Supplier>()
        {
            new Supplier
            {
                 Name = "John",
                 SupplierId = 101,
                 Address = "Mysore",
                 Company = "xyz"
            },
            new Supplier
            {
                 Name = "Mathew",
                 SupplierId = 201,
                 Address = "Banglore",
                 Company = "uvw"
            }
        };

        [HttpGet]
        public List<Supplier> GetAllSuppliers()
        {
            return suppliers;
        }

        [HttpPost]
        public void AddSupplier(Supplier supplier)
        {
            suppliers.Add(supplier);
        }

        [HttpDelete("{SupplierId:int}")]
        public void DeleteSupplier(int SupplierId)
        {
            var SupplierToBeDeleted = suppliers.Where(s => s.SupplierId == SupplierId).FirstOrDefault();
            suppliers.Remove(SupplierToBeDeleted);
        }

        [HttpGet("{SupplierId:int}")]
        public Supplier RetriewSupplier(int SupplierId)
        {
            var SupplierToBeDisplayed = suppliers.Where(s => s.SupplierId == SupplierId).FirstOrDefault();
            return SupplierToBeDisplayed;
        }
    }
}

