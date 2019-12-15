using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects.Domain;
using Projects.Domain.Repositories;
using System;

namespace ProjectRepositoryTests
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
                var projectContext = new ProjectsContext();

                Guid id = Guid.NewGuid();
                var proj = new ProjectRepository(projectContext);
                var p = proj.CreateProject(id, "PROIECTNOU", "dsadsaasdas", "start", new string[2] { "Java", "c++" });

            Console.WriteLine(p.Name, p.OwnerId);
        }
        
    }
}

