using System.Collections.Generic;

namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    #region Main Class
    class BuildListProjectOrder_UsingDFS
    {

        Stack<Project> FindBuildOrder(string[] projects, string[][] dependencies)
        {
            Graph graph = BuildGraph(projects, dependencies);
            return OrderProjects(graph.GetNodes());
        }

        private Stack<Project> OrderProjects(List<Project> projects)
        {
            Stack<Project> stackProjects = new Stack<Project>();
            foreach (Project projectItem in projects)
            {
                if (projectItem.GetState() == NodeState.BLANK)
                {
                    if (!DoDepthFirstSearch(projectItem, stackProjects))
                    {
                        return null;
                    }
                }
            }

            return stackProjects;
        }

        bool DoDepthFirstSearch(Project project, Stack<Project> stackProjects)
        {
            if (project.GetState() == NodeState.PARTIAL)
            {
                return false; // Cycle
            }

            if (project.GetState() == NodeState.BLANK)
            {
                project.SetState(NodeState.PARTIAL);
                List<Project> children = project.GetChildren();
                foreach (Project child in children)
                {
                    if (!DoDepthFirstSearch(child, stackProjects))
                    {
                        return false;
                    }
                }

                project.SetState(NodeState.COMPLETE);
                stackProjects.Push(project);
            }

            return true;
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

    #region Project class

    public enum NodeState {  COMPLETE, PARTIAL, BLANK };
    
    public class Project
    {
        private List<Project> children = new List<Project>();
        private Dictionary<string, Project> dictionary = new Dictionary<string, Project>();
        private string name;
        private NodeState nodeState = NodeState.BLANK;


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
            }
        }

        public NodeState GetState()
        {
            return nodeState;
        }

        public void SetState(NodeState newState)
        {
            nodeState = newState;
        }

        public string GetName()
        {
            return name;
        }

        public List<Project> GetChildren()
        {
            return children;
        }
   }

    #endregion

}
