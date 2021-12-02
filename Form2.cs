using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string lstBoxLine1 = "80 Watt LED Flood Light, 10,560 Lumens";
            string lstBoxLine2 = "150 Watt LED Flood Light, 21,000 Lumens";
            string lstBoxLine3 = "200 Watt LED Area Light, 28,000 Lumens";
            //Add string to listbox
            listBox1.Items.Add(lstBoxLine1);
            listBox1.Items.Add(lstBoxLine2);
            listBox1.Items.Add(lstBoxLine3);            
            textBox2.Visible = false;
            label1.Text = "Enter the side of the square";
            //label2.Text = "Enter the height of the rectangle";
        }
        private void SquareRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //making textBox2 visibility false
            textBox2.Visible = false;
            //setting label1.Text
            label1.Text = "Enter the side of the square";
            //making label2 visibility false
            label2.Visible = false;
            // making empty textBox1.Text, textBox2.Text and ReusultLabel.Text
            textBox1.Text = "";
            textBox2.Text = "";
            //Clear listbox selection
            listBox1.ClearSelected();
        }

        private void RectangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //making textBox1 visibility true
            textBox1.Visible = true;
            //making textBox2 visibility true
            textBox2.Visible = true;
            //setting label1.Text
            label1.Text = "Enter the length of the rectangle";
            //setting label2.Text
            label2.Text = "Enter the height of the rectangle";
            //making label1 visibility true
            label1.Visible = true;
            //making label2 visibility true
            label2.Visible = true;
            //Clear listbox selection
            listBox1.ClearSelected();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // making empty textBox1.Text, textBox2.Text
            textBox1.Text = "";
            textBox2.Text = "";
            //making checked property false for RectangleRadioButton and SquareRadioButton
            RectangleRadioButton.Checked = false;
            SquareRadioButton.Checked = false;
            listBox1.ClearSelected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //declaring variable length as integer
            int length;
            //declaring variable width as integer
            int width;
            //declaring variable area as integer
            float area = 0;
            //declaring variable side as integer
            int side;
            //checking SquareRadioButton checked or not
            if (SquareRadioButton.Checked)
            {
                //Convert to int and check if value entered by the user is a number
                bool validSideValue = int.TryParse(textBox1.Text, out side);
                if (!validSideValue)
                {
                    MessageBox.Show("Invalid entry for side of square.Only numbers are allowed", "Entry Error");
                    // making empty textBox1.Text, textBox2.Text and ReusultLabel.Text
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else if (listBox1.SelectedIndex <= -1)
                {
                    MessageBox.Show("Select the lumens to calculate the number of fixtures", "Entry Error");
                }
                else
                {
                    //if checked, assigning textBox1.Text value to variable size
                    //side = Convert.ToInt32(textBox1.Text);
                    //calculating area by multiplying side * side
                    area = side * side;
                    //showing result in the message box
                    MessageBox.Show("Area of Square is: " + Convert.ToString(area));
                    calculateLumens(area);
                }

            }
            else if (RectangleRadioButton.Checked)
            {
                bool validLengthValue = int.TryParse(textBox1.Text, out length);
                bool validHeightValue = int.TryParse(textBox2.Text, out width);
                if (!validLengthValue)
                {
                    MessageBox.Show("Invalid entry for length of rectangle.Only numbers are allowed", "Entry Error");
                    // making empty textBox1.Text, textBox2.Text and ReusultLabel.Text
                    textBox1.Text = "";
                }
                else if (!validHeightValue)
                {
                    MessageBox.Show("Invalid entry for width of rectangle.Only numbers are allowed", "Entry Error");
                    // making empty textBox1.Text, textBox2.Text and ReusultLabel.Text
                    textBox2.Text = "";
                }
                else if (listBox1.SelectedIndex <= -1)
                {
                    MessageBox.Show("Select the lumens to calculate the number of fixtures", "Entry Error");
                    
                }
                else
                {
                    //if RectangleRadioButton checked
                    //assigning textBox1.Text to variable length
                    //length = Convert.ToInt32(textBox1.Text);
                    //assigning textBox1.Text to variable width
                    //width = Convert.ToInt32(textBox2.Text);
                    //calculating area by multiplying length with width
                    area = length * width;
                    //showing result in the ReusultLabel label
                    MessageBox.Show("Area of Rectangle is: " + Convert.ToString(area));
                    calculateLumens(area);

                }

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Function to calculate the fixture
        private void calculateLumens(float area)
        {
            string selectedLumensText = listBox1.GetItemText(listBox1.SelectedItem);
            string[] splitLumensText = selectedLumensText.Split(' ');
            string lumenValue = splitLumensText[5];
            float lumens = 0;
            float candleLumens = 0;
            float recomendlumens = 0;
            float numFix = 0;
            int numFixInt = 0;
            lumenValue = lumenValue.Replace(",", "");
            float.TryParse(textBox1.Text, out lumens);
            if (area != 0)
            {
                candleLumens = (lumens / area);
            }
            else
            {
                candleLumens = 0;
            }
          ///recomended candle lumens is 1.5 for outdoor lighting
            recomendlumens = (float)(1.50 * area);

            numFix = candleLumens / recomendlumens;
            //numFixInt = (int)Math.Ceiling(numFix);
            string outString = String.Format("Recommended Lumens = {0}, Number of Fixtures = {1}", recomendlumens, numFix);
            MessageBox.Show(outString, "Calculation Results");

            

        }

        private void RectangleRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}