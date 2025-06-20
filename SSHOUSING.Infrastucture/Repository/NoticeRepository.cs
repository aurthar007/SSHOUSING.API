using Microsoft.EntityFrameworkCore;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSHOUSING.Infrastructure.Repositories
{
    public class NoticeRepository : INotice
    {
        private readonly ApplicationDbContext _context;

        public NoticeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Notice>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Notice>>(_context.Notices.ToList());
        }

        public Task<Notice> AddAsync(Notice notice)
        {
            _context.Notices.Add(notice);
            _context.SaveChanges();
            return Task.FromResult(notice);
        }
    }
}
