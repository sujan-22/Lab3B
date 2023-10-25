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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear all the ListBox items
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            // Reset the flag for hairdresser added
            hairdresserAdded = false;

            // Clear the TextBox
            textBox1.Clear();

            comboBox1 .Items.Clear();
            listBox1.SelectedIndex = -1;
        }

        private bool hairdresserAdded = false; // Add this field to track if the hairdresser has been added
        private void button1_Click(object sender, EventArgs e)
        {
            string selectedHairdresser = comboBox1.SelectedItem.ToString();

            List<string> services = new List<string>();
            foreach (var items in listBox1.SelectedItems)
            {
                services.Add(items.ToString());
            }


            decimal totalPrice = 0;

            string[] selectedHairdresserParts = selectedHairdresser.Split(' ');
            string firstName = selectedHairdresserParts[0]; // Extract the first name

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


            decimal servicePrice = 0;
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


            foreach (var service in services)
            {
                listBox2.Items.Add($"{service}");
            }

            listBox3.Items.Add($"${servicePrice}");

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal totalPrice = 0;

            foreach (var item in listBox3.Items)
            {
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
