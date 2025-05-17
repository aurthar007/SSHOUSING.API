using SSHOUSING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Domain.Interface
{
    public interface IState
    {
        List<State> GetAll();
        State GetById(int id);
        bool Add(State state);
        bool Update(State state);
        bool Delete(int id);
    }
}
