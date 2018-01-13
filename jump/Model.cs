using System.Drawing;
using System.Timers;	

namespace jump
{
	/// <summary>
	/// 模型类
	/// 作者：吴晓晗
	/// 项目地址： http://github.com/wuxiaohan/wechat-jump/
	/// </summary>
	class Model
	{
		private Point _MousePos;			//鼠标位置变量（鼠标位置的副本，每10ms刷新一次）
		private Timer timer;				//刷新鼠标位置的计时器
		private KeyboardHook _keyboardHook; //键盘钩子，监听全局键盘事件	
		private Point _BeginMousePos;		//开始前的鼠标位置
		private int _speed;					//跳跃速度常数（预设值35）

		public Model()
		{
			_MousePos = Mouse.GetPosition();
			_keyboardHook = new KeyboardHook();
			_BeginMousePos = new Point(0, 0);
			_speed = 35;

			//每10ms触发一次鼠标位置刷新
			timer = new Timer(10);
			timer.AutoReset = true;     //设置是执行一次（false）还是一直执行(true)；
			timer.Enabled = true;       //是否执行System.Timers.Timer.Elapsed事件；
			timer.Elapsed += RefreshMousePos;	//时钟触发事件绑定刷新鼠标位置函数

			//开启键盘监听
			_keyboardHook.Start();
		}

		/// <summary>
		/// 鼠标位置变量刷新事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RefreshMousePos(object sender, ElapsedEventArgs e)
		{
			_MousePos = Mouse.GetPosition();
		}

		public Point BeginMousePos
		{
			get{ return _BeginMousePos; }
			set { _BeginMousePos = value; }
		}

		//获取当前鼠标位置
		public Point MousePos
		{
			get{return _MousePos;}
		}

		public KeyboardHook keyboardHook
		{
			get{return _keyboardHook;}
		}

		public int speed
		{
			get { return _speed; }
			set { _speed = value; }
		}
	}

}