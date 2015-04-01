//  
//  Copyright (C) 2009 Jason Smith, Robert Dyer, Chris Szikszoy
//  Copyright (C) 2010 Robert Dyer
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

using Gdk;
using Gtk;
using Cairo;
using Mono.Unix;

using Docky.Menus;
using Docky.Services;
using Docky.CairoHelper;

namespace Docky.Items
{
	public abstract class IconDockItem : AbstractDockItem
	{
		public event EventHandler IconUpdated;
		
		string remote_icon;
		string icon;
		public string Icon {
			get { return string.IsNullOrEmpty (remote_icon) ? icon : remote_icon; }
			protected set {
				if (icon == value)
					return;
				icon = value;
				
				// if we set this, clear the forced pixbuf
				ForcePixbuf = null;
				
				if (icon != null)
					using (Gtk.IconInfo info = Gtk.IconTheme.Default.LookupIcon (icon, 48, Gtk.IconLookupFlags.ForceSvg))
						ScalableRendering = info != null && info.Filename != null && info.Filename.EndsWith (".svg");
				
				OnIconUpdated ();
				QueueRedraw ();
			}
		}
		
		Pixbuf forced_pixbuf;
		protected Pixbuf ForcePixbuf {
			get { return forced_pixbuf; }
			set {
				if (forced_pixbuf == value)
					return;
				if (forced_pixbuf != null)
					forced_pixbuf.Dispose ();
				forced_pixbuf = value;
				QueueRedraw ();
			}
		}
		
		List<IconEmblem> Emblems;
		
		protected void SetIconFromGIcon (GLib.Icon gIcon)
		{
			Icon = DockServices.Drawing.IconFromGIcon (gIcon);
		}
		
		protected void SetIconFromPixbuf (Pixbuf pbuf)
		{
			ForcePixbuf = pbuf.Copy ();
		}
		
		public IconDockItem ()
		{
			Emblems = new List<IconEmblem> ();
			Icon = "";
		}
		
		public void AddEmblem (IconEmblem emblem)
		{
			// remove current emblems at this position
			foreach (IconEmblem e in Emblems.Where (e => e.Position == emblem.Position).ToList ())
				RemoveEmblem (e);
			// add the new emblem
			Emblems.Add (emblem);
			emblem.Changed += HandleEmblemChanged;
			QueueRedraw ();
		}

		void HandleEmblemChanged (object sender, EventArgs e)
		{
			QueueRedraw ();
		}
		
		public void RemoveEmblem (IconEmblem emblem)
		{
			if (Emblems.Contains (emblem)) {
				emblem.Changed -= HandleEmblemChanged;
				Emblems.Remove (emblem);
				emblem.Dispose ();
				QueueRedraw ();
			}
		}
		
		public void SetRemoteIcon (string icon)
		{
			remote_icon = icon;
			
			OnIconUpdated ();
			QueueRedraw ();
		}

		
	
	
		/// <summary>
		/// Convert HSV to RGB
		/// h is from 0-360
		/// s,v values are 0-1
		/// r,g,b values are 0-255
		/// Based upon http://ilab.usc.edu/wiki/index.php/HSV_And_H2SV_Color_Space#HSV_Transformation_C_.2F_C.2B.2B_Code_2
		/// </summary>
		public void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
		{    
			double H = h;
			while (H < 0) { H += 360; };
			while (H >= 360) { H -= 360; };
			double R, G, B;
			if (V <= 0)
				{ R = G = B = 0; }
			else if (S <= 0)
			{
				R = G = B = V;
			}
			else
			{
				double hf = H / 60.0;
				int i = (int)Math.Floor(hf);
				double f = hf - i;
				double pv = V * (1 - S);
				double qv = V * (1 - S * f);
				double tv = V * (1 - S * (1 - f));
				switch (i)
				{

					// Red is the dominant color

					case 0:
						R = V;
						G = tv;
						B = pv;
						break;

					// Green is the dominant color

					case 1:
						R = qv;
						G = V;
						B = pv;
						break;
					case 2:
						R = pv;
						G = V;
						B = tv;
						break;

					// Blue is the dominant color

					case 3:
						R = pv;
						G = qv;
						B = V;
						break;
					case 4:
						R = tv;
						G = pv;
						B = V;
						break;

					// Red is the dominant color

					case 5:
						R = V;
						G = pv;
						B = qv;
						break;

					// Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

					case 6:
						R = V;
						G = tv;
						B = pv;
						break;
					case -1:
						R = V;
						G = pv;
						B = qv;
						break;

					// The color is not defined, we should throw an error.

					default:
						//LFATAL("i Value error in Pixel conversion, Value is %d", i);
						R = G = B = V; // Just pretend its black/white
						break;
				}
			}
			r = Clamp((int)(R * 255.0));
			g = Clamp((int)(G * 255.0));
			b = Clamp((int)(B * 255.0));
		}

		public int Clamp(int i)
		{
			if (i < 0) return 0;
			if (i > 255) return 255;
			return i;
		}

		
		
