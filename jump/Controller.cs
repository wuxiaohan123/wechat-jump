using System.Windows.Forms;

namespace jump
{
	/// <summary>
	/// 控制类
	/// 作者：吴晓晗
	/// 项目地址： http://github.com/wuxiaohan/wechat-jump/
	/// </summary>
	class Controller
	{
		Model model;

		/// <summary>
		/// 获取Model控制权
		/// 通过引用传递对象
		/// </summary>
		/// <param name="model">Model类实例</param>
		public Controller(ref Model model)
		{
			this.model = model;

			//键盘按下事件绑定处理函数
			model.keyboardHook.KeyDownEvent += KeyboardHook_KeyDownEvent;
		}

		/// <summary>
		/// 键盘按下事件响应函数
		/// </summary>
		private void KeyboardHook_KeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//判断按下的键（Alt + Q）
			if (e.KeyValue == (int)Keys.Q && (int)Control.ModifierKeys == (int)Keys.Alt)
			{
				model.BeginMousePos = Mouse.GetPosition();	//获取按下Alt + Q时鼠标的位置
			}
			//判断按下的键（Alt + W）
			if (e.KeyValue == (int)Keys.W && (int)Control.ModifierKeys == (int)Keys.Alt)
			{
				//获取按下Alt + W时鼠标的位置，并计算出点击时长，发送鼠标左键点击
				Mouse.LeftClick(Cal.HoldTime(model.BeginMousePos,Mouse.GetPosition(), model.speed));
			}
		}
	}
}
