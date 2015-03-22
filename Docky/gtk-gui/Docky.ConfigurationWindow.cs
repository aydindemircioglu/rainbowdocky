
// This file has been generated by the GUI designer. Do not modify.
namespace Docky
{
	public partial class ConfigurationWindow
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.Notebook config_notebook;
		private global::Gtk.VBox vbox2;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.VBox vbox6;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.VBox vbox3;
		private global::Gtk.CheckButton start_with_computer_checkbutton;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Label label3;
		private global::Gtk.ComboBox theme_combo;
		private global::Gtk.Button install_theme_btn;
		private global::Gtk.Label GtkLabel5;
		private global::Gtk.Frame frame3;
		private global::Gtk.Alignment config_alignment;
		private global::Gtk.Label GtkLabel6;
		private global::Gtk.Label label1;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.VBox vbox7;
		private global::Gtk.HBox hbox1;
		private global::Gtk.ComboBox docklet_show_cmb;
		private global::Gtk.Alignment docklet_alignment;
		private global::Gtk.ScrolledWindow docklet_scroll;
		private global::Gtk.Label label2;
		private global::Gtk.Alignment helper_alignment;
		private global::Gtk.VBox vbox5;
		private global::Gtk.HBox hbox5;
		private global::Gtk.ComboBox helper_show_cmb;
		private global::Gtk.Button install_btn;
		private global::Gtk.ScrolledWindow helper_scroll;
		private global::Gtk.Label label4;
		private global::Gtk.HBox hbox2;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Button help_button;
		private global::Gtk.Button new_dock_button;
		private global::Gtk.Button delete_dock_button;
		private global::Gtk.Button close_button;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Docky.ConfigurationWindow
			this.Name = "Docky.ConfigurationWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Docky Settings");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-preferences", global::Gtk.IconSize.Menu);
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.BorderWidth = ((uint)(2));
			// Container child Docky.ConfigurationWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			// Container child vbox1.Gtk.Box+BoxChild
			this.config_notebook = new global::Gtk.Notebook ();
			this.config_notebook.CanFocus = true;
			this.config_notebook.Name = "config_notebook";
			this.config_notebook.CurrentPage = 1;
			this.config_notebook.Scrollable = true;
			// Container child config_notebook.Gtk.Notebook+NotebookChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(7));
			this.alignment1.TopPadding = ((uint)(7));
			this.alignment1.RightPadding = ((uint)(7));
			this.alignment1.BottomPadding = ((uint)(7));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox6 = new global::Gtk.VBox ();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.start_with_computer_checkbutton = new global::Gtk.CheckButton ();
			this.start_with_computer_checkbutton.CanFocus = true;
			this.start_with_computer_checkbutton.Name = "start_with_computer_checkbutton";
			this.start_with_computer_checkbutton.Label = global::Mono.Unix.Catalog.GetString ("_Start When User Logs In");
			this.start_with_computer_checkbutton.DrawIndicator = true;
			this.start_with_computer_checkbutton.UseUnderline = true;
			this.vbox3.Add (this.start_with_computer_checkbutton);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.start_with_computer_checkbutton]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.CanFocus = true;
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("_Theme:");
			this.label3.UseUnderline = true;
			this.hbox4.Add (this.label3);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label3]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.theme_combo = global::Gtk.ComboBox.NewText ();
			this.theme_combo.Name = "theme_combo";
			this.hbox4.Add (this.theme_combo);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.theme_combo]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.install_theme_btn = new global::Gtk.Button ();
			this.install_theme_btn.CanFocus = true;
			this.install_theme_btn.Name = "install_theme_btn";
			this.install_theme_btn.UseUnderline = true;
			// Container child install_theme_btn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w4 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w5 = new global::Gtk.HBox ();
			w5.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w6 = new global::Gtk.Image ();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-execute", global::Gtk.IconSize.Menu);
			w5.Add (w6);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w8 = new global::Gtk.Label ();
			w8.LabelProp = global::Mono.Unix.Catalog.GetString ("_Install");
			w8.UseUnderline = true;
			w5.Add (w8);
			w4.Add (w5);
			this.install_theme_btn.Add (w4);
			this.hbox4.Add (this.install_theme_btn);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.install_theme_btn]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			this.GtkAlignment.Add (this.vbox3);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel5 = new global::Gtk.Label ();
			this.GtkLabel5.Name = "GtkLabel5";
			this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>General Options</b>");
			this.GtkLabel5.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel5;
			this.vbox6.Add (this.frame1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.frame1]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame ();
			this.frame3.Name = "frame3";
			this.frame3.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame3.Gtk.Container+ContainerChild
			this.config_alignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.config_alignment.Name = "config_alignment";
			this.config_alignment.LeftPadding = ((uint)(12));
			this.config_alignment.RightPadding = ((uint)(10));
			this.frame3.Add (this.config_alignment);
			this.GtkLabel6 = new global::Gtk.Label ();
			this.GtkLabel6.Name = "GtkLabel6";
			this.GtkLabel6.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Dock Configuration</b>");
			this.GtkLabel6.UseMarkup = true;
			this.frame3.LabelWidget = this.GtkLabel6;
			this.vbox6.Add (this.frame3);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.frame3]));
			w18.Position = 1;
			this.alignment1.Add (this.vbox6);
			this.vbox2.Add (this.alignment1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment1]));
			w20.Position = 0;
			this.config_notebook.Add (this.vbox2);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Docks");
			this.config_notebook.SetTabLabel (this.vbox2, this.label1);
			this.label1.ShowAll ();
			// Container child config_notebook.Gtk.Notebook+NotebookChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.LeftPadding = ((uint)(7));
			this.alignment2.TopPadding = ((uint)(7));
			this.alignment2.RightPadding = ((uint)(7));
			this.alignment2.BottomPadding = ((uint)(7));
			this.alignment2.BorderWidth = ((uint)(7));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.docklet_show_cmb = global::Gtk.ComboBox.NewText ();
			this.docklet_show_cmb.AppendText (global::Mono.Unix.Catalog.GetString ("All"));
			this.docklet_show_cmb.AppendText (global::Mono.Unix.Catalog.GetString ("Enabled"));
			this.docklet_show_cmb.AppendText (global::Mono.Unix.Catalog.GetString ("Disabled"));
			this.docklet_show_cmb.Name = "docklet_show_cmb";
			this.docklet_show_cmb.Active = 0;
			this.hbox1.Add (this.docklet_show_cmb);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.docklet_show_cmb]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			this.vbox7.Add (this.hbox1);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.hbox1]));
			w23.Position = 0;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.docklet_alignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.docklet_alignment.Name = "docklet_alignment";
			// Container child docklet_alignment.Gtk.Container+ContainerChild
			this.docklet_scroll = new global::Gtk.ScrolledWindow ();
			this.docklet_scroll.CanFocus = true;
			this.docklet_scroll.Name = "docklet_scroll";
			this.docklet_scroll.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.docklet_alignment.Add (this.docklet_scroll);
			this.vbox7.Add (this.docklet_alignment);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.docklet_alignment]));
			w25.Position = 1;
			this.alignment2.Add (this.vbox7);
			this.config_notebook.Add (this.alignment2);
			global::Gtk.Notebook.NotebookChild w27 = ((global::Gtk.Notebook.NotebookChild)(this.config_notebook [this.alignment2]));
			w27.Position = 1;
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Docklets");
			this.config_notebook.SetTabLabel (this.alignment2, this.label2);
			this.label2.ShowAll ();
			// Container child config_notebook.Gtk.Notebook+NotebookChild
			this.helper_alignment = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.helper_alignment.Name = "helper_alignment";
			this.helper_alignment.LeftPadding = ((uint)(7));
			this.helper_alignment.TopPadding = ((uint)(7));
			this.helper_alignment.RightPadding = ((uint)(7));
			this.helper_alignment.BottomPadding = ((uint)(7));
			this.helper_alignment.BorderWidth = ((uint)(7));
			// Container child helper_alignment.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.helper_show_cmb = global::Gtk.ComboBox.NewText ();
			this.helper_show_cmb.AppendText (global::Mono.Unix.Catalog.GetString ("Usable"));
			this.helper_show_cmb.AppendText (global::Mono.Unix.Catalog.GetString ("Enabled"));
			this.helper_show_cmb.AppendText (global::Mono.Unix.Catalog.GetString ("Disabled"));
			this.helper_show_cmb.AppendText (global::Mono.Unix.Catalog.GetString ("All"));
			this.helper_show_cmb.Name = "helper_show_cmb";
			this.helper_show_cmb.Active = 0;
			this.hbox5.Add (this.helper_show_cmb);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.helper_show_cmb]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.install_btn = new global::Gtk.Button ();
			this.install_btn.CanFocus = true;
			this.install_btn.Name = "install_btn";
			this.install_btn.UseUnderline = true;
			// Container child install_btn.Gtk.Container+ContainerChild
			global::Gtk.Alignment w29 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w30 = new global::Gtk.HBox ();
			w30.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w31 = new global::Gtk.Image ();
			w31.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-execute", global::Gtk.IconSize.Menu);
			w30.Add (w31);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w33 = new global::Gtk.Label ();
			w33.LabelProp = global::Mono.Unix.Catalog.GetString ("_Install");
			w33.UseUnderline = true;
			w30.Add (w33);
			w29.Add (w30);
			this.install_btn.Add (w29);
			this.hbox5.Add (this.install_btn);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.install_btn]));
			w37.PackType = ((global::Gtk.PackType)(1));
			w37.Position = 1;
			w37.Expand = false;
			w37.Fill = false;
			this.vbox5.Add (this.hbox5);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.hbox5]));
			w38.Position = 0;
			w38.Expand = false;
			w38.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.helper_scroll = new global::Gtk.ScrolledWindow ();
			this.helper_scroll.CanFocus = true;
			this.helper_scroll.Name = "helper_scroll";
			this.helper_scroll.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
			this.vbox5.Add (this.helper_scroll);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.helper_scroll]));
			w39.Position = 1;
			this.helper_alignment.Add (this.vbox5);
			this.config_notebook.Add (this.helper_alignment);
			global::Gtk.Notebook.NotebookChild w41 = ((global::Gtk.Notebook.NotebookChild)(this.config_notebook [this.helper_alignment]));
			w41.Position = 2;
			// Notebook tab
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Helpers");
			this.config_notebook.SetTabLabel (this.helper_alignment, this.label4);
			this.label4.ShowAll ();
			this.vbox1.Add (this.config_notebook);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.config_notebook]));
			w42.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.help_button = new global::Gtk.Button ();
			this.help_button.CanFocus = true;
			this.help_button.Name = "help_button";
			this.help_button.BorderWidth = ((uint)(5));
			// Container child help_button.Gtk.Container+ContainerChild
			global::Gtk.Alignment w43 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w44 = new global::Gtk.HBox ();
			w44.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w45 = new global::Gtk.Image ();
			w45.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-help", global::Gtk.IconSize.Menu);
			w44.Add (w45);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w47 = new global::Gtk.Label ();
			w44.Add (w47);
			w43.Add (w44);
			this.help_button.Add (w43);
			this.hbox3.Add (this.help_button);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.help_button]));
			w51.Position = 0;
			w51.Expand = false;
			w51.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.new_dock_button = new global::Gtk.Button ();
			this.new_dock_button.CanFocus = true;
			this.new_dock_button.Name = "new_dock_button";
			this.new_dock_button.UseUnderline = true;
			this.new_dock_button.BorderWidth = ((uint)(5));
			// Container child new_dock_button.Gtk.Container+ContainerChild
			global::Gtk.Alignment w52 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w53 = new global::Gtk.HBox ();
			w53.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w54 = new global::Gtk.Image ();
			w54.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			w53.Add (w54);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w56 = new global::Gtk.Label ();
			w56.LabelProp = global::Mono.Unix.Catalog.GetString ("_New Dock");
			w56.UseUnderline = true;
			w53.Add (w56);
			w52.Add (w53);
			this.new_dock_button.Add (w52);
			this.hbox3.Add (this.new_dock_button);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.new_dock_button]));
			w60.Position = 1;
			w60.Expand = false;
			w60.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.delete_dock_button = new global::Gtk.Button ();
			this.delete_dock_button.CanFocus = true;
			this.delete_dock_button.Name = "delete_dock_button";
			this.delete_dock_button.UseUnderline = true;
			this.delete_dock_button.BorderWidth = ((uint)(5));
			// Container child delete_dock_button.Gtk.Container+ContainerChild
			global::Gtk.Alignment w61 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w62 = new global::Gtk.HBox ();
			w62.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w63 = new global::Gtk.Image ();
			w63.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			w62.Add (w63);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w65 = new global::Gtk.Label ();
			w65.LabelProp = global::Mono.Unix.Catalog.GetString ("_Delete Dock");
			w65.UseUnderline = true;
			w62.Add (w65);
			w61.Add (w62);
			this.delete_dock_button.Add (w61);
			this.hbox3.Add (this.delete_dock_button);
			global::Gtk.Box.BoxChild w69 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.delete_dock_button]));
			w69.Position = 2;
			w69.Expand = false;
			w69.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.close_button = new global::Gtk.Button ();
			this.close_button.WidthRequest = 100;
			this.close_button.CanFocus = true;
			this.close_button.Name = "close_button";
			this.close_button.UseStock = true;
			this.close_button.UseUnderline = true;
			this.close_button.BorderWidth = ((uint)(5));
			this.close_button.Label = "gtk-close";
			this.hbox3.Add (this.close_button);
			global::Gtk.Box.BoxChild w70 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.close_button]));
			w70.PackType = ((global::Gtk.PackType)(1));
			w70.Position = 3;
			w70.Expand = false;
			w70.Fill = false;
			this.hbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w71 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.hbox3]));
			w71.Position = 0;
			this.vbox1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w72 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
			w72.Position = 1;
			w72.Expand = false;
			w72.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 398;
			this.DefaultHeight = 390;
			this.label3.MnemonicWidget = this.theme_combo;
			this.Show ();
			this.config_notebook.SwitchPage += new global::Gtk.SwitchPageHandler (this.OnPageSwitch);
			this.start_with_computer_checkbutton.Toggled += new global::System.EventHandler (this.OnStartWithComputerCheckbuttonToggled);
			this.theme_combo.Changed += new global::System.EventHandler (this.OnThemeComboChanged);
			this.install_theme_btn.Clicked += new global::System.EventHandler (this.OnInstallThemeClicked);
			this.docklet_show_cmb.Changed += new global::System.EventHandler (this.OnShowDockletChanged);
			this.helper_show_cmb.Changed += new global::System.EventHandler (this.OnShowHelperChanged);
			this.install_btn.Clicked += new global::System.EventHandler (this.OnInstallClicked);
			this.help_button.Clicked += new global::System.EventHandler (this.OnHelpClicked);
			this.new_dock_button.Clicked += new global::System.EventHandler (this.OnNewDockButtonClicked);
			this.delete_dock_button.Clicked += new global::System.EventHandler (this.OnDeleteDockButtonClicked);
			this.close_button.Clicked += new global::System.EventHandler (this.OnCloseButtonClicked);
		}
	}
}