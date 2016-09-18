using System.Data.Entity;
using SavingVariables.Models;

namespace SavingVariables.DAL
{
    //Context manages interaction with database and change tracking.
    public class VariableContext : DbContext
    {
        // Our lonely, single table in the model.
        public virtual DbSet<Variable> Variables { get; set; }
    }
}
