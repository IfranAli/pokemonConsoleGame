using System;

namespace Hookin
{
	public class Cscui
	{
		public Cscui ()
		{
			
		}

		public class Region {
			public Region ParentRegion;
			public Region ChildRegion;
			Point pointA;
			Point pointB;
			private const int offset = 2;
			public int Width { 
				get{ 
					return pointA.left - pointB.left;  
				}
			}
			public int Height {
				get {
					return pointA.top - pointB.top;
				}
			}

				public Region () {
				Console.ForegroundColor = ConsoleColor.Cyan;
				pointA = new Point(0,0);
				pointB = new Point(Console.BufferWidth, Console.BufferHeight - offset);
			}

			public Region(Region region) {
				ParentRegion = (this);
				SetChild(region);
			}

			public void Render(String message) {
				drawBox (pointA, pointB);
				if (ChildRegion != null) {
					ChildRegion.Render ("");
				}
			}

			void drawBox(Point a, Point b) {
				for (int i = a.top; i <= b.top; i++) {
					Console.SetCursorPosition (a.left, i);
					if (i == a.top || i == b.top) {
						Console.Write (new String ('#', b.left - a.left));
					} else {
						Console.SetCursorPosition (a.left, i);
						Console.Write ('#');
						Console.SetCursorPosition (b.left -1, i);
						Console.Write ('#');
					}
				}
			}

			public void SetChild(Region region) {
				region.ParentRegion = this;
				ChildRegion = region;
			}

			public void Split(Orientation orientation) {
				if (orientation == Orientation.Horizontal) {
					int a = pointB.left;
					int b = a / 2;
					pointB.left = b;
				} else {
					//Point
				}
			}
		}

		public enum Orientation {
			Vertical,
			Horizontal
		};

		public struct Point {
			public int left, top;
			public Point(int left, int top) {
				this.left = left;
				this.top = top;
			}
		};
	}
}