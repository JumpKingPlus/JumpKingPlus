namespace JKPlusModManager
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonChangeFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUnload = new System.Windows.Forms.Button();
            this.labelFolder = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelNewSize = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.labelNewName = new System.Windows.Forms.Label();
            this.buttonNewMod = new System.Windows.Forms.Button();
            this.labelNewFolder = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNewFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 272);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(395, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxFolder.Location = new System.Drawing.Point(6, 19);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(286, 20);
            this.textBoxFolder.TabIndex = 1;
            this.textBoxFolder.Text = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Jump King";
            this.textBoxFolder.TextChanged += new System.EventHandler(this.textBoxFolder_TextChanged);
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.Location = new System.Drawing.Point(298, 17);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.Size = new System.Drawing.Size(91, 23);
            this.buttonChangeFolder.TabIndex = 2;
            this.buttonChangeFolder.Text = "Change folder";
            this.buttonChangeFolder.UseVisualStyleBackColor = true;
            this.buttonChangeFolder.Click += new System.EventHandler(this.buttonChangeFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.buttonChangeFolder);
            this.groupBox1.Controls.Add(this.textBoxFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jump King folder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelSize);
            this.groupBox2.Controls.Add(this.labelName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonUnload);
            this.groupBox2.Controls.Add(this.labelFolder);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 83);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current mod";
            // 
            // labelSize
            // 
            this.labelSize.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSize.Location = new System.Drawing.Point(68, 61);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(240, 13);
            this.labelSize.TabIndex = 6;
            this.labelSize.Text = "mod size";
            // 
            // labelName
            // 
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelName.Location = new System.Drawing.Point(68, 41);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(321, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "mod name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folder:";
            // 
            // buttonUnload
            // 
            this.buttonUnload.Enabled = false;
            this.buttonUnload.Location = new System.Drawing.Point(314, 54);
            this.buttonUnload.Name = "buttonUnload";
            this.buttonUnload.Size = new System.Drawing.Size(75, 23);
            this.buttonUnload.TabIndex = 0;
            this.buttonUnload.Text = "Unload";
            this.buttonUnload.UseVisualStyleBackColor = true;
            this.buttonUnload.Click += new System.EventHandler(this.buttonUnload_Click);
            // 
            // labelFolder
            // 
            this.labelFolder.BackColor = System.Drawing.SystemColors.Control;
            this.labelFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelFolder.Location = new System.Drawing.Point(71, 21);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(318, 13);
            this.labelFolder.TabIndex = 7;
            this.labelFolder.Text = "mod folder";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelNewSize);
            this.groupBox3.Controls.Add(this.buttonLoad);
            this.groupBox3.Controls.Add(this.labelNewName);
            this.groupBox3.Controls.Add(this.buttonNewMod);
            this.groupBox3.Controls.Add(this.labelNewFolder);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBoxNewFolder);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(12, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 106);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Load new mod";
            // 
            // labelNewSize
            // 
            this.labelNewSize.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelNewSize.Location = new System.Drawing.Point(68, 84);
            this.labelNewSize.Name = "labelNewSize";
            this.labelNewSize.Size = new System.Drawing.Size(240, 13);
            this.labelNewSize.TabIndex = 12;
            this.labelNewSize.Text = "mod size";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Enabled = false;
            this.buttonLoad.Location = new System.Drawing.Point(314, 77);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // labelNewName
            // 
            this.labelNewName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelNewName.Location = new System.Drawing.Point(68, 64);
            this.labelNewName.Name = "labelNewName";
            this.labelNewName.Size = new System.Drawing.Size(321, 13);
            this.labelNewName.TabIndex = 11;
            this.labelNewName.Text = "mod name";
            // 
            // buttonNewMod
            // 
            this.buttonNewMod.Enabled = false;
            this.buttonNewMod.Location = new System.Drawing.Point(287, 17);
            this.buttonNewMod.Name = "buttonNewMod";
            this.buttonNewMod.Size = new System.Drawing.Size(102, 23);
            this.buttonNewMod.TabIndex = 4;
            this.buttonNewMod.Text = "Select new mod";
            this.buttonNewMod.UseVisualStyleBackColor = true;
            this.buttonNewMod.Click += new System.EventHandler(this.buttonNewMod_Click);
            // 
            // labelNewFolder
            // 
            this.labelNewFolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelNewFolder.Location = new System.Drawing.Point(68, 44);
            this.labelNewFolder.Name = "labelNewFolder";
            this.labelNewFolder.Size = new System.Drawing.Size(321, 13);
            this.labelNewFolder.TabIndex = 10;
            this.labelNewFolder.Text = "mod folder";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Size:";
            // 
            // textBoxNewFolder
            // 
            this.textBoxNewFolder.Location = new System.Drawing.Point(6, 19);
            this.textBoxNewFolder.Name = "textBoxNewFolder";
            this.textBoxNewFolder.ReadOnly = true;
            this.textBoxNewFolder.Size = new System.Drawing.Size(275, 20);
            this.textBoxNewFolder.TabIndex = 3;
            this.textBoxNewFolder.TextChanged += new System.EventHandler(this.textBoxNewFolder_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Folder:";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(419, 307);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "JKPlusModManager v0.1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonChangeFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonUnload;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonNewMod;
        private System.Windows.Forms.TextBox textBoxNewFolder;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNewSize;
        private System.Windows.Forms.Label labelNewName;
        private System.Windows.Forms.Label labelNewFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox labelFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
    }
}

