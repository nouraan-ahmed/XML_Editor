
namespace XML_Project
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formattingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtArea = new FastColoredTextBoxNS.FastColoredTextBox();
            this.output_txt = new FastColoredTextBoxNS.FastColoredTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_txt)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.compressToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(990, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formattingToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.formatToolStripMenuItem.Text = "Format";
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // formattingToolStripMenuItem
            // 
            this.formattingToolStripMenuItem.Name = "formattingToolStripMenuItem";
            this.formattingToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.formattingToolStripMenuItem.Text = "Formatting";
            this.formattingToolStripMenuItem.Click += new System.EventHandler(this.formattingToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToJSONToolStripMenuItem});
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.convertToolStripMenuItem.Text = "Convert";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // ToJSONToolStripMenuItem
            // 
            this.ToJSONToolStripMenuItem.Name = "ToJSONToolStripMenuItem";
            this.ToJSONToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.ToJSONToolStripMenuItem.Text = "To JSON";
            this.ToJSONToolStripMenuItem.Click += new System.EventHandler(this.ToJSONToolStripMenuItem_Click);
            // 
            // compressToolStripMenuItem
            // 
            this.compressToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.fileSizeToolStripMenuItem});
            this.compressToolStripMenuItem.Name = "compressToolStripMenuItem";
            this.compressToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.compressToolStripMenuItem.Text = "Compress";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.dataToolStripMenuItem.Text = "Data";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // fileSizeToolStripMenuItem
            // 
            this.fileSizeToolStripMenuItem.Name = "fileSizeToolStripMenuItem";
            this.fileSizeToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.fileSizeToolStripMenuItem.Text = "File Size";
            this.fileSizeToolStripMenuItem.Click += new System.EventHandler(this.fileSizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(79, 24);
            this.toolStripMenuItem1.Text = "Compile";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(188, 26);
            this.toolStripMenuItem2.Text = "Error_handling";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtArea);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.output_txt);
            this.splitContainer1.Size = new System.Drawing.Size(990, 422);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 8;
            // 
            // txtArea
            // 
            this.txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArea.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtArea.AutoScrollMinSize = new System.Drawing.Size(221, 18);
            this.txtArea.BackBrush = null;
            this.txtArea.CharHeight = 18;
            this.txtArea.CharWidth = 10;
            this.txtArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArea.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtArea.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtArea.IsReplaceMode = false;
            this.txtArea.Location = new System.Drawing.Point(3, 3);
            this.txtArea.Name = "txtArea";
            this.txtArea.Paddings = new System.Windows.Forms.Padding(0);
            this.txtArea.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtArea.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtArea.ServiceColors")));
            this.txtArea.Size = new System.Drawing.Size(378, 416);
            this.txtArea.TabIndex = 0;
            this.txtArea.Text = "fastColoredTextBox1";
            this.txtArea.Zoom = 100;
            // 
            // output_txt
            // 
            this.output_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output_txt.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.output_txt.AutoScrollMinSize = new System.Drawing.Size(221, 18);
            this.output_txt.BackBrush = null;
            this.output_txt.CharHeight = 18;
            this.output_txt.CharWidth = 10;
            this.output_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.output_txt.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.output_txt.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.output_txt.IsReplaceMode = false;
            this.output_txt.Location = new System.Drawing.Point(3, 3);
            this.output_txt.Name = "output_txt";
            this.output_txt.Paddings = new System.Windows.Forms.Padding(0);
            this.output_txt.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.output_txt.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("output_txt.ServiceColors")));
            this.output_txt.Size = new System.Drawing.Size(596, 416);
            this.output_txt.TabIndex = 0;
            this.output_txt.Text = "fastColoredTextBox2";
            this.output_txt.Zoom = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.output_txt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formattingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FastColoredTextBoxNS.FastColoredTextBox txtArea;
        private FastColoredTextBoxNS.FastColoredTextBox output_txt;
    }
}

