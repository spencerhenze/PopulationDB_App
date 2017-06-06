using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 Spencer Henze
 ITM 225
 Kit Scott
 12/7/16
 Homework 10
 */

namespace PopulationDBApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'populationDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.populationDataSet.City);

        }

        private void popAscButton_Click(object sender, EventArgs e)
        {
            //When the button to sort by population ascending is clicked, this query is run and the result is loaded into the table.
            this.cityTableAdapter.FillByPopAsc(this.populationDataSet.City);
        }

        private void popDescButton_Click(object sender, EventArgs e)
        {
            //When the button to sort by population decending is clicked, this query is run and the result is loaded into the table.
            this.cityTableAdapter.FillByPopDesc(this.populationDataSet.City);
        }

        private void nameSortButton_Click(object sender, EventArgs e)
        {
            //When the button to sort by City Name is clicked, this query is run and the result is loaded into the table.
            this.cityTableAdapter.FillByCity(this.populationDataSet.City);
        }

        private void totalPopButton_Click(object sender, EventArgs e)
        {
            //When the button to get the total population is clicked, this query is run and the result is displayed in a message box.
            decimal totalPop; // make a variable to hold the result of the query (since the query returns a value rather than rows of a table)
            totalPop = (decimal)this.cityTableAdapter.Total();

            MessageBox.Show("The total population for all cities is: " + totalPop.ToString());
        }

        private void avgPopButton_Click(object sender, EventArgs e)
        {
            //When the button to get the average population is clicked, this query is run and the result is displayed in a message box.
            decimal avgPop; // make a variable to hold the result of the query (since the query returns a value rather than rows of a table)

            avgPop = (decimal)this.cityTableAdapter.AvgPop();

            MessageBox.Show("The average population for all cities is: " + avgPop.ToString());
        }

        private void highestPopButton_Click(object sender, EventArgs e)
        {
            //When the button to get the highest population is clicked, this query is run and the result is displayed in a message box.
            decimal highestPop = (decimal)this.cityTableAdapter.MaxPop(); // make a variable to hold the result of the query (since the query returns a value rather than rows of a table)
            string city = (string)this.cityTableAdapter.MaxPopCity();
            MessageBox.Show("The city with the highest population is " + city + " with a population of " + highestPop.ToString());

        }

        private void lowestPopButton_Click(object sender, EventArgs e)
        {
            //When the button to get the lowest population is clicked, this query is run and the result is displayed in a message box.
            decimal lowestPop = (decimal)this.cityTableAdapter.MinPop(); // make a variable to hold the result of the query (since the query returns a value rather than rows of a table)
            string city = (string)this.cityTableAdapter.MinPopCity();
            MessageBox.Show("The city with the lowest population is " + city + " with a population of " + lowestPop.ToString());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //The binding navigator bar did not have a save button. I added one along with this code which updates changes to the table once they have been entered and enter has been pressed.
            //Once the changes have been made, enter has been pressed, and this save button has been clicked, the operators will work with the updated data. 
            //All changes to the original database file are erased when the program exits. 
            cityTableAdapter.Update(populationDataSet.City);
        }
    }
}
