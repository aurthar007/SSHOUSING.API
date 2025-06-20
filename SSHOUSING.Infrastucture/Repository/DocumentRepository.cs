using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace SSHOUSING.Infrastructure.Repositories
{
    public class DocumentRepository : IDocument
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Document> GetAll()
        {
            return _context.Documents.ToList();
        }

        public Document GetById(int id)
        {
            return _context.Documents.FirstOrDefault(d => d.Id == id);
        }

        public bool Add(Document document)
        {
            try
            {
                _context.Documents.Add(document);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var doc = _context.Documents.FirstOrDefault(d => d.Id == id);
            if (doc != null)
            {
                _context.Documents.Remove(doc);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
