using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Plugin.Maui.KeyListener.Sample;

public partial class NavigableContainer : ContentView
{
	public NavigableContainer()
	{
		InitializeComponent();

		Loaded += OnLoaded;
	}

	protected void OnLoaded(object sender, EventArgs e)
	{
		for (int i = 1; i < 5; i++)
		{
			var item = new NavigableContentView() { Text = $"Nav Control {i}" };
			//SemanticProperties.SetDescription(item, item.Text);
			NavContainer.Add(item);
		}
		Loaded -= OnLoaded;
	}

	public void OnKeyDown(object sender, KeyPressedEventArgs e)
	{
		NavigableContentView currentlyActiveControl =
			(NavigableContentView)NavContainer.Children.FirstOrDefault(o => o.IsFocused == true);

		if (currentlyActiveControl == null)
		{
			return;
		}

		int currentIndex = NavContainer.Children.IndexOf(currentlyActiveControl);

		if (e.Keys == KeyboardKeys.UpArrow)
		{
			//navigate up
			if (currentIndex > 0)
			{
				NavContainer.Children[currentIndex - 1].Focus();
			}
		}
		else if (e.Keys == KeyboardKeys.DownArrow)
		{
			//navigate down
			if (currentIndex < NavContainer.Count - 1)
			{
				NavContainer.Children[currentIndex + 1].Focus();
			}
		}
	}
}