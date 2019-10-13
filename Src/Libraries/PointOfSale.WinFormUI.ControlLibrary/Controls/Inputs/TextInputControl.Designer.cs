namespace PointOfSale.WinFormUI.ControlLibrary.Controls.Inputs
{
    partial class TextInputControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InputErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputLabel.Location = new System.Drawing.Point(3, 0);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(33, 13);
            this.InputLabel.TabIndex = 0;
            this.InputLabel.Text = "Label";
            // 
            // InputTextBox
            // 
            this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputTextBox.Location = new System.Drawing.Point(3, 16);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(191, 20);
            this.InputTextBox.TabIndex = 1;
            // 
            // InputErrorMessage
            // 
            this.InputErrorMessage.AutoSize = true;
            this.InputErrorMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InputErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.InputErrorMessage.Location = new System.Drawing.Point(3, 39);
            this.InputErrorMessage.Name = "InputErrorMessage";
            this.InputErrorMessage.Size = new System.Drawing.Size(72, 13);
            this.InputErrorMessage.TabIndex = 2;
            this.InputErrorMessage.Text = "ErrorMessage";
            // 
            // TextInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.InputErrorMessage);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InputLabel);
            this.Name = "TextInputControl";
            this.Size = new System.Drawing.Size(200, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label InputLabel;
        public System.Windows.Forms.TextBox InputTextBox;
        public System.Windows.Forms.Label InputErrorMessage;
    }
}
