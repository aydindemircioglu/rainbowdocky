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
				double myLastPosition = maxPosition;
				double relPos = (double)(Position)/(double)myLastPosition;

				double newColorR = 0;
				double newColorG = 0;
				double newColorB = 0;

				// FIXME: do something with the saturation/intensity/value whatever
				byte maxRGB = 229;
				
				if (relPos < 0.2) {
					newColorR = 0;
					newColorG = (byte) Math.Round ( (relPos/0.2) * maxRGB);
					newColorB = maxRGB;
				} else if (relPos < 0.4) {
					newColorR = 0;
					newColorG = maxRGB;
					newColorB = maxRGB - (byte) Math.Round ( ((relPos-0.2)/0.2) * maxRGB);
				} else if (relPos < 0.6) {
					newColorR = (byte) Math.Round ( ((relPos-0.4)/0.2) * maxRGB);
					newColorG = maxRGB;
					newColorB = 0;
				} else if (relPos < 0.8) {
					newColorR = maxRGB;
					newColorG = maxRGB - (byte) Math.Round ( ((relPos-0.6)/0.2) * maxRGB);
					newColorB = 0;
				} else {
					newColorR = maxRGB;
					newColorG = 0;
					newColorB = (byte) Math.Round ( ((relPos-0.8)/0.2) * maxRGB);
				}
				
				Log<IconDockItem>.Info ("{0}, {1}, {2} for position {3} of {4}", newColorR, newColorG, newColorB, Position, maxPosition);
				
				for (int i = 0; i < length; i++) {
						
						// check if pixel is whitish by checking the difference in R, G, B, the max is 255+255
						double whiteAlpha = Math.Abs (pixels[0] - pixels[1]) + Math.Abs (pixels[0] - pixels[2]) + Math.Abs (pixels[2] - pixels[1]);
						whiteAlpha = whiteAlpha/(255 + 255);
						
				
						if (whiteAlpha > 0.2) {
							pixels[0] = (byte) Math.Round(newColorR * whiteAlpha + 255  * (1.0 - whiteAlpha));
							pixels[1] = (byte) Math.Round(newColorG * whiteAlpha + 255 * (1.0 - whiteAlpha));
							pixels[2] = (byte) Math.Round(newColorB * whiteAlpha + 255  * (1.0 - whiteAlpha));
							pixels[0] = (byte) newColorR;
							pixels[1] = (byte) newColorG;
							pixels[2] = (byte) newColorB;
						}  else {
							byte whitish = (byte) Math.Round ( 255 * (double) (pixels[0] + pixels[1] + pixels[2])/(double)(255*3) );
							whitish = 255;
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
