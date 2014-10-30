namespace ASTMViewer
{
    partial class ASTMParserGUI
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
            this.astmData = new System.Windows.Forms.RichTextBox();
            this.bParse = new System.Windows.Forms.Button();
            this.messagesData = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // astmData
            // 
            this.astmData.Location = new System.Drawing.Point(769, 35);
            this.astmData.Name = "astmData";
            this.astmData.Size = new System.Drawing.Size(654, 585);
            this.astmData.TabIndex = 1;
            this.astmData.Text = "";
            // 
            // bParse
            // 
            this.bParse.Location = new System.Drawing.Point(769, 626);
            this.bParse.Name = "bParse";
            this.bParse.Size = new System.Drawing.Size(75, 23);
            this.bParse.TabIndex = 2;
            this.bParse.Text = "Parse";
            this.bParse.UseVisualStyleBackColor = true;
            this.bParse.Click += new System.EventHandler(this.button1_Click);
            // 
            // messagesData
            // 
            this.messagesData.Location = new System.Drawing.Point(12, 35);
            this.messagesData.Name = "messagesData";
            this.messagesData.Size = new System.Drawing.Size(751, 613);
            this.messagesData.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(769, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "ASTM 1394 Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "ASTM Messages";
            // 
            // ASTMParserGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 660);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messagesData);
            this.Controls.Add(this.bParse);
            this.Controls.Add(this.astmData);
            this.Name = "ASTMParserGUI";
            this.Text = "ASTMParserGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox astmData;
        private System.Windows.Forms.Button bParse;
        private System.Windows.Forms.TreeView messagesData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

