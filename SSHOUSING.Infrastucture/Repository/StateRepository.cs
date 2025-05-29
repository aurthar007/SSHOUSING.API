using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHOUSING.Infrastucture.Repository
{
    public class StateRepository : IState
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddState(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteState(int Id)
        {
            var state = _context.States.Find(Id);
            if (state == null)
                return false; 

            _context.States.Remove(state);
            _context.SaveChanges();
            return true;
        }

        public List<State> GetAllState()
        {
            return _context.States.ToList();
        }

        public State GetStateById(int Id)
        {
            return _context.States.Find(Id);
        }

        public bool UpdateState(State state)
        {
            _context.States.Update(state);
            _context.SaveChanges();
            return true;
        }
    }
}
