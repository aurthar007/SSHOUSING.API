using SSHOUSING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Interface
{
    public interface INotice
    {
        Task<IEnumerable<Notice>> GetAllAsync();
        Task<Notice> AddAsync(Notice notice);
    }
}
