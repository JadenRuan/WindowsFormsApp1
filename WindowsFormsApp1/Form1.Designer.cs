using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.inletLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.RemainderLabel = new System.Windows.Forms.Label();
            this.LotNumberLabel = new System.Windows.Forms.Label();
            this.ExprLabel = new System.Windows.Forms.Label();
            this.scriptStatusButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.portNumberLabel = new System.Windows.Forms.Label();
            this.syringeInletLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(300, 400);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 30);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(375, 400);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 30);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 175);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(617, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(171, 203);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(617, 35);
            this.textBox2.TabIndex = 2;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.productLabel.ForeColor = System.Drawing.Color.Black;
            this.productLabel.Location = new System.Drawing.Point(5, 20);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(84, 23);
            this.productLabel.TabIndex = 0;
            this.productLabel.Text = "Product:";
            // 
            // inletLabel
            // 
            this.inletLabel.AutoSize = true;
            this.inletLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.inletLabel.ForeColor = System.Drawing.Color.Black;
            this.inletLabel.Location = new System.Drawing.Point(5, 55);
            this.inletLabel.Name = "inletLabel";
            this.inletLabel.Size = new System.Drawing.Size(59, 23);
            this.inletLabel.TabIndex = 1;
            this.inletLabel.Text = "Inlet: ";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.PortLabel.ForeColor = System.Drawing.Color.Black;
            this.PortLabel.Location = new System.Drawing.Point(5, 90);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(76, 23);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "Port #: ";
            // 
            // RemainderLabel
            // 
            this.RemainderLabel.AutoSize = true;
            this.RemainderLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.RemainderLabel.ForeColor = System.Drawing.Color.Black;
            this.RemainderLabel.Location = new System.Drawing.Point(5, 135);
            this.RemainderLabel.Name = "RemainderLabel";
            this.RemainderLabel.Size = new System.Drawing.Size(164, 23);
            this.RemainderLabel.TabIndex = 3;
            this.RemainderLabel.Text = "Remainder (mL): ";
            // 
            // LotNumberLabel
            // 
            this.LotNumberLabel.AutoSize = true;
            this.LotNumberLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.LotNumberLabel.ForeColor = System.Drawing.Color.Black;
            this.LotNumberLabel.Location = new System.Drawing.Point(5, 170);
            this.LotNumberLabel.Name = "LotNumberLabel";
            this.LotNumberLabel.Size = new System.Drawing.Size(124, 23);
            this.LotNumberLabel.TabIndex = 4;
            this.LotNumberLabel.Text = "Lot Number: ";
            // 
            // ExprLabel
            // 
            this.ExprLabel.AutoSize = true;
            this.ExprLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.ExprLabel.ForeColor = System.Drawing.Color.Black;
            this.ExprLabel.Location = new System.Drawing.Point(5, 205);
            this.ExprLabel.Name = "ExprLabel";
            this.ExprLabel.Size = new System.Drawing.Size(108, 23);
            this.ExprLabel.TabIndex = 5;
            this.ExprLabel.Text = "Expiration: ";
            // 
            // scriptStatusButton
            // 
            this.scriptStatusButton.Location = new System.Drawing.Point(539, 401);
            this.scriptStatusButton.Name = "scriptStatusButton";
            this.scriptStatusButton.Size = new System.Drawing.Size(96, 28);
            this.scriptStatusButton.TabIndex = 8;
            this.scriptStatusButton.Text = "Script Status";
            this.scriptStatusButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(665, 401);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 27);
            this.button3.TabIndex = 9;
            this.button3.Text = "Run Script";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(127, 374);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 54);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(24, 374);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 54);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(171, 138);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(617, 22);
            this.textBox3.TabIndex = 14;
            // 
            // portNumberLabel
            // 
            this.portNumberLabel.AutoSize = true;
            this.portNumberLabel.Location = new System.Drawing.Point(168, 97);
            this.portNumberLabel.Name = "portNumberLabel";
            this.portNumberLabel.Size = new System.Drawing.Size(28, 16);
            this.portNumberLabel.TabIndex = 15;
            this.portNumberLabel.Text = "176";
            // 
            // syringeInletLabel
            // 
            this.syringeInletLabel.AutoSize = true;
            this.syringeInletLabel.Location = new System.Drawing.Point(168, 61);
            this.syringeInletLabel.Name = "syringeInletLabel";
            this.syringeInletLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.syringeInletLabel.Size = new System.Drawing.Size(80, 16);
            this.syringeInletLabel.TabIndex = 16;
            this.syringeInletLabel.Text = "Syringe Inlet";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(167, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(621, 24);
            this.comboBox1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.syringeInletLabel);
            this.Controls.Add(this.portNumberLabel);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.scriptStatusButton);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.inletLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.RemainderLabel);
            this.Controls.Add(this.LotNumberLabel);
            this.Controls.Add(this.ExprLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "Form1";
            this.Text = "Port 2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Button okButton;
        private Button cancelButton;
        private Label productLabel;
        private Label inletLabel;
        private Label PortLabel;
        private Label RemainderLabel;
        private Label LotNumberLabel;
        private Label ExprLabel;
        private Button scriptStatusButton;
        private Button button3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textBox3;
        private Label portNumberLabel;
        private Label syringeInletLabel;
        private ComboBox comboBox1;
    }
}

