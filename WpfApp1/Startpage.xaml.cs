﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace seabattle
{
  
    public partial class Window1 : Window
    {
        Window SeaBattle = null;
        Random RND = new Random();
        List<Button> Buttons;
        public Window1(Window SeaBattle)
        {
            
            InitializeComponent();
            Buttons = new List<Button>();
            this.SeaBattle = SeaBattle;
            foreach (var item in grid.Children)
            {

                if (item is Grid)
                {
                    foreach (var child1 in (item as Grid).Children)
                    {
                        if (item is Grid)
                        {
                            foreach (var child in (item as Grid).Children)
                            {

                                if (child is Button)
                                {
                                    if ((child as Button).Tag.ToString() != "0")
                                    {
                                        Buttons.Add(child as Button);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            DDD();
        }

        public void DDD()
        {
            int i = 20;
            while (i!=0)
            {

           
                int Shot = RND.Next(0, 100);
                if (Buttons[Shot].Tag.ToString() == "false")
                {

                    Buttons[Shot].Template = Resources["ButtonWound"] as ControlTemplate;
                }
                else { Buttons[Shot].Template = Resources["ButtonShot"] as ControlTemplate; }
                
                i--;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            SeaBattle.ShowDialog();
        }
    }
}
