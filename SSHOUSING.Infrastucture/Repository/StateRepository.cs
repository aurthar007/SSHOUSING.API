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

        public bool Add(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var state = _context.States.Find(id);
            if (state == null) return false;

            _context.States.Remove(state);
            _context.SaveChanges();
            return true;
        }

        public List<State> GetAll()
        {
            return _context.States.ToList();
        }

        public State GetById(int id)
        {
            return _context.States.Find(id);
        }

          public bool Update(State state)
        {
            _context.States.Update(state);
            _context.SaveChanges();
            return true;
        }

    }

}
