using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using MetroFramework.Components;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System.Drawing.Imaging;
using System.Collections;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using MetroFramework;
using MetroFramework.Controls;

namespace MetroFramework.CustomMetroControls
{
    internal static class MetroDefaults
    {
        public const MetroColorStyle Style = MetroColorStyle.Blue;
        public const MetroThemeStyle Theme = MetroThemeStyle.Light;

        public static class PropertyCategory
        {
            public const string Appearance = "Metro Appearance";
            public const string Behaviour = "Metro Behaviour";
        }
    }

    public partial class MetroListBox : ListBox, IMetroControl
    {
        private Font stdFont = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);


        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 133 && !DesignMode)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                Graphics g = Graphics.FromHdc(hDC);
                g.DrawRectangle(new Pen(MetroPaint.GetStyleColor(Style)), 0, 0, Width - 1, Height - 1);
                ReleaseDC(m.HWnd, hDC);
            }
            else
                base.WndProc(ref m);
        }

        #region Interface

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private MetroColorStyle metroStyle = MetroColorStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroColorStyle.Default)]
        public MetroColorStyle Style
        {
            get
            {
                if (DesignMode || metroStyle != MetroColorStyle.Default)
                {
                    return metroStyle;
                }

                if (StyleManager != null && metroStyle == MetroColorStyle.Default)
                {
                    return StyleManager.Style;
                }
                if (StyleManager == null && metroStyle == MetroColorStyle.Default)
                {
                    return MetroDefaults.Style;
                }

                return metroStyle;
            }
            set
            {
                metroStyle = value;
            }
        }

        private MetroThemeStyle metroTheme = MetroThemeStyle.Default;
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        [DefaultValue(MetroThemeStyle.Default)]
        public MetroThemeStyle Theme
        {
            get
            {
                if (DesignMode || metroTheme != MetroThemeStyle.Default)
                {
                    return metroTheme;
                }

                if (StyleManager != null && metroTheme == MetroThemeStyle.Default)
                {
                    return StyleManager.Theme;
                }
                if (StyleManager == null && metroTheme == MetroThemeStyle.Default)
                {
                    return MetroDefaults.Theme;
                }

                return metroTheme;
            }
            set { metroTheme = value; }
        }

        private MetroStyleManager metroStyleManager = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MetroStyleManager StyleManager
        {
            get { return metroStyleManager; }
            set
            {
                metroStyleManager = value;
            }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(MetroDefaults.PropertyCategory.Appearance)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(MetroDefaults.PropertyCategory.Behaviour)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion

        public MetroListBox()
        {
            this.Font = new Font("Segoe UI", 12.0f);
            if(DesignMode)
            {
            }
            else
            {
                this.BorderStyle = BorderStyle.FixedSingle;
                this.DrawMode = DrawMode.OwnerDrawVariable;
                this.DrawItem += MetroListBox_DrawItem;
                this.MeasureItem += MetroListBox_MeasureItem;
            }
        }

        private void MetroListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Cast the sender object back to ListBox type.
            ListBox listBox = (ListBox)sender;
            e.ItemHeight = listBox.Font.Height;
        }

        private void MetroListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (DesignMode)
                return;

            ListBox listBox = (ListBox)sender;
            e.DrawBackground();
            Brush myBrush = Brushes.White;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (Style == MetroColorStyle.White)
                    myBrush = Brushes.Black;
                e.Graphics.FillRectangle(new SolidBrush(MetroPaint.GetStyleColor(Style)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            }

            if(listBox.Items.Count > 0)
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds);
            e.DrawFocusRectangle();
        }

        [Description("Set the font of the button caption")]
        [Browsable(false)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

    }
}

