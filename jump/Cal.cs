using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jump
{
	class Cal
	{
		public const double SPEED = 3.4;

		//计算鼠标点击延时
		public static int HoldTime(Point LastPos, Point ThisPos)
		{
			int dx = ThisPos.X - LastPos.X;
			int dy = ThisPos.Y - LastPos.Y;

			return (int)(System.Math.Sqrt(dx * dx + dy * dy) * SPEED);
		}
	}
}
