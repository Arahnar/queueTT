using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dawsdaw
{
    public partial class Form1 : Form
    {
        Queue q1 = new Queue(), q2 = new Queue(), q3 = new Queue();
        object[] str1 = new object[15];
        object[] str2 = new object[15];
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("", "");
            dataGridView2.Columns.Add("", "");
            dataGridView3.Columns.Add("", "");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            q1.Enqueue(textBox1.Text);
            dataGridView1.Rows.Add(textBox1.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (q1.Count > 0) str1[str1.Length - 1] = q1.Dequeue();
            Int32 rowToDelete = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.None);
            if (rowToDelete > -1)
            {
                this.dataGridView1.Rows.RemoveAt(rowToDelete);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (q2.Count > 0) str2[str1.Length - 1] = q2.Dequeue();
            Int32 rowToDelete = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.None);
            if (rowToDelete > -1)
            {
                this.dataGridView1.Rows.RemoveAt(rowToDelete);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            q2.Enqueue(textBox2.Text);
            dataGridView2.Rows.Add(textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Queue temp = new Queue();
            foreach (Object obj in q1) temp.Enqueue(obj);
            for (int i = 0; i < int.Parse(textBox3.Text)-1; i++)
            {
                object temp2 = temp.Dequeue();
                q3.Enqueue(temp2);
                dataGridView3.Rows.Add(temp2);
            }
            foreach (Object obj in q2)
            {
                q3.Enqueue(obj);
                dataGridView3.Rows.Add(obj);
            }
            foreach (Object obj in temp)
            {
                q3.Enqueue(obj);
                dataGridView3.Rows.Add(obj);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Queue temp = new Queue();
            Queue temp2 = new Queue();
            if(q3.Count> int.Parse(textBox4.Text) + int.Parse(textBox5.Text) && dataGridView3.Rows.Count> int.Parse(textBox4.Text) + int.Parse(textBox5.Text))
            {
                for (int i = 0; i < int.Parse(textBox4.Text); i++)
                {
                    temp.Enqueue(q3.Dequeue());
                }
                for (int i = int.Parse(textBox4.Text); i < int.Parse(textBox4.Text) + int.Parse(textBox5.Text)-1; i++)
                {
                    temp2.Enqueue(q3.Dequeue());
                    dataGridView3.Rows.RemoveAt(i);
                }
                foreach (Object obj in q3)
                {
                    temp.Enqueue(obj);
                }

                q3 = temp;
            }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            q3.Clear();
            dataGridView3.Rows.Clear();



        }
    }
}
