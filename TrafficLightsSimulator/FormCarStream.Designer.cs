namespace TrafficLight
{
    partial class FormCarStream
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
            this.nmNrCars = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnCreateOrEdit = new System.Windows.Forms.Button();
            this.gpNewStream = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmNrCars)).BeginInit();
            this.gpNewStream.SuspendLayout();
            this.SuspendLayout();
            // 
            // nmNrCars
            // 
            this.nmNrCars.Location = new System.Drawing.Point(116, 19);
            this.nmNrCars.Name = "nmNrCars";
            this.nmNrCars.Size = new System.Drawing.Size(74, 27);
            this.nmNrCars.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of cars";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "End";
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEnd.Location = new System.Drawing.Point(115, 54);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 28);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text = "Select";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnCreateOrEdit
            // 
            this.btnCreateOrEdit.Location = new System.Drawing.Point(15, 88);
            this.btnCreateOrEdit.Name = "btnCreateOrEdit";
            this.btnCreateOrEdit.Size = new System.Drawing.Size(175, 31);
            this.btnCreateOrEdit.TabIndex = 6;
            this.btnCreateOrEdit.Text = "Create";
            this.btnCreateOrEdit.UseVisualStyleBackColor = true;
            this.btnCreateOrEdit.Click += new System.EventHandler(this.button3_Click);
            // 
            // gpNewStream
            // 
            this.gpNewStream.Controls.Add(this.nmNrCars);
            this.gpNewStream.Controls.Add(this.btnCreateOrEdit);
            this.gpNewStream.Controls.Add(this.label1);
            this.gpNewStream.Controls.Add(this.btnEnd);
            this.gpNewStream.Controls.Add(this.label3);
            this.gpNewStream.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpNewStream.Location = new System.Drawing.Point(8, 11);
            this.gpNewStream.Name = "gpNewStream";
            this.gpNewStream.Size = new System.Drawing.Size(200, 133);
            this.gpNewStream.TabIndex = 7;
            this.gpNewStream.TabStop = false;
            this.gpNewStream.Text = "Stream Properties";
            // 
            // FormCarStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 169);
            this.Controls.Add(this.gpNewStream);
            this.Name = "FormCarStream";
            this.Text = "NewCarStream";
            ((System.ComponentModel.ISupportInitialize)(this.nmNrCars)).EndInit();
            this.gpNewStream.ResumeLayout(false);
            this.gpNewStream.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmNrCars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnCreateOrEdit;
        private System.Windows.Forms.GroupBox gpNewStream;
    }
}