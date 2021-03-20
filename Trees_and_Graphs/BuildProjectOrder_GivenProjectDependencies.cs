using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    // Given a list of projects and a list of dependencies (which is  a list of pairs of projects, where the second project
    // is dependent on the first project). All of a project's dependencies must be build before the project is. Find a build 
    // order that will allow the projects to be built. If there is no valid build order, return an error.

    #region Project class
    public class Project
    {
        private List<Project> children = new List<Project>();
        private Dictionary<string, Project> dictionary = new Dictionary<string, Project>();
        private string name;
        private int dependencies;

        public Project(string _name)
        {
            name = _name;
        }

        public void AddNeighbor(Project node)
        {
            if (!dictionary.ContainsKey(node.GetName()))
            {
                children.Add(node);
                dictionary.Add(node.GetName(), node);
                node.IncrementDependencies();
            }
        
        }

        public void IncrementDependencies()
        {
            dependencies++;
        }

        public void DecrementDependencies()
        {
            dependencies--;
        }

        public string GetName()
        {
            return name;
        }

        public List<Project> GetChildren()
        {
            return children;
        }

        public int GetNumberDependencies()
        {
            return dependencies;
        }
    }

    #endregion

    #region Graph class

    public class Graph
    {
        private List<Project> nodes = new List<Project>();
        private Dictionary<string, Project> dictionary = new Dictionary<string, Project>();

        public Project GetOrCreateProject(string name)
        {

            if (!dictionary.ContainsKey(name))
            {
                Project newProject = new Project(name);
                nodes.Add(newProject);
                dictionary.Add(newProject.GetName(), newProject);
            }

            return dictionary[name];
        }

        public void AddEdge(string startName, string endName)
        {
            Project start = GetOrCreateProject(startName);
            Project end = GetOrCreateProject(endName);

            start.AddNeighbor(end);
        }

        public List<Project> GetNodes()
        {
            return nodes;
        }
    }

    #endregion

    #region BuildProjectOrderManager

    public class BuildProjectOrderManager
    {
        /* Find a correct build order */
        Project[] FindBuildOrder(string[] projects, string[][] dependencies)
        {

            Graph graphItem = BuildGraph(projects, dependencies);
            return OrderProjects(graphItem.GetNodes());
        }

        /* Build the graph, adding the edge (a,b) if b is dependent on a.
         * Assumes a pair is listed in "build order". The pair (a, b) in dependencies indicates
         * that b depends on a and a must be built before b.         
        */
        Graph BuildGraph(string[] projects, string[][] dependencies)
        {
            Graph graph = new Graph();

            foreach (string[] dependency in dependencies)
            {
                string first = dependency[0];
                string second = dependency[1];
                graph.AddEdge(first, second);
            }

            return graph;
        }

        /* Return a list of the projects in correct build order. */
        Project[] OrderProjects(List<Project> projects)
        {

            Project[] order = new Project[projects.Count];

            /* Add "roots" to the build order first */
            int endOfList = AddNonDependent(order, projects, 0);

            int toBeProcessed = 0;
            while (toBeProcessed < order.Count())
            {
                Project current = order[toBeProcessed];

                /* We have a circular dependency since there are no remaining projects with zero dependencies                 
                */
                if (current == null)
                {
                    return null;
                }

                /* Remove myself as  a dependency */
                List<Project> children = current.GetChildren();
                foreach (Project tempProject in children)
                {
                    tempProject.DecrementDependencies();
                }

                /* Add children that have no one depending on them */
                endOfList = AddNonDependent(order, children, endOfList);
                toBeProcessed++;
                           
            }

            return order;

            return null;
        }

        /* A helper function to insert projects with zero dependencies into the order
            array, starting at index offset. 
        */
        private int AddNonDependent(Project[] order, List<Project> projects, int offset)
        {

            foreach (Project projectItem in projects)
            {
                if (projectItem.GetNumberDependencies() == 0)
                {
                    order[offset] = projectItem;
                    offset++;
                }
            }

            return offset;
        }
    }


    #endregion
}
