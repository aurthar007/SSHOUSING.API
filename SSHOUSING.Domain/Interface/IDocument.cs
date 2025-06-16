using SSHOUSING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Interface
{
    public interface IDocument
    {
        IEnumerable<Document> GetAll();
        Document GetById(int id);
        bool Add(Document document);    // Returns true if add is successful
        bool Delete(int id);            // Returns true if delete is successful
    }
}