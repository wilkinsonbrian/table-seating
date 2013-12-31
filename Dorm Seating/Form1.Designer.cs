namespace Dorm_Seating
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.saveText = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadStudents = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.loadStaff = new System.Windows.Forms.Button();
            this.createSeating = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.fileBox);
            this.flowLayoutPanel3.Controls.Add(this.saveText);
            this.flowLayoutPanel3.Controls.Add(this.button1);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(227, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel3, 2);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(330, 331);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(3, 3);
            this.fileBox.Multiline = true;
            this.fileBox.Name = "fileBox";
            this.fileBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fileBox.Size = new System.Drawing.Size(327, 265);
            this.fileBox.TabIndex = 0;
            // 
            // saveText
            // 
            this.saveText.AutoSize = true;
            this.saveText.Location = new System.Drawing.Point(3, 274);
            this.saveText.Name = "saveText";
            this.saveText.Size = new System.Drawing.Size(87, 23);
            this.saveText.TabIndex = 1;
            this.saveText.Text = "Save Changes";
            this.saveText.UseVisualStyleBackColor = true;
            this.saveText.Click += new System.EventHandler(this.saveText_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // loadStudents
            // 
            this.loadStudents.AutoSize = true;
            this.loadStudents.Location = new System.Drawing.Point(3, 3);
            this.loadStudents.Name = "loadStudents";
            this.loadStudents.Size = new System.Drawing.Size(112, 23);
            this.loadStudents.TabIndex = 0;
            this.loadStudents.Text = "Choose Student File";
            this.loadStudents.UseVisualStyleBackColor = true;
            this.loadStudents.Click += new System.EventHandler(this.loadStudentFile);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.loadStudents);
            this.flowLayoutPanel2.Controls.Add(this.loadStaff);
            this.flowLayoutPanel2.Controls.Add(this.createSeating);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 29);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(218, 133);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // loadStaff
            // 
            this.loadStaff.AutoSize = true;
            this.loadStaff.Location = new System.Drawing.Point(3, 32);
            this.loadStaff.Name = "loadStaff";
            this.loadStaff.Size = new System.Drawing.Size(112, 23);
            this.loadStaff.TabIndex = 0;
            this.loadStaff.Text = "Choose Staff File";
            this.loadStaff.UseVisualStyleBackColor = true;
            this.loadStaff.Click += new System.EventHandler(this.loadStaff_Click);
            // 
            // createSeating
            // 
            this.createSeating.AutoSize = true;
            this.createSeating.Location = new System.Drawing.Point(3, 61);
            this.createSeating.Name = "createSeating";
            this.createSeating.Size = new System.Drawing.Size(112, 23);
            this.createSeating.TabIndex = 1;
            this.createSeating.Text = "Create Seating";
            this.createSeating.UseVisualStyleBackColor = true;
            this.createSeating.Click += new System.EventHandler(this.createSeating_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Text files|*.txt|All files|*.*\"";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"Text files|*.txt|Word file|*.doc|All files|*.*\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Dorm Seating";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button loadStudents;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button loadStaff;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TextBox fileBox;
        private System.Windows.Forms.Button saveText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button createSeating;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

