using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradingForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }



       
        // Function to calculate symbol based on average
        private char CalculateSymbol(double average)
        {
            if (average >= 75)
                return 'A';
            else if (average >= 70)
                return 'B';
            else if (average >= 60)
                return 'C';
            else if (average >= 50)
                return 'D';
            else
                return 'E';
        }

       
        // TRANSFER MARKS BUTTON: Adds mark to the listbox
        private void transfer_Click_1(object sender, EventArgs e)
        {
            try
            {
                int mark = int.Parse(textBoxMark.Text); // Get the mark from the TextBox
                if (mark >= 0 && mark <= 100) // Validate mark between 0 and 100
                {
                    listBoxMarks.Items.Add(mark); // Add mark to ListBox
                    textBoxMark.Clear(); // Clear input box
                }
                else
                {
                    MessageBox.Show("Please enter a mark between 0 and 100.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.");
            }
        }
        // PROCESS MARKS BUTTON: Calculate average, highest mark, and determine symbol
        private void processmarks_Click_1(object sender, EventArgs e)
        {
            if (listBoxMarks.Items.Count > 0)
            {
                int total = 0;
                int highest = int.Parse(listBoxMarks.Items[0].ToString()); // Start with the first mark as highest
                for (int i = 0; i < listBoxMarks.Items.Count; i++)
                {
                    int mark = int.Parse(listBoxMarks.Items[i].ToString()); // Get the mark from the ListBox
                    total += mark;

                    if (mark > highest) // Find highest mark
                    {
                        highest = mark;
                    }
                }

                double average = (double)total / listBoxMarks.Items.Count; // Calculate average
                char symbol = CalculateSymbol(average); // Get the symbol

                // Now pass these values to Form2 on the SUMMARY button click.
            }
            else
            {
                MessageBox.Show("No marks to process. Please enter marks first.");
            }
        }
        // SUMMARY BUTTON: Open Form2 and pass data
        private void summary_Click_1(object sender, EventArgs e)
        {
            double average = CalculateAverage(); // Get the average mark
            int highest = FindHighest();         // Get the highest mark
            char symbol = CalculateSymbol(average); // Get the symbol for the average

            Form2 form2 = new Form2(average, highest, symbol);
            form2.Show(); // Show Form2 with the passed data
        }

        private double CalculateAverage()
        {
            int total = 0;
            for (int i = 0; i < listBoxMarks.Items.Count; i++)
            {
                int mark = int.Parse(listBoxMarks.Items[i].ToString());
                total += mark;
            }
            return (double)total / listBoxMarks.Items.Count;
        }

        // Helper method to find the highest mark
        private int FindHighest()
        {
            int highest = int.Parse(listBoxMarks.Items[0].ToString());
            for (int i = 1; i < listBoxMarks.Items.Count; i++)
            {
                int mark = int.Parse(listBoxMarks.Items[i].ToString());
                if (mark > highest)
                {
                    highest = mark;
                }
            }
            return highest;
        }
    }

}
