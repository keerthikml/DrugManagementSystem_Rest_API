using DrugManagementSystemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrugManagement.Data.Entities;
using DrugManagement.Data.Repositories;

namespace DrugManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        public DrugRepository DrugRepository { get; set; }
        public DrugController()
        {
            this.DrugRepository = new DrugRepository();
        }


        [HttpGet]
        public List<TblDrug> GetAllDrugs()    //Converting c# object to json is called serialization
        {
            return this.DrugRepository.GetAllDrugs();
        }

        [HttpPost]
        public void AddDrug(Drug drug)  //Converting json to c# object is called Deserialization
        {
            TblDrug tblDrug = new TblDrug();
            tblDrug.SupplierId = 1;
            tblDrug.SerialNumber = drug.SerialNumber;
            tblDrug.Name = drug.Name;
            tblDrug.ExpiryDate = drug.ExpiredDate;
            this.DrugRepository.AddDrug(tblDrug);
        }
        [HttpDelete]
        public void DeleteDrug(int DrugID)
        {
            this.DrugRepository.DeleteDrug(DrugID);

        }

        [HttpGet("{DrugID:int}")]

        public Drug GetDrug(int DrugID)
        {
            //var DrugToBeDisplayed = dmsContext.Where(d => d.Id == DrugID).FirstOrDefault();
            return new Drug();

        }
    }

}

