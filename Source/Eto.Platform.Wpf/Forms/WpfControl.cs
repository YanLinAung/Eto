using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eto.Forms;
using Eto.Drawing;
using Eto.Platform.Wpf.Drawing;
using swc = System.Windows.Controls;

namespace Eto.Platform.Wpf.Forms
{
	public class WpfControl<T, W> : WpfFrameworkElement<T, W>, IControl
		where T : swc.Control
		where W: Control
	{
		Font font;


		public override Color BackgroundColor
		{
			get { return (ContainerControl as swc.Control ?? Control).Background.ToEtoColor(); }
			set { (ContainerControl as swc.Control ?? Control).Background = value.ToWpfBrush(Control.Background); }
		}

		public Font Font
		{
			get
			{
				if (font == null)
					font = new Font (Widget.Generator, new FontHandler (Widget.Generator, Control));
				return font;
			}
			set
			{
				font = value;
				FontHandler.Apply (Control, font);
			}
		}

	}
}
