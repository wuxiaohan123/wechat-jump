using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;  //StructLayout
using System.Drawing;
using System.Windows.Forms;

namespace jump
{
	class Mouse :MouseWinAPI
	{
		//屏幕分辨率获取
		public static int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
		public static int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
			
		/// <summary>
		/// 获取当前鼠标位置
		/// </summary>
		/// <returns></returns>
		public static Point GetPosition()
		{
			Point point = new Point(0, 0);
			GetCursorPos(ref point);
			return point;
		}

		/// <summary>
		/// 设置鼠标位置
		/// </summary>
		/// <param name="NewPos">坐标</param>
		public static void SetPosition(Point NewPos)
		{
			if (NewPos.X < 0)
				NewPos.X = 0;
			else if (NewPos.X >= ScreenWidth)
				NewPos.X = ScreenWidth;
			if (NewPos.Y < 0)
				NewPos.Y = 0;
			else if (NewPos.Y >= ScreenHeight)
				NewPos.Y = ScreenHeight;

			SetCursorPos(NewPos.X, NewPos.Y);
		}

		/// <summary>
		/// 设置鼠标X坐标
		/// </summary>
		/// <param name="x"></param>
		public static void SetX(int x)
		{
			Point point = new Point(0, 0);
			if (GetCursorPos(ref point))
				SetCursorPos(x, point.Y);
		}

		/// <summary>
		/// 设置鼠标Y坐标
		/// </summary>
		/// <param name="y"></param>
		public static void SetY(int y)
		{
			Point point = new Point(0, 0);
			if (GetCursorPos(ref point))
				SetCursorPos(point.X, y);
		}

		/// <summary>
		/// 发送模拟左键点击事件
		/// </summary>
		/// <param name="millisecond">点击时长</param>
		public static void LeftClick(int millisecond)
		{
			if (millisecond <= 0 || millisecond > 10000)
				return;

			System.Timers.Timer timer = new System.Timers.Timer(millisecond);
			timer.Enabled = false;

			timer.Elapsed += new System.Timers.ElapsedEventHandler(theout);	//到达时间的时候执行事件；
			timer.AutoReset = false;	//设置是执行一次（false）还是一直执行(true)；
			timer.Enabled = true;		//是否执行System.Timers.Timer.Elapsed事件；
			mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
		}

		//
		public static void theout(object source, System.Timers.ElapsedEventArgs e)
		{
			mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
			mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
		}
	}



	/// <summary>
	/// 鼠标相关操作的Win32 API
	/// </summary>
	class MouseWinAPI
	{
		//将枚举作为位域处理
		[Flags]
		protected enum MouseEventFlag : uint //设置鼠标动作的键值
		{
			Move = 0x0001,               //发生移动
			LeftDown = 0x0002,           //鼠标按下左键
			LeftUp = 0x0004,             //鼠标松开左键
			RightDown = 0x0008,          //鼠标按下右键
			RightUp = 0x0010,            //鼠标松开右键
			MiddleDown = 0x0020,         //鼠标按下中键
			MiddleUp = 0x0040,           //鼠标松开中键
			XDown = 0x0080,
			XUp = 0x0100,
			Wheel = 0x0800,              //鼠标轮被移动
			VirtualDesk = 0x4000,        //虚拟桌面
			Absolute = 0x8000
		}

		/// <summary>   
		/// 获取鼠标的坐标   
		/// </summary>   
		/// <param name="lpPoint">传址参数，坐标point类型</param>   
		/// <returns>获取成功返回真</returns>   
		[DllImport("User32")]
		protected extern static bool GetCursorPos(ref Point lpPoint);

		/// <summary>
		/// 设置鼠标位置
		/// </summary>
		/// <returns>获取成功返回真</returns>   
		[DllImport("user32.dll")]
		protected static extern bool SetCursorPos(int X, int Y);

		/// <summary>   
		/// 设置鼠标按键和动作 
		/// </summary>   
		/// <param name="flags">鼠标动作的键值</param> 
		/// <param name="dx">鼠标相对移动x距离</param> 
		/// <param name="dy">鼠标相对移动y距离</param> 
		/// <param name="data">0</param>
		/// <param name="extraInfo">指针多句柄类型，UintPtr.Zero</param> 
		/// <returns>获取成功返回真</returns>   
		[DllImport("user32.dll")]
		protected static extern void mouse_event(MouseEventFlag flags, int dx, int dy,
			uint data, UIntPtr extraInfo);
	}
}
