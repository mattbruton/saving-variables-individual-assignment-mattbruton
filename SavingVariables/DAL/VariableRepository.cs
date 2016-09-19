using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingVariables.Models;

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
    }
}
