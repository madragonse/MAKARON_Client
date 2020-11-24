
namespace BMB
{
    partial class BMB
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGry = new System.Windows.Forms.Panel();
            this.connectButton = new System.Windows.Forms.Button();
            this.textBoxAdresIPWpisany = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelGry
            // 
            this.panelGry.Location = new System.Drawing.Point(0, 0);
            this.panelGry.Margin = new System.Windows.Forms.Padding(0);
            this.panelGry.Name = "panelGry";
            this.panelGry.Size = new System.Drawing.Size(977, 977);
            this.panelGry.TabIndex = 0;
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectButton.Location = new System.Drawing.Point(1027, 122);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(397, 109);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Dołącz do serwera";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // textBoxAdresIPWpisany
            // 
            this.textBoxAdresIPWpisany.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxAdresIPWpisany.Location = new System.Drawing.Point(1027, 79);
            this.textBoxAdresIPWpisany.Name = "textBoxAdresIPWpisany";
            this.textBoxAdresIPWpisany.Size = new System.Drawing.Size(397, 37);
            this.textBoxAdresIPWpisany.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1021, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wpisz Adres IP serwera";
            // 
            // BMB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1436, 960);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAdresIPWpisany);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.panelGry);
            this.KeyPreview = true;
            this.Name = "BMB";
            this.Text = "--";
            this.Load += new System.EventHandler(this.BMB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BMB_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BMB_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGry;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox textBoxAdresIPWpisany;
        private System.Windows.Forms.Label label1;
    }
}

