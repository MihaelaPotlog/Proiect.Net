using Projects.Domain;
using Projects.Domain.Repositories;
using System;

namespace ProjectRepositoryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * -- verify add project method --
             * 
             * var projectContext = new ProjectsContext();

             Guid id = Guid.NewGuid();
             var proj = new ProjectRepository(projectContext);
             var p = proj.Add(id, "PROIECT2", "dkjhkjhs", "end", new string[2] { "Java", "c++" });

             Console.WriteLine(p.Name, p.OwnerId);*/

            /* 
             *  -- verify Update and GetAll project method --
             *  
             * var projectContext = new ProjectsContext();
             var proj = new ProjectRepository(projectContext);

             var p = proj.GetAll();
             Console.WriteLine( p[0].Id);
             var project = p[0];
             project.Name = "SALUT";


             var vfproj =  proj.Update(project);

             Console.WriteLine(vfproj.Name);

             

            
            //-- verify delete method --

            var projectContext = new ProjectsContext();
            var proj = new ProjectRepository(projectContext);

            var p = proj.GetAll();
            var project = p[0];

            Guid newguid = new Guid();
            var rasp = proj.Delete(newguid);

            Console.WriteLine(rasp); 

            // -- verify public List<Project> Get_Projects_By_State(string projectState) --


            var projectContext = new ProjectsContext();
            var proj = new ProjectRepository(projectContext);

            var projectsList = proj.Get_Projects_By_State("start");

            Console.WriteLine(projectsList[0].Name); */



        }
    }
}
