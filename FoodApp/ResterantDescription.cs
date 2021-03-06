﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodApp
{
  
    public partial class ResterantDescription : Form
    {  
        public bool Favorites;
        private Resturants rests;
        private Form1 parentform;
        public ResterantDescription(Resturants rest,Form1 form)
        {
            InitializeComponent();
            rests = rest;
            descLB.Text = rest.Description;
            parentform = form;
            Show_Foods();
            Show_Hours();

           

            Favorites = rest.favorites;
            if (Favorites)
            {
                favorite.Image = global::FoodApp.Properties.Resources.starOn;
            }
            else if(!Favorites)
            {
                favorite.Image = global::FoodApp.Properties.Resources.star;
            }
            this.ShowDialog();
            
        }
        //Create Hour Labels
        private void Show_Hours()
        {
            string[] types = { "Breakfast", "Lunch", "Dinner" };
            int count = 0;
            AddLabel(550, 240 + (count * 20), "Opens at " + rests.Change_Time(rests.HourOpen));
            count++;
            foreach (string meal in types)
            {
                if (rests.Type.Contains(meal))
                {
                    AddLabel(550, 240 + (count * 20), rests.Time(meal));
                    count++;
                }
            }
            AddLabel(550, 240 + (count * 20), "Closes at " + rests.Change_Time(rests.HourClose));
        }

        //Creates all the food labels
        private void Show_Foods()
        {
            int count = 0;
            foreach (Foods food in rests.Menu)
            {
                

                AddLabel(200, 250 + (count * 20), "- "+food.Name+" : $"+food.Price);
                
                count++;
            }
        }
        //Adds a label for either the food or the hour
        private void AddLabel(int locx, int locy, string text)
        {
            
            Label newLabel = new System.Windows.Forms.Label();
            this.Controls.Add(newLabel);
            newLabel.AutoSize = true;
            newLabel.Location = new System.Drawing.Point(locx, locy);
            newLabel.Name = "label1";
            newLabel.Size = new System.Drawing.Size(46, 17);
            newLabel.TabIndex = 5;
            newLabel.Text = text;

        }
        //Closes this form and re-enables the parent form
        private void Exit_Click(object sender, EventArgs e)
        {
            parentform.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void favorite_Click(object sender, EventArgs e)
        {
            if (Favorites)
            {
                favorite.Image = global::FoodApp.Properties.Resources.star;
                rests.favorites = false;
                Favorites = false;
            }
            else if (!Favorites)
            {
                favorite.Image = global::FoodApp.Properties.Resources.starOn;
                rests.favorites = true;
                Favorites = true;
            }
        }
    }
}
