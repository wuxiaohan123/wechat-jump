using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jump
{
	class Controller
	{
		Model model;
		public KeyboardHook keyboardhook;

		public Controller(ref Model model)
		{
			this.model = model;
			model.keyboardHook.KeyDownEvent += KeyboardHook_KeyDownEvent;
		}

		private void KeyboardHook_KeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//判断按下的键（Alt + Q）
			if (e.KeyValue == (int)Keys.Q && (int)Control.ModifierKeys == (int)Keys.Alt)
			{
				model.BeginMousePos = Mouse.GetPosition();
			}
			//判断按下的键（Alt + W）
			if (e.KeyValue == (int)Keys.W && (int)Control.ModifierKeys == (int)Keys.Alt)
			{
				Mouse.LeftClick(Cal.HoldTime(model.BeginMousePos,Mouse.GetPosition()));
			}
		}
	}
}
