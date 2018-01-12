using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;   //调用WINDOWS API函数时要用到

namespace jump
{
	public partial class MyForm : Form
	{
		Model model;
		Controller controller;
		

		public MyForm()
		{
			InitializeComponent();
			model = new Model();
			controller = new Controller(ref model);

			label3.Text = "跳跃速度常数：" + model.speed.ToString();
		}

		

		


		private void MyForm_Load(object sender, EventArgs e)
		{

		}
		private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			model.keyboardHook.Stop();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text == string.Empty)
				Mouse.SetX(0);
			else
				Mouse.SetX(Convert.ToInt32(textBox1.Text));
		}
		

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text == string.Empty)
				Mouse.SetY(0);
			else
				Mouse.SetY(Convert.ToInt32(textBox2.Text));
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			textBox1.Text = model.MousePos.X.ToString();
			textBox2.Text = model.MousePos.Y.ToString();
		}

		private void begin_Click(object sender, EventArgs e)
		{
			//Mouse.SetPosition(new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
			Mouse.LeftClick(1000);
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			System.Environment.Exit(0);
		}

		

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			model.speed += 0.1;
			label3.Text = "跳跃速度常数：" + model.speed.ToString();
		}

		private void down_Click(object sender, EventArgs e)
		{
			if (model.speed >= 0)
				model.speed -= 0.1;
			label3.Text = "跳跃速度常数：" + model.speed.ToString();
		}
	}
}
