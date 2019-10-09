namespace PointOfSale.WinFormUI.Views
{
    partial class ContainerView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.routerContent = new ReactiveUI.Winforms.RoutedControlHost();
            this.SuspendLayout();
            // 
            // routerContent
            // 
            this.routerContent.DefaultContent = null;
            this.routerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routerContent.Location = new System.Drawing.Point(0, 0);
            this.routerContent.Margin = new System.Windows.Forms.Padding(0);
            this.routerContent.Name = "routerContent";
            this.routerContent.Router = null;
            this.routerContent.Size = new System.Drawing.Size(804, 461);
            this.routerContent.TabIndex = 0;
            this.routerContent.ViewLocator = null;
            // 
            // ContainerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.routerContent);
            this.Name = "ContainerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point Of Sale";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private ReactiveUI.Winforms.RoutedControlHost routerContent;
    }
}