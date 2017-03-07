using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFLSuite.DataContracts.Entities;
using System.Data.Entity;
using CFLSuite.DataContracts;

namespace CFLSuite.Data
{
    public class ThrowTypeAccessor
    {
        public List<ThrowType> GetThrowTypes()
        {
            var result = new List<ThrowType>();
            using (var db = new CFLSuiteDB())
            {
                result = db.ThrowTypes.ToList();
            }

            return result;
        }

        public ThrowType SaveThrowType(ThrowType model)
        {
            model.ValidateModel();
            ThrowType result = null;
            using (var db = new CFLSuiteDB())
            {
                var dup = db.ThrowTypes.FirstOrDefault(x => x.Description == model.Description && x.ThrowTypeID != model.ThrowTypeID);
                if(dup == null)
                {
                    if(model.ThrowTypeID > 0)
                    {
                        db.ThrowTypes.Attach(model);
                        db.Entry(model).State = EntityState.Modified;
                    }
                    else
                    {
                        db.ThrowTypes.Add(model);
                    }
                }
                else
                {
                    throw new Exception("This throw already exists");
                }

                db.SaveChanges();
                result = model;
            }

            return result;
        }
    }
}
