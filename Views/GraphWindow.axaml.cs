using Avalonia.Controls;
using GraphPractice;
using System;
using System.Collections.Generic;

namespace ADSAvaloniaPractice.Views
{
    public partial class GraphWindow : Window
    {
        Graph graph = new Graph();
        List<Node> listOfNodes = new List<Node>();
        public GraphWindow()
        {
            InitializeComponent();
        }
        void ReturnButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Show();
            this.Close();

        }
        void AddNode_Button(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Node node = new Node(graph);
            graph.insertNode(node);
            ConsoleUI.Content = "Node " + node.data + " successfully added";
        }
        void AddEdge_Button(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (StartNode_TextBox.Text == "" || EndNode_TextBox.Text == "" || Weight_TextBox.Text == "" || StartNode_TextBox.Text == null || EndNode_TextBox.Text == null || Weight_TextBox.Text == null)
            {
                ConsoleUI.Content = "For adding an edge, complete all the blank spaces.";
                return;
            }

            if (Int16.Parse(StartNode_TextBox.Text) == Int16.Parse(EndNode_TextBox.Text))
            {
                ConsoleUI.Content = "You cannot conect a node between itself.";
                return;
            }
            foreach (Edge edge in graph.edgesList)
            {
                if (Int16.Parse(StartNode_TextBox.Text) == edge.initialNode.data && Int16.Parse(EndNode_TextBox.Text) == edge.finalNode.data)
                {
                    ConsoleUI.Content = "You can't add two edges with the same start and end.";
                    return;
                }
            }
            foreach (Node node in graph.nodesList)
            {
                if(node.data == Int16.Parse(StartNode_TextBox.Text))
                {
                    foreach (Node node2 in graph.nodesList) 
                    {
                        if(node2.data == Int16.Parse(EndNode_TextBox.Text))
                        {
                            Edge edge = new Edge(node,node2, Int16.Parse(Weight_TextBox.Text));
                            graph.insertEdge(edge);
                            ConsoleUI.Content = "Edge "+node.data+ " to "+ node2.data + " successfully added";
                            return;
                        }
                    }
                    ConsoleUI.Content = "End node not found";
                    return;
                }
            }
            ConsoleUI.Content = "Start node not found";
        }
     
       
        void ShortestPathButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(Destiny_TextBox.Text == null)
            {
                ConsoleUI.Content = "Insert the node that you want to go.";
                return;
            }
            int[] shortPath = new int[10];
            String message= "Shortest path = ";

            for (int i = 0; i < graph.shortestPath.Length; i++)
            {
                graph.shortestPath[i] = 0;
            }
            
            for (int i = 0; i < graph.shortestPath.Length; i++)
            {
                graph.shortestPath[i] = 0;
            }

            foreach (Node node in graph.nodesList)
            {
                if(Int16.Parse(Destiny_TextBox.Text) == node.data)
                {
                    shortPath = graph.shortAlgorithmDefinitive2(graph.nodesList[0], node);
                    break;
                }
            }
            for(int i = 0; i < shortPath.Length; i++)
            {
                if(shortPath[i] != 0)
                {
                    message = message + shortPath[i] + " ";
                }
                
            }
            ConsoleUI.Content = message;
        }
       
        void LongestButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (LongDestiny_TextBox.Text == null)
            {
                ConsoleUI.Content = "Insert the node that you want to go.";
                return;
            }
            int[] longPath = new int[10];
            String message1 = "Longest path = ";
            for (int i = 0; i < graph.longestPath.Length; i++)
            {
                graph.longestPath[i] = 0;
            }

            for (int i = 0; i < graph.longestPath.Length; i++)
            {
                graph.longestPath[i] = 0;
            }
            foreach (Node node in graph.nodesList)
            {
                if (Int16.Parse(LongDestiny_TextBox.Text) == node.data)
                {
                    longPath = graph.longAlgorithmDefinitive2(graph.nodesList[0], node);
                    break;
                }
            }
            for (int i = 0; i < longPath.Length; i++)
            {
                if (longPath[i] != 0)
                {
                    message1 = message1 + longPath[i] + " ";
                }
            }
            ConsoleUI.Content = message1;
        }

    }
}
