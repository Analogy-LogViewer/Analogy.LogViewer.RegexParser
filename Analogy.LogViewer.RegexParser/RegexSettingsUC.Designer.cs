namespace Analogy.LogViewer.RegexParser
{
    partial class RegexSettingsUC
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExportSettings = new System.Windows.Forms.Button();
            this.txtbSupportedFiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtbDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.tcSetttings = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtbGuidFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstbRegularExpressions = new System.Windows.Forms.ListBox();
            this.gbresult = new System.Windows.Forms.GroupBox();
            this.lblResultMessage = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtbTest = new System.Windows.Forms.TextBox();
            this.lblLogTest = new System.Windows.Forms.Label();
            this.txtbDateTimeFormat = new System.Windows.Forms.TextBox();
            this.txtbRegEx = new System.Windows.Forms.TextBox();
            this.lblDateTimeFormat = new System.Windows.Forms.Label();
            this.lblRegex = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtbOpenFileFilters = new System.Windows.Forms.TextBox();
            this.lblOpenfilesFilters = new System.Windows.Forms.Label();
            this.tcSetttings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbresult.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(964, 707);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 47);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExportSettings
            // 
            this.btnExportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSettings.Location = new System.Drawing.Point(825, 707);
            this.btnExportSettings.Name = "btnExportSettings";
            this.btnExportSettings.Size = new System.Drawing.Size(133, 47);
            this.btnExportSettings.TabIndex = 2;
            this.btnExportSettings.Text = "Export Settings";
            this.btnExportSettings.UseVisualStyleBackColor = true;
            this.btnExportSettings.Click += new System.EventHandler(this.btnExportSettings_Click);
            // 
            // txtbSupportedFiles
            // 
            this.txtbSupportedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSupportedFiles.Location = new System.Drawing.Point(197, 73);
            this.txtbSupportedFiles.Name = "txtbSupportedFiles";
            this.txtbSupportedFiles.Size = new System.Drawing.Size(899, 26);
            this.txtbSupportedFiles.TabIndex = 9;
            this.txtbSupportedFiles.Text = "*.Clef";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 50);
            this.label2.TabIndex = 8;
            this.label2.Text = "Supported Log Formats (use ; as separator):";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(682, 707);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(137, 47);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "Import settings";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtbDirectory
            // 
            this.txtbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbDirectory.Location = new System.Drawing.Point(197, 8);
            this.txtbDirectory.Name = "txtbDirectory";
            this.txtbDirectory.Size = new System.Drawing.Size(858, 26);
            this.txtbDirectory.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Default Logs Location:";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(1063, 8);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(33, 22);
            this.btnOpenFolder.TabIndex = 13;
            this.btnOpenFolder.Text = "..";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // tcSetttings
            // 
            this.tcSetttings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSetttings.Controls.Add(this.tabPage2);
            this.tcSetttings.Location = new System.Drawing.Point(6, 129);
            this.tcSetttings.Name = "tcSetttings";
            this.tcSetttings.SelectedIndex = 0;
            this.tcSetttings.Size = new System.Drawing.Size(1090, 572);
            this.tcSetttings.TabIndex = 45;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtbGuidFormat);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnDelete);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.lstbRegularExpressions);
            this.tabPage2.Controls.Add(this.gbresult);
            this.tabPage2.Controls.Add(this.txtbTest);
            this.tabPage2.Controls.Add(this.lblLogTest);
            this.tabPage2.Controls.Add(this.txtbDateTimeFormat);
            this.tabPage2.Controls.Add(this.txtbRegEx);
            this.tabPage2.Controls.Add(this.lblDateTimeFormat);
            this.tabPage2.Controls.Add(this.lblRegex);
            this.tabPage2.Controls.Add(this.btnTest);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1082, 541);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Text file - Regular Expression Parser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtbGuidFormat
            // 
            this.txtbGuidFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbGuidFormat.Location = new System.Drawing.Point(652, 78);
            this.txtbGuidFormat.Name = "txtbGuidFormat";
            this.txtbGuidFormat.Size = new System.Drawing.Size(360, 26);
            this.txtbGuidFormat.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 47);
            this.label1.TabIndex = 57;
            this.label1.Text = "Guid Format (The format parameter can be \"N\", \"D\", \"B\", \"P\", or \"X\". If format is" +
    " null or an empty string (\"\"), \"D\" is used):";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(986, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 25);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(1029, 76);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(47, 25);
            this.btnAdd.TabIndex = 55;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstbRegularExpressions
            // 
            this.lstbRegularExpressions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstbRegularExpressions.FormattingEnabled = true;
            this.lstbRegularExpressions.ItemHeight = 18;
            this.lstbRegularExpressions.Location = new System.Drawing.Point(9, 131);
            this.lstbRegularExpressions.Name = "lstbRegularExpressions";
            this.lstbRegularExpressions.Size = new System.Drawing.Size(965, 130);
            this.lstbRegularExpressions.TabIndex = 54;
            // 
            // gbresult
            // 
            this.gbresult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbresult.Controls.Add(this.lblResultMessage);
            this.gbresult.Controls.Add(this.lblResult);
            this.gbresult.Location = new System.Drawing.Point(9, 294);
            this.gbresult.Name = "gbresult";
            this.gbresult.Size = new System.Drawing.Size(965, 235);
            this.gbresult.TabIndex = 52;
            this.gbresult.TabStop = false;
            this.gbresult.Text = "Result";
            // 
            // lblResultMessage
            // 
            this.lblResultMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResultMessage.Location = new System.Drawing.Point(3, 41);
            this.lblResultMessage.Name = "lblResultMessage";
            this.lblResultMessage.Size = new System.Drawing.Size(959, 191);
            this.lblResultMessage.TabIndex = 31;
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResult.Location = new System.Drawing.Point(3, 22);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(959, 19);
            this.lblResult.TabIndex = 30;
            // 
            // txtbTest
            // 
            this.txtbTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbTest.Location = new System.Drawing.Point(119, 266);
            this.txtbTest.Name = "txtbTest";
            this.txtbTest.Size = new System.Drawing.Size(855, 26);
            this.txtbTest.TabIndex = 51;
            // 
            // lblLogTest
            // 
            this.lblLogTest.AccessibleDescription = "";
            this.lblLogTest.AutoSize = true;
            this.lblLogTest.Location = new System.Drawing.Point(6, 269);
            this.lblLogTest.Name = "lblLogTest";
            this.lblLogTest.Size = new System.Drawing.Size(109, 18);
            this.lblLogTest.TabIndex = 50;
            this.lblLogTest.Text = "Log line to test:";
            // 
            // txtbDateTimeFormat
            // 
            this.txtbDateTimeFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbDateTimeFormat.Location = new System.Drawing.Point(188, 37);
            this.txtbDateTimeFormat.Name = "txtbDateTimeFormat";
            this.txtbDateTimeFormat.Size = new System.Drawing.Size(888, 26);
            this.txtbDateTimeFormat.TabIndex = 48;
            this.txtbDateTimeFormat.Text = "yyyy-MM-dd HH:mm:ss,fff";
            // 
            // txtbRegEx
            // 
            this.txtbRegEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbRegEx.Location = new System.Drawing.Point(188, 6);
            this.txtbRegEx.Name = "txtbRegEx";
            this.txtbRegEx.Size = new System.Drawing.Size(888, 26);
            this.txtbRegEx.TabIndex = 49;
            // 
            // lblDateTimeFormat
            // 
            this.lblDateTimeFormat.AccessibleDescription = "";
            this.lblDateTimeFormat.AutoSize = true;
            this.lblDateTimeFormat.Location = new System.Drawing.Point(6, 45);
            this.lblDateTimeFormat.Name = "lblDateTimeFormat";
            this.lblDateTimeFormat.Size = new System.Drawing.Size(149, 18);
            this.lblDateTimeFormat.TabIndex = 46;
            this.lblDateTimeFormat.Text = "DateTime log format:";
            // 
            // lblRegex
            // 
            this.lblRegex.AccessibleDescription = "";
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(6, 10);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(163, 18);
            this.lblRegex.TabIndex = 47;
            this.lblRegex.Text = "Log Regular Expression:";
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(1029, 266);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(47, 25);
            this.btnTest.TabIndex = 44;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtbOpenFileFilters
            // 
            this.txtbOpenFileFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbOpenFileFilters.Location = new System.Drawing.Point(197, 42);
            this.txtbOpenFileFilters.Name = "txtbOpenFileFilters";
            this.txtbOpenFileFilters.Size = new System.Drawing.Size(899, 26);
            this.txtbOpenFileFilters.TabIndex = 47;
            // 
            // lblOpenfilesFilters
            // 
            this.lblOpenfilesFilters.AutoEllipsis = true;
            this.lblOpenfilesFilters.Location = new System.Drawing.Point(7, 42);
            this.lblOpenfilesFilters.Name = "lblOpenfilesFilters";
            this.lblOpenfilesFilters.Size = new System.Drawing.Size(184, 22);
            this.lblOpenfilesFilters.TabIndex = 46;
            this.lblOpenfilesFilters.Text = "Open file Filter:";
            // 
            // RegexSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtbOpenFileFilters);
            this.Controls.Add(this.lblOpenfilesFilters);
            this.Controls.Add(this.tcSetttings);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.txtbDirectory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtbSupportedFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExportSettings);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "RegexSettingsUC";
            this.Size = new System.Drawing.Size(1100, 757);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tcSetttings.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbresult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExportSettings;
        private System.Windows.Forms.TextBox txtbSupportedFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtbDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TabControl tcSetttings;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtbGuidFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstbRegularExpressions;
        private System.Windows.Forms.GroupBox gbresult;
        private System.Windows.Forms.Label lblResultMessage;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtbTest;
        private System.Windows.Forms.Label lblLogTest;
        private System.Windows.Forms.TextBox txtbDateTimeFormat;
        private System.Windows.Forms.TextBox txtbRegEx;
        private System.Windows.Forms.Label lblDateTimeFormat;
        private System.Windows.Forms.Label lblRegex;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtbOpenFileFilters;
        private System.Windows.Forms.Label lblOpenfilesFilters;
    }
}
