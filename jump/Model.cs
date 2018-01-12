using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace jump
{
	class Model
	{
		private State _GameState;	//游戏状态变量
		private Point _MousePos;	//鼠标位置变量（鼠标位置的副本，设置鼠标位置时不经过本变量）
		private System.Timers.Timer timer;	//刷新鼠标位置的计时器
		private KeyboardHook _keyboardHook; //键盘钩子，监听全局键盘事件	
		private Point _BeginMousePos;   //开始前的鼠标位置
		public double speed;			//跳跃速度

		public Model()
		{
			_GameState = State.Ready;
			_MousePos = Mouse.GetPosition();
			_keyboardHook = new KeyboardHook();
			_BeginMousePos = new Point(0, 0);
			speed = 3.4;

			//每10ms触发一次鼠标位置刷新
			timer = new System.Timers.Timer(10);
			timer.AutoReset = true;
			timer.Enabled = true;
			timer.Elapsed += RefreshMousePos;

			//设置键盘事件
			_keyboardHook.Start();
		}

		//鼠标位置变量刷新事件
		private void RefreshMousePos(object sender, ElapsedEventArgs e)
		{
			_MousePos = Mouse.GetPosition();
		}











		//更改当前状态
		public State GameState
		{
			get { return _GameState; }
			set { _GameState = value; }
		}

		public Point BeginMousePos
		{
			get{ return _BeginMousePos; }
			set { _BeginMousePos = value; }

		}

		//获取当前鼠标位置
		public Point MousePos { get { return _MousePos; } }

		public KeyboardHook keyboardHook { get { return _keyboardHook; } }
	}

	//游戏状态
	enum State
	{
		Ready,          //就绪
		Initialization, //初始化
		InGame          //游戏进行中
	}
}