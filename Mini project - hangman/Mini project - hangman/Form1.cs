using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace Mini_project___hangman
{
    public partial class Form1 : Form
    {
        //add all properties of images together
        private Bitmap [] hangImages = { Mini_project___hangman.Properties.Resources.Untitled_1, Mini_project___hangman.Properties.Resources.Untitled_2, Mini_project___hangman.Properties.Resources.Untitled_3,
                                        Mini_project___hangman.Properties.Resources.Untitled_4, Mini_project___hangman.Properties.Resources.Untitled_5, Mini_project___hangman.Properties.Resources.Untitled_6,
                                        Mini_project___hangman.Properties.Resources.Untitled_7, Mini_project___hangman.Properties.Resources.Untitled_8};
            //assing private int to wring guesses
            private int wrongGuesses = 0;
            private string current = "";
            private string copyCurrent = "";
            private string[] words;
            private string lblShowWord;
            string Text;
            private string filePath = @"C:\Mini_project-hangman\Mini_project-hangman\bin\Debug\words.csv";


        /*  private static Scoreboard scoreboard = new Scoreboard();
         private static readonly string[] Words = new string[] { "computer", "programmer", "software", "debugger", "compiler",
         "developer", "algorithm", "array", "method", "variable"}; */

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
           
        }


     private void loadwords()
    {
        char[] delimiterChars = {','};
        string[] readText = File.ReadAllLines(filePath);
        words = new string[readText.Length];
        int index = 0;
        foreach (string s in readText)
        {
            string[] line = s.Split(delimiterChars);
            words[index++] = line[0]; 
        }
          //  int end = 0;
    } 

    private void SetupWordChoice()
        {
            //making a guess
            wrongGuesses = 0;
            hangImage1.Image = hangImages[wrongGuesses];
            int guessIndex = (new Random()).Next(words.Length); //generates random number for the words 
            current = words[guessIndex];

            //make a copy of a guess
            copyCurrent = "";
            for(int index=0; index < current.Length; index++)
            {
                copyCurrent += "_";
            }
             displayCopy();

        }
        //display to the label above function
        private void displayCopy()
        {
            //copyCurrent = "_";
            for (int index = 0; index < copyCurrent.Length; index++)
            {
                lblShowWord.Text += copyCurrent.Substring(index,1);
                lblShowWord.Text += " ";
            }
        }

        private void updateCopy(char guess)
        {

        } 
        //all alphabet buttons are linked to this part.
        private void buttonA_Click(object sender, EventArgs e)
        {
            wrongGuesses++;
            if (wrongGuesses <= 7)
            {
                hangImage1.Image = hangImages[wrongGuesses];
            }
            else 
            {
                labelResult.Text = "You Lose!";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadwords();
            SetupWordChoice();
        }
    }
}
