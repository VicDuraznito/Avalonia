using Avalonia.Controls;
using System;
using System.Collections.Generic;
using TreePactice;

namespace ADSAvaloniaPractice.Views
{
    public partial class Window1 : Window
    {
        List<Node> listOfNodes = new List<Node>();
        public Window1()
        {
            InitializeComponent();
            listOfNodes.Add(new Node(1));
            Console.WriteLine("teste");
        }
        void ReturnButton_Clicked (object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Show();
            this.Close();
        }
        void AddButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            bool check = true;

            if (Father_TextBox.Text == null || Father_TextBox.Text == "")
            {
                ConsoleUI.Content = "You need to select a father node to add a new node.";
                return;
            }
            if (NewNode_TextBox.Text == null || NewNode_TextBox.Text == "")
            {
                ConsoleUI.Content = "You need to insert a new node into the text box if you want to create a new node.";
                return;
            }

            Node node = new Node(Int16.Parse(NewNode_TextBox.Text));
            
            foreach (Node node2 in listOfNodes)
            {
                if(Int16.Parse(NewNode_TextBox.Text) == node2.data)
                {
                    ConsoleUI.Content = "The new node already exists.";
                    return;
                }
                
            }
            foreach (Node node2 in listOfNodes)
            {
                if (Int16.Parse(Father_TextBox.Text) == node2.data)
                {
                    if (0 == Position_ComboBox.SelectedIndex)
                    {
                        if(node2.elementLeft != null)
                        {
                            ConsoleUI.Content = "Left element of father have already a node.";
                            return;
                        }
                    }
                    else
                    {
                        if (node2.elementRight != null)
                        {
                            ConsoleUI.Content = "Right element of father have already a node.";
                            return;
                        }
                    }
                }

            }

            foreach (Node node2 in listOfNodes)
            {
                if (node2.data == Int16.Parse(Father_TextBox.Text))
                {
                    
                    if (0 == Position_ComboBox.SelectedIndex)
                    {
                        
                        listOfNodes.Add(node);
                        node2.Insert(node);
                        ConsoleUI.Content = "Node "+ NewNode_TextBox.Text + " successfully added to left of " + Father_TextBox.Text;
                        break;
                    }
                    else
                    {
                        listOfNodes.Add(node);
                        node2.Insert(node,"right");

                        ConsoleUI.Content = "Node "+ NewNode_TextBox.Text +" successfully added to right of " + Father_TextBox.Text;
                        break;
                    }
                    
                }
            }

        }
        void DeleteButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(1 == Int16.Parse(DeleteSelectNode_TextBox.Text))
            {
                ConsoleUI.Content = "You cannot delete the main node.";
                return;
            }
            foreach(Node node in listOfNodes)
            {
                if(node.data == Int16.Parse(DeleteSelectNode_TextBox.Text))
                {
                    ConsoleUI.Content = "Node " + node.data + " successfully deleted.";
                    listOfNodes[0].RemoveDefinitive(node);
                    
                    listOfNodes.Remove(node);
                    
                    return;
                }
            }
            ConsoleUI.Content = "Node that you tried to erase not found.";

        }
        void HeightButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            height_label.Content = listOfNodes[0].HeightWithReturn();
            if("0" == height_label.Content.ToString())
            {
                height_label.Content = "1";
            }
        }
        void TransverseButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            int?[] list1 = new int?[15];
            for(int i = 0; i < list1.Length; i++)
            {
                list1[i] = 0;
            }
            String save = "Transversed tree: (";

            if (Transverse_ComboBox.SelectedIndex == 0)
            {
                list1 = listOfNodes[0].TransverseDefinitive("inorder");

            } 
            else if (Transverse_ComboBox.SelectedIndex == 1)
            {
                list1 = listOfNodes[0].TransverseDefinitive("preorder");
            }
            else
            {
                list1 = listOfNodes[0].TransverseDefinitive("postorder");
            }

            for (int i = 0; i < list1.Length; i++)
            {
                if (list1[i] != null)
                {
                    if (i == 0)
                    {
                        save = save + list1[i];
                    }
                    else
                    {
                        save = save + ", " + list1[i];
                    }
                }
            }
            save = save + ")";
            ConsoleUI.Content = save;
        }
        void SearchButton_Clicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (listOfNodes[0].SearchWithReturn2(Int16.Parse(Search_TextBox.Text)) == true)
            {
                ConsoleUI.Content = "Node " + Search_TextBox.Text + " IS on the tree.";
            }
            else
            {
                ConsoleUI.Content = "Node " + Search_TextBox.Text + " IS NOT on the tree.";
            }
        }
    }
}
