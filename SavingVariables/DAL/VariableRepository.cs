using SavingVariables.Models;
using System.Collections.Generic;
using System.Linq;

namespace SavingVariables.DAL
{
    public class VariableRepository
    {
        public VariableContext Context { get; set; }
        public VariableRepository()
        {
            Context = new VariableContext();
        }
        public VariableRepository(VariableContext _context)
        {
            Context = _context;
        }

        public List<Variable> GetVariables()
        {
            return Context.Variables.ToList();
        }
    }
}
