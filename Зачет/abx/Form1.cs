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

namespace abx
{
    public partial class Form1 : Form
    {

        private char[] letters;
        private int[] numbers;
        private string[] colors;
        private List<string> list;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr1 = File.OpenText("letters.txt");
                StreamReader sr2 = File.OpenText("numbers.txt");
                StreamReader sr3 = File.OpenText("colors.txt");
                string line1 = sr1.ReadLine();
                string line2 = sr2.ReadLine();
                string line3 = sr3.ReadLine();
                letters = line1.Split(' ').Select(char.Parse).ToArray();
                numbers = line2.Split(' ').Select(int.Parse).ToArray();
                colors = line3.Split(' ');
                list = new List<string>();
                comboBox1.SelectedIndex = 0;
                foreach (char letter in letters)
                {
                    foreach (int number in numbers)
                    {
                        foreach (string color in colors)
                        {
                            string entry = $"{{буква = {letter}, число = {number}, цвет = {color}}}";
                            list.Add(entry);
                        }
                    }
                }
                Print();
            }
            catch
            {
                MessageBox.Show("Неверный ввод данных", "Ошибка");
            }
            
        }





        private void Print()
        {
            listBox2.Items.Clear();

            foreach (string entry in list)
            {
                listBox2.Items.Add(entry);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                char newLetter = Convert.ToChar(newLetterTextBox.Text);
                int newNumber = Convert.ToInt32(newNumberTextBox.Text);
                string newColor = newColorTextBox.Text;
              /*  if(listBox1.Items.Contains(newNumber)&& listBox1.Items.Contains(newLetter)&& listBox1.Items.Contains(newLetter))
                {
                    MessageBox.Show("Такие данные уже были добавлены", "Ошибка")ж
                }*/
                string newEntry = $"{{буква = {newLetter}, число = {newNumber}, цвет = {newColor}}}";
                list.Add(newEntry);

                Print();
            }
            catch
            {
                MessageBox.Show("Неверный ввод данных", "Ошибка");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();

                string vibor = comboBox1.SelectedItem.ToString();


                var groupby = list.GroupBy(item =>
                {
                    if (vibor == "буква")
                        return item.Substring(item.IndexOf("буква = "));
                    if (vibor == "число")
                        return item.Substring(item.IndexOf("число = "));
                    if (vibor == "цвет")
                        return item.Substring(item.IndexOf("цвет = "));

                    return "";
                });
                foreach (var group in groupby)
                {
                    foreach (string entry in group)
                    {
                        listBox1.Items.Add(entry);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Неверный ввод данных", "Ошибка");
            }
        }
    }
}
