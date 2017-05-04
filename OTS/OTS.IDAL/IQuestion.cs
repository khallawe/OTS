using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.IDAL
{
   public interface IQuestion
    {
        int Add(Question question);
        int Update(Question question);
        int Delete(int id);
        Question SelectOne(int id);
        List<Question> SelectAll();   
        List<Question> Search(string key);

        List<Question> SelectBySubInventory(int subinventoryId);
        List<Question> SelectByExam(int examID);



    }
}