		protected override void PaintIconSurface (DockySurface surface)
		{			
			Gdk.Pixbuf pbuf;
			
			if (ForcePixbuf == null) {
				Log<IconDockItem>.Info ("Loading icon {0}", Icon);
				pbuf = DockServices.Drawing.LoadIcon (Icon, surface.Width, surface.Height);
			} else {
				pbuf = ForcePixbuf.Copy ();
				pbuf = pbuf.ARScale (surface.Width, surface.Height);
			}
			Log<IconDockItem>.Info ("Painting icon {0}", Icon);
			
			pbuf = ProcessPixbuf (pbuf);

			unsafe {
				// process pixbuf maybe
				byte *pixels = (byte*)pbuf.Pixels;
				int width = pbuf.Width;
				int height = pbuf.Height;
				int length = width * height;

				// determine rainbow color
				double curPosition = Position;
				double myMaxPosition = maxPosition + 1;
				
				// we have one minor problem, the docky icon has always zero position.
				Log<IconDockItem>.Info ("{0}", ShortName);
				if (ShortName != "Docky") 
					curPosition = curPosition + 1;
				
				double relPos = curPosition/(double)myMaxPosition;
				int[] hueMap =  {240, 220, 190, 130, 80, 60, 40, 20, 0,  -20, -40, -60, -80};
				int hueMin = (int) Math.Floor(relPos*(hueMap.Length-2));
				int hueMax = hueMin + 1;
				double hueWeight = relPos*(hueMap.Length-2) - hueMin;
				double hue = Math.Round (hueWeight * hueMap[hueMax] + (1 - hueWeight) * hueMap[hueMin]);
// 				// hue should go from 240 downto 0--360 downto 300
// 				double hue = 240 - relPos*300; 
				Log<IconDockItem>.Info ("{0}, {1}, {2} of {3} ", relPos, hueMin, hueMax, hueMap.Length);
				if (hue < 0)
					hue = 360 + hue;

					
				double[] satMap =  {0.82, 0.82, 0.82, 0.84, 0.88, 0.92, 0.94, 0.92, 0.88, 0.86, 0.84, 0.82, 0.82};
				double sat = (hueWeight * satMap[hueMax] + (1 - hueWeight) * satMap[hueMin]);

				double[] valMap =  {0.75, 0.75, 0.78, 0.84, 0.88, 0.92, 0.94, 0.92, 0.88, 0.78, 0.71, 0.66, 0.66};
				double val = (hueWeight * valMap[hueMax] + (1 - hueWeight) * valMap[hueMin]);

				int newColorR = 0;
				int newColorG = 0;
				int newColorB = 0;
				HsvToRgb(hue, sat, val, out newColorR, out newColorG, out newColorB);

				
				Log<IconDockItem>.Info ("{0}, {1}, {2} (hue {5}, sat {6}, val {7}) for position {3} of {4}", newColorR, newColorG, newColorB, curPosition, myMaxPosition, hue, sat, val);
				
				for (int i = 0; i < length; i++) {
						
						// check if pixel is whitish by checking the difference in R, G, B, the max is 255+255
						double whiteAlpha = Math.Abs (pixels[0] - pixels[1]) + Math.Abs (pixels[0] - pixels[2]) + Math.Abs (pixels[2] - pixels[1]);
						whiteAlpha = whiteAlpha/(255 + 255);
						
				
						if (whiteAlpha > 0.19) {
							pixels[0] = (byte) Math.Round(newColorR * whiteAlpha + 255  * (1.0 - whiteAlpha));
							pixels[1] = (byte) Math.Round(newColorG * whiteAlpha + 255 * (1.0 - whiteAlpha));
							pixels[2] = (byte) Math.Round(newColorB * whiteAlpha + 255  * (1.0 - whiteAlpha));
							pixels[0] = (byte) newColorR;
							pixels[1] = (byte) newColorG;
							pixels[2] = (byte) newColorB;
						}  else {
							byte whitish = (byte) Math.Round ( 255 * (double) (pixels[0] + pixels[1] + pixels[2])/(double)(255*3) );
//							whitish = 255;
							pixels[0] = (byte) whitish;
							pixels[1] = (byte) whitish;
							pixels[2] = (byte) whitish;
						}
						
						pixels += 4;
				}
			}
			
			Gdk.CairoHelper.SetSourcePixbuf (surface.Context, 
			                                 pbuf, 
			                                 (surface.Width - pbuf.Width) / 2, 
			                                 (surface.Height - pbuf.Height) / 2);
			surface.Context.Paint ();
			
			// draw the emblems
			foreach (IconEmblem emblem in Emblems)
				using (Pixbuf p = emblem.GetPixbuf (surface.Width, surface.Height)) {
					int x, y;
					switch (emblem.Position) {
					case 1:
						x = surface.Width - p.Width;
						y = 0;
						break;
					case 2:
						x = surface.Width - p.Width;
						y = surface.Height - p.Height;
						break;
					case 3:
						x = 0;
						y = surface.Height - p.Height;
						break;
					default:
						x = y = 0;
						break;
					}
					Gdk.CairoHelper.SetSourcePixbuf (surface.Context, p, x, y);
					surface.Context.Paint ();
				}

			pbuf.Dispose ();
			
			try {
				PostProcessIconSurface (surface);
			} catch (Exception e) {
				Log<IconDockItem>.Error (e.Message);
				Log<IconDockItem>.Debug (e.StackTrace);
			}
		}
		
		protected virtual Gdk.Pixbuf ProcessPixbuf (Gdk.Pixbuf pbuf)
		{
			return pbuf;
		}
		
		protected virtual void PostProcessIconSurface (DockySurface surface)
		{
		}
		
		
		protected void OnIconUpdated ()
		{
			if (IconUpdated != null)
				IconUpdated (this, EventArgs.Empty);
		}
		
		public override void Dispose ()
		{
			if (Emblems.Any ())
				Emblems.ForEach (emblem => {
					emblem.Changed -= HandleEmblemChanged;
					emblem.Dispose ();
				});
			Emblems.Clear ();
			
			if (forced_pixbuf != null)
				forced_pixbuf.Dispose ();
			forced_pixbuf = null;
			
			base.Dispose ();
		}				
	}
}
