using System.Drawing;

namespace jump
{
	/// <summary>
	/// 计算类
	/// 作者：吴晓晗
	/// 项目地址： http://github.com/wuxiaohan/wechat-jump/
	/// </summary>
	class Cal
	{
		/// <summary>
		/// 计算鼠标点击延时
		/// </summary>
		/// <param name="LastPos">第一次确定起始位置</param>
		/// <param name="ThisPos">第二次确定目的位置</param>
		/// <param name="SPEED">速度常数</param>
		/// <returns>按下鼠标左键的时长，单位：ms</returns>
		public static int HoldTime(Point LastPos, Point ThisPos, int SPEED)
		{
			int dx = ThisPos.X - LastPos.X;
			int dy = ThisPos.Y - LastPos.Y;

			//微信跳一跳游戏之公理1：跳跃距离与时间成正比，本程序正是基于此公理而开发
			return (int)(System.Math.Sqrt(dx * dx + dy * dy) * SPEED / 10.0);
		}
	}
}
