using DrugManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugManagement.Data.Repositories
{
  public class DrugRepository
    {
        DmsContext dmsDbContext { get; set; }

        public DrugRepository()
        {
            this.dmsDbContext = new DmsContext();
        }

        public List<TblDrug> GetAllDrugs()
        {
            return this.dmsDbContext.TblDrugs.ToList();
        }

        public void AddDrug(TblDrug drug)
        {
            this.dmsDbContext.TblDrugs.Add(drug);
            this.dmsDbContext.SaveChanges();
        }

        public void DeleteDrug(int drugId)
        {
            var DrugNeedsToBeDeleted = this.dmsDbContext.TblDrugs.Where(d => d.Id == drugId).FirstOrDefault();
            if (DrugNeedsToBeDeleted != null)
            {
                this.dmsDbContext.Remove(DrugNeedsToBeDeleted);
                this.dmsDbContext.SaveChanges();
            }
        }


    }
}



