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
using System.Diagnostics;
using Lab5;

namespace Lab4
{
    public partial class Form1 : Form
    {
        List<string> word_list = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            word_list.Clear();
            Stopwatch extime = new Stopwatch();
            string fileContent;
            string filePath;
            string[] strs;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Текстовый файл|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                extime.Start();
                filePath = openFile.FileName;
                textBox2.Text = filePath.Split('\\').Last();
                fileContent = File.ReadAllText(filePath);
                strs = fileContent.Split();
                for (int i = 0; i < strs.Length; i++)
                {
                    if (!word_list.Contains(strs[i]) && (strs[i] != " ") && (strs[i].Length > 0))
                        word_list.Add(strs[i]);
                }
            }
            extime.Stop();
            textBox1.Text = extime.ElapsedMilliseconds.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch extime = new Stopwatch();
            string new_str = "\0";
            Random rnd = new Random();
            if (radioButton1.Checked == true)
            {
                extime.Start();
                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                for (int i = 0; i < word_list.Count; i++)
                {
                    if (word_list[i].Contains(textBox3.Text))
                    {
                        listBox1.Items.Add(word_list[i]);
                    }
                }
                listBox1.EndUpdate();
            }
            else if (radioButton2.Checked == true)
            {
                extime.Start();
                int max_dist;
                if ((int.TryParse(textBox5.Text, out max_dist)))
                {
                    listBox1.BeginUpdate();
                    listBox1.Items.Clear();
                    for (int i = 0; i < word_list.Count; i++)
                    {
                        if (Fisher.GetLen(word_list[i], textBox3.Text) <= max_dist &&
                            !listBox1.Items.Contains(word_list[i]))
                        {
                            listBox1.Items.Add(word_list[i]);                          
                        }
                    }
                    listBox1.EndUpdate();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите метод поиска слова!");
            }
            extime.Stop();
            textBox4.Text = extime.ElapsedMilliseconds.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label6.Visible = true;
                textBox5.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label6.Visible = false;
                textBox5.Visible = false;
            }
        }
    }
}
