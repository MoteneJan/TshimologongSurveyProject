namespace TshimologongSurveyProject
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
            this.btnFillSurvey = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFillSurvey
            // 
            this.btnFillSurvey.BackColor = System.Drawing.Color.Lime;
            this.btnFillSurvey.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFillSurvey.ForeColor = System.Drawing.Color.White;
            this.btnFillSurvey.Location = new System.Drawing.Point(97, 68);
            this.btnFillSurvey.Name = "btnFillSurvey";
            this.btnFillSurvey.Size = new System.Drawing.Size(341, 53);
            this.btnFillSurvey.TabIndex = 0;
            this.btnFillSurvey.Text = "Fill Out Survey";
            this.btnFillSurvey.UseVisualStyleBackColor = false;
            this.btnFillSurvey.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.BackColor = System.Drawing.Color.Blue;
            this.btnViewResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewResults.ForeColor = System.Drawing.Color.White;
            this.btnViewResults.Location = new System.Drawing.Point(97, 161);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(341, 50);
            this.btnViewResults.TabIndex = 1;
            this.btnViewResults.Text = "View Survey Results";
            this.btnViewResults.UseVisualStyleBackColor = false;
            this.btnViewResults.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Home Page";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.btnFillSurvey);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SURVEY APP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFillSurvey;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.Label label1;
    }
}