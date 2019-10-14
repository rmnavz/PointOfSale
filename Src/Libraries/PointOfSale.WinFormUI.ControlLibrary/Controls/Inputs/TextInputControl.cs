using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI.ControlLibrary.Controls.Inputs
{
    public partial class TextInputControl : UserControl
    {
        public TextInputControl()
        {
            InitializeComponent();
        }

        #region User Defined Properties

        /// <summary>
        /// Property to set/get Input Label
        /// </summary>
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets Input label")]
        [DisplayName("Input Label")]
        public string Label
        {
            get
            {
                return InputLabel.Text;
            }
            set
            {
                InputLabel.Text = value;
                base.OnTextChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Property to set/get Textbox Text
        /// </summary>
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets Textbox Text")]
        [DisplayName("Textbox's Text")]
        public string TextboxText
        {
            get
            {
                return InputTextBox.Text;
            }
            set
            {
                InputTextBox.Text = value;
                base.OnTextChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Property to set/get Input Error Message
        /// </summary>
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets Input Error Message")]
        [DisplayName("Error Message")]
        public string ErrorMessage
        {
            get
            {
                return InputErrorMessage.Text;
            }
            set
            {
                InputErrorMessage.Text = value;
                base.OnTextChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Property to set/get Password Char
        /// </summary>
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets Input Password Char")]
        [DisplayName("Password Char")]
        public char PasswordChar
        {
            get
            {
                return InputTextBox.PasswordChar;
            }
            set
            {
                InputTextBox.PasswordChar = value;
                base.OnTextChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Property to set/get Use System Password Char
        /// </summary>
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets Input Use System Password Char")]
        [DisplayName("Use System Password Char")]
        public bool UseSystemPasswordChar
        {
            get
            {
                return InputTextBox.UseSystemPasswordChar;
            }
            set
            {
                InputTextBox.UseSystemPasswordChar = value;
                base.OnTextChanged(new EventArgs());
            }
        }

        #endregion
    }
}
