using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cryptographic_Assistant
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadCiphertext_Click(object sender, EventArgs e)
        {
            Stream s = null;
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (d.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((s = d.OpenFile()) != null)
                    {
                        textBoxCiphertext.Text = File.ReadAllText(d.FileName, Encoding.UTF8);
                        analyzeData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void buttonETAOIN_Click(object sender, EventArgs e)
        {

        }

        private void buttonCustomFrequency_Click(object sender, EventArgs e)
        {

        }

        private void buttonClearCiphertext_Click(object sender, EventArgs e)
        {
            textBoxCiphertext.Text = "";
        }

        private void buttonClearPlaintext_Click(object sender, EventArgs e)
        {
            textBoxPlaintext.Text = "";
        }

        private void buttonCalculatePlaintext_Click(object sender, EventArgs e)
        {
            analyzeData();
        }

        private void analyzeData()
        {
            if(textBoxCiphertext.Text == "")
            {
                MessageBox.Show("No Ciphertext!");
                return;
            }
            //a list that contains each letter in ciphertext and its # of occurrences
            //sorted by which occurs most frequently
            List<KeyValuePair<char, int>> l = parseCiphertext();

            //an array list that specifies which frequency mapping we are using
            ArrayList a = useEtaoin();

            //TODO, move through frequency mapping and sorted ciphertext frequencies
            //to determine the letter mapping
        }

        //function that counts the number of occurrences of letters in a given ciphertext
        private List<KeyValuePair<char, int>> parseCiphertext()
        {
            String s = textBoxCiphertext.Text;
            SortedDictionary<char, int> d = new SortedDictionary<char, int>();

            //count occurrences of each letter and store in a dictionary
            d.Add('E', s.Split('E').Length - 1);
            d.Add('T', s.Split('T').Length - 1);
            d.Add('A', s.Split('A').Length - 1);
            d.Add('O', s.Split('O').Length - 1);
            d.Add('I', s.Split('I').Length - 1);
            d.Add('N', s.Split('N').Length - 1);
            d.Add('S', s.Split('S').Length - 1);
            d.Add('H', s.Split('H').Length - 1);
            d.Add('R', s.Split('R').Length - 1);
            d.Add('D', s.Split('D').Length - 1);
            d.Add('L', s.Split('L').Length - 1);
            d.Add('U', s.Split('U').Length - 1);
            d.Add('C', s.Split('C').Length - 1);
            d.Add('M', s.Split('M').Length - 1);
            d.Add('F', s.Split('F').Length - 1);
            d.Add('W', s.Split('W').Length - 1);
            d.Add('Y', s.Split('Y').Length - 1);
            d.Add('P', s.Split('P').Length - 1);
            d.Add('V', s.Split('V').Length - 1);
            d.Add('B', s.Split('B').Length - 1);
            d.Add('G', s.Split('G').Length - 1);
            d.Add('K', s.Split('K').Length - 1);
            d.Add('J', s.Split('J').Length - 1);
            d.Add('Q', s.Split('Q').Length - 1);
            d.Add('X', s.Split('X').Length - 1);
            d.Add('Z', s.Split('Z').Length - 1);

            //the dictionary sorts on key, so we need to re-sort it by value
            List<KeyValuePair<char, int>> l = d.ToList();

            l.Sort(
                delegate (KeyValuePair<char, int> pair1,
                KeyValuePair<char, int> pair2)
                {
                    return pair1.Value.CompareTo(pair2.Value);
                }
            );

            //but 0 is at the top, so reverse so that the most occurrences at the top
            l.Reverse();

            return l;
        }

        private ArrayList useEtaoin()
        {
            //etaoin shrdlu cmfwyp vbgkjq xz
            ArrayList a = new ArrayList();
            a.Add('E');
            a.Add('T');
            a.Add('A');
            a.Add('O');
            a.Add('I');
            a.Add('N');
            a.Add('S');
            a.Add('H');
            a.Add('R');
            a.Add('D');
            a.Add('L');
            a.Add('U');
            a.Add('C');
            a.Add('M');
            a.Add('F');
            a.Add('W');
            a.Add('Y');
            a.Add('P');
            a.Add('V');
            a.Add('B');
            a.Add('G');
            a.Add('K');
            a.Add('J');
            a.Add('Q');
            a.Add('X');
            a.Add('Z');

            return a;
        }

    }
}
