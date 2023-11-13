/*
Class:                  Form1.cs
Author:                 Sujan Rokad
Date:                   October 26, 2023
Authorship statement:   I, Sujan Rokad, 000882948 certify that this material is my original work. No other person's work has been used without due acknowledgement.

Purpose: This class represents the main form of the Hair Salon Pricing Calculator application. It provides a graphical user interface (GUI) for users to select a hairdresser, one or more services, and calculate the total price for the salon services. Users can also reset their selections and exit the application.

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Group of methods related to event handlers and form initialization


        /// <summary>
        /// Handles the form's Load event and initializes button states.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            addServices.Enabled = false; // Disable Add Service button
            button2.Enabled = false; // Disable Calculate button
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the "Reset" button's click event and resets selections and controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Clear all ListBox items
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            // Reset the flag for hairdresser added
            hairdresserAdded = false;

            // Clear the TextBox
            textBox1.Clear();

            // Reset the selected index of the ComboBox
            comboBox1.SelectedIndex = 0;

            // Reset the selected indices of the ListBox
            listBox1.SelectedIndex = -1;

            // Disable "Add Service" button
            addServices.Enabled = false;

            // Disable "Calculate" button
            button2.Enabled = false;
        }



        private bool hairdresserAdded = false; // Add this field to track if the hairdresser has been added
        /// <summary>
        /// Handles the "Add Service" button's click event, calculates prices, and displays results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected hairdresser from the ComboBox
            string selectedHairdresser = comboBox1.SelectedItem.ToString();

            // Create a list to store selected services from the ListBox
            List<string> services = new List<string>();

            foreach (var items in listBox1.SelectedItems)
            {
                services.Add(items.ToString());
            }

            // Initialize the total price
            decimal totalPrice = 0;

            // Extract the first name of the selected hairdresser
            string[] selectedHairdresserParts = selectedHairdresser.Split(' ');
            string firstName = selectedHairdresserParts[0]; // Extract the first name

            // Calculate the base price based on the selected hairdresser
            if (firstName == "Jane")
            {
                totalPrice = 30;
            }
            else if (firstName == "Pat")
            {
                totalPrice = 45;
            }
            else if (firstName == "Ron")
            {
                totalPrice = 40;
            }
            else if (firstName == "Sue")
            {
                totalPrice = 50;
            }
            else if (firstName == "Laurie")
            {
                totalPrice = 55;
            }

            // Initialize the service price
            decimal servicePrice = 0;

            // Calculate the price for each selected service
            foreach (var service in services)
            {
                switch (service)
                {
                    case "Cut":
                        servicePrice += 30;
                        break;
                    case "Wash, blow-dry, and style":
                        servicePrice += 20;
                        break;
                    case "Colour":
                        servicePrice += 40;
                        break;
                    case "Highlights":
                        servicePrice += 50;
                        break;
                    case "Extensions":
                        servicePrice += 200;
                        break;
                    case "Up-do":
                        servicePrice += 60;
                        break;
                }
            }

            // Display the selected hairdresser and their price in the ListBox2 and ListBox3
            if (!hairdresserAdded)
            {
                listBox2.Items.Add($"{selectedHairdresser}:");
                listBox3.Items.Add($"${totalPrice}");
                hairdresserAdded = true; // Set the flag to true to indicate that it has been added
            }

            // Display the selected services in ListBox2
            foreach (var service in services)
            {
                listBox2.Items.Add($"{service}");
            }

            // Display the service price in ListBox3
            listBox3.Items.Add($"${servicePrice}");

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Handles the ListBox1's SelectedIndexChanged event. It enables "Add Service" and "Calculate" buttons based on selections.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if at least one item is selected in listBox1
            if (listBox1.SelectedItems.Count > 0)
            {
                addServices.Enabled = true; // Enables Add Service button
                button2.Enabled = true; // Enables Calculate button
            }

        }

        /// <summary>
        /// Handles the "Calculate" button's click event, calculates the total price based on the items in ListBox3, and displays it in textBox1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // Initialize the total price
            decimal totalPrice = 0;

            // Iterate through items in ListBox3 to calculate the total price
            foreach (var item in listBox3.Items)
            {
                // Check if the item is a string and starts with a '$' character
                if (item is string itemString && itemString.StartsWith("$"))
                {
                    // Extract the price value (remove the '$' character and parse as decimal)
                    if (decimal.TryParse(itemString.Substring(1), out decimal price))
                    {
                        totalPrice += price;
                    }
                }
            }

            // Display the total price in textBox1
            textBox1.Text = $"${totalPrice}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        } 
    }
}
