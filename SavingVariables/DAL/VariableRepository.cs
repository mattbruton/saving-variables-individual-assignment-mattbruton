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

        public void AddVariable(string variable, int value)
        {
            Variable new_var = new Variable { Name = variable.ToLower(), Value = value };
            Context.Variables.Add(new_var);
            Context.SaveChanges();
        }

        public Variable FindVariableByName(string name)
        {
            Variable relevant_variable = Context.Variables.FirstOrDefault(v => v.Name == name.ToLower());
            return relevant_variable;
        }

        public void RemoveAllVariables()
        {
            List<Variable> all_variables = GetVariables();

            foreach (Variable variable in all_variables)
            {
                RemoveVariable(variable.Name.ToLower());
            }

            Context.SaveChanges();
        }

        public void RemoveVariable(string name)
        {
            Variable variable_to_remove = FindVariableByName(name);
            Context.Variables.Remove(variable_to_remove);
            Context.SaveChanges();
        }
    }
}
