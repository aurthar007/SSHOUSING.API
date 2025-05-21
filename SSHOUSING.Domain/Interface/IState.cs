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
        List<State> GetAllState();
        State GetStateById(int Id);
        bool AddState(State state);
        bool DeleteState(int Id);
        bool UpdateState(State state);
    }
}
