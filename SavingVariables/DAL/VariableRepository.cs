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
            List<Variable> relevant_variables = Context.Variables.ToList();

            foreach(Variable variable in relevant_variables)
            {
                if(variable.Name == name)
                {
                    return variable;
                }
            }
            return null;
        }

        public void RemoveAllVariables()
        {
            List<Variable> all_variables = Context.Variables.ToList();

            foreach (Variable variable in all_variables)
            {
                Context.Variables.Remove(variable);
            }
            Context.SaveChanges();
        }

        public void RemoveVariable(string name)
        {
            List<Variable> all_variables = Context.Variables.ToList();

            foreach(Variable variable in all_variables)
            {
                if (variable.Name.Contains(name))
                {
                    Context.Variables.Remove(variable);
                    Context.SaveChanges();
                }
            }
        }
    }
}
