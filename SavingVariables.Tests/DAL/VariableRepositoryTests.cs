using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavingVariables.Models;
using Moq;
using System.Data.Entity;
using SavingVariables.DAL;
using System.Collections.Generic;
using System.Linq;

namespace SavingVariables.Tests.DAL
{
    [TestClass]
    public class VariableRepositoryTests
    {
        Mock<VariableContext> mock_context { get; set; }
        Mock<DbSet<Variable>> mock_variable_table { get; set; }
        List<Variable> variable_list { get; set; }
        VariableRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = variable_list.AsQueryable();

            mock_variable_table.As<IQueryable<Variable>>().Setup(x => x.Provider).Returns(queryable_list.Provider);
            mock_variable_table.As<IQueryable<Variable>>().Setup(x => x.Expression).Returns(queryable_list.Expression);
            mock_variable_table.As<IQueryable<Variable>>().Setup(x => x.ElementType).Returns(queryable_list.ElementType);
            mock_variable_table.As<IQueryable<Variable>>().Setup(x => x.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(x => x.Variables).Returns(mock_variable_table.Object);

            mock_variable_table.Setup(t => t.Add(It.IsAny<Variable>())).Callback((Variable v) => variable_list.Add(v));
            mock_variable_table.Setup(t => t.Remove(It.IsAny<Variable>())).Callback((Variable v) => variable_list.Remove(v));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<VariableContext>();
            mock_variable_table = new Mock<DbSet<Variable>>();
            variable_list = new List<Variable>(); // Fake
            repo = new VariableRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null; 
        }

        [TestMethod]
        public void RepoEnsureRepoCanBeInstantiated()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoHasContext()
        {
            VariableContext expected_context = repo.Context;
            Assert.IsInstanceOfType(expected_context, typeof(VariableContext));
        }

        [TestMethod]
        public void RepoEnsureNoVariablesStoredByDefault()
        {
            List<Variable> actual_variables = repo.GetVariables();

            int expected_variable_count = 0;
            int actual_variable_count = actual_variables.Count;

            Assert.AreEqual(expected_variable_count, actual_variable_count);
        }

        [TestMethod]
        public void RepoEnsureRepoCanAddVariablesToDb()
        {
            repo.AddVariable("a", 2);

            int actual_variable_count = repo.GetVariables().Count;
            int expected_variable_count = 1;

            Assert.AreEqual(expected_variable_count, actual_variable_count);
        }

        [TestMethod]
        public void RepoEnsureRepoCanAddMultipleVariables()
        {
            repo.AddVariable("a", 2);
            repo.AddVariable("b", 3);
            repo.AddVariable("c", 4);

            int actual_variable_count = repo.GetVariables().Count;
            int expected_variable_count = 3;

            Assert.AreEqual(expected_variable_count, actual_variable_count);
        }

        [TestMethod]
        public void RepoEnsureRepoCanFindSingleVariableByName()
        {
            variable_list.Add(new Variable { Id = 1, Name = "a", Value = 2 });
            variable_list.Add(new Variable { Id = 2, Name = "b", Value = 2 });
            variable_list.Add(new Variable { Id = 3, Name = "c", Value = 2 });

            Variable actual_variable = repo.FindVariableByName("b");
            int actual_variable_id = actual_variable.Id;
            int expected_variable_id = 2;

            Assert.AreEqual(expected_variable_id, actual_variable_id);
        }

        [TestMethod]
        public void RepoEnsureRepoCanRemoveAllVariables()
        {
            variable_list.Add(new Variable { Id = 1, Name = "a", Value = 2 });
            variable_list.Add(new Variable { Id = 2, Name = "b", Value = 2 });
            variable_list.Add(new Variable { Id = 3, Name = "c", Value = 2 });

            repo.RemoveAllVariables();
            int actual_variable_count = repo.GetVariables().Count;
            int expected_variable_count = 0;

            Assert.AreEqual(expected_variable_count, actual_variable_count);
        }


        // need to test:
        // remove single item

        // think of more fringe case scenarios
    }
}
