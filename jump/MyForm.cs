using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace jump
{
	/// <summary>
	/// 窗体类
	/// 作者：吴晓晗
	/// 项目地址： http://github.com/wuxiaohan/wechat-jump/
	/// </summary>
	public partial class MyForm : Form
	{
		Model model;
		Controller controller;
		KeyboardHook TempKeyboardHook;

		public MyForm()
		{
			InitializeComponent();
			model = new Model();
			controller = new Controller(ref model);		//获取model对象的引用
			TempKeyboardHook = model.keyboardHook;		//获取键盘钩子对象的引用
			notifyIcon1.MouseClick += NotifyIcon1_MouseClick;	//绑定鼠标左键点击托盘态图标事件处理函数
			
			label3.Text = "跳跃速度常数：" + model.speed.ToString();
		}

		/// <summary>
		/// 托盘态左键点击显示程序窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
		{
			//点击鼠标"左键"发生  
			if (e.Button == MouseButtons.Left)
			{
				Visible = true;                        //窗体可见  
				WindowState = FormWindowState.Normal;  //窗体默认大小  
			}
		}
		
		// 重写OnClosing使点击关闭按键时窗体能够缩进托盘
		protected override void OnClosing(CancelEventArgs e)
		{
			this.ShowInTaskbar = false;
			this.WindowState = FormWindowState.Minimized;
			e.Cancel = true;
		}

		//人为修改鼠标绝对坐标x坐标
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text == string.Empty)
				Mouse.SetX(0);
			else
				Mouse.SetX(Convert.ToInt32(textBox1.Text));
		}

		//人为修改鼠标绝对坐标x坐标
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text == string.Empty)
				Mouse.SetY(0);
			else
				Mouse.SetY(Convert.ToInt32(textBox2.Text));
		}

		//每50ms刷新一次窗口显示的当前坐标
		private void timer1_Tick(object sender, EventArgs e)
		{
			textBox1.Text = model.MousePos.X.ToString();
			textBox2.Text = model.MousePos.Y.ToString();
		}
		
		/// <summary>
		/// 托盘态右键菜单：关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			//停止键盘钩子的监听
			TempKeyboardHook.Stop();
			System.Environment.Exit(0);
		}
		
		/// <summary>
		/// 托盘态右键菜单：显示窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
		}

		//up按钮，增加速度常数
		private void button1_Click(object sender, EventArgs e)
		{
			model.speed += 1;
			label3.Text = "跳跃速度常数：" + model.speed.ToString();
		}

		//down按钮，减小速度常数
		private void down_Click(object sender, EventArgs e)
		{
			if (model.speed >= 0)
				model.speed -= 1;
			label3.Text = "跳跃速度常数：" + model.speed.ToString();
		}

		//帮助页面
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("用法：\n1、鼠标指向初始位置，按下Alt+Q记录；\n2、鼠标指向目标位置，按下Alt+W发射。\n源代码地址:http://github.com/wuxiaohan/wechat-jump/","帮助");
		}

		private void MyForm_Load(object sender, EventArgs e)
		{

		}
	}
}
