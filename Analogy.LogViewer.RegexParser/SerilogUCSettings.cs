﻿using Analogy.Interfaces;
using Analogy.LogViewer.RegexParser.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.LogViewer.RegexParser
{
    public partial class SerilogUCSettings : UserControl
    {
        private RegexSettings Settings => UserSettingsManager.UserSettings.Settings;
        public SerilogUCSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        public void SaveSettings()
        {
#if NETCOREAPP3_1
            Settings.SupportFormats = txtbSupportedFiles.Text.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
#endif
#if !NETCOREAPP3_1
            Settings.SupportFormats = txtbSupportedFiles.Text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
#endif
            Settings.Directory = txtbDirectory.Text;
            Settings.FileOpenDialogFilters = txtbOpenFileFilters.Text;
            Settings.SupportFormats = txtbSupportedFiles.Text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Settings.RegexPatterns = lstbRegularExpressions.Items.Count > 0 ? lstbRegularExpressions.Items.Cast<RegexPattern>().ToList() : new List<RegexPattern>();
            UserSettingsManager.UserSettings.Save();
        }

        private void btnExportSettings_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Analogy Regex Settings (*.regexsettings)|*.regexsettings";
            saveFileDialog.Title = @"Export settings";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveSettings();
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(Settings));
                    MessageBox.Show("File Saved", @"Export settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Export: " + ex.Message, @"Error Saving file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Analogy Regex Settings (*.regexsettings)|*.regexsettings";
            openFileDialog1.Title = @"Import Regex settings";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog1.FileName);
                    RegexSettings settings = JsonConvert.DeserializeObject<RegexSettings>(json);
                    LoadSettings(settings);
                    MessageBox.Show("File Imported. Save settings if desired", @"Import settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Import: " + ex.Message, @"Error Import file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSettings(RegexSettings logSettings)
        {
            txtbDirectory.Text = Settings.Directory;
            txtbOpenFileFilters.Text = Settings.FileOpenDialogFilters;
            txtbSupportedFiles.Text = string.Join(";", Settings.SupportFormats.ToList());
            lstbRegularExpressions.Items.Clear();
            lstbRegularExpressions.Items.AddRange(Settings.RegexPatterns.ToArray());
            txtbDateTimeFormat.Text = Settings.RegexPatterns.First().DateTimeFormat;
            txtbSupportedFiles.Text = string.Join(";", logSettings.SupportFormats);
            rbtnCLEF.Checked = true;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtbDirectory.Text = fbd.SelectedPath;
                }
            }
        }

        private void NLogSettings_Load(object sender, EventArgs e)
        {
            LoadSettings(UserSettingsManager.UserSettings.Settings);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbRegEx.Text)) return;
            var rp = new RegexPattern(txtbRegEx.Text, txtbDateTimeFormat.Text, txtbGuidFormat.Text);
            lstbRegularExpressions.Items.Add(rp);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstbRegularExpressions.SelectedItem is RegexPattern regexPattern)
            {
                lstbRegularExpressions.Items.Remove(lstbRegularExpressions.SelectedItem);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            RegexPattern p = new RegexPattern(txtbRegEx.Text, txtbDateTimeFormat.Text, "");
            bool valid = RegexParser.CheckRegex(txtbTest.Text, p, out AnalogyLogMessage m);
            if (valid)
            {
                lblResult.Text = "Valid Regular Expression";
                lblResult.BackColor = Color.GreenYellow;
                lblResultMessage.Text = m.ToString();
            }
            else
            {
                lblResult.Text = "Non Valid Regular Expression";
                lblResult.BackColor = Color.OrangeRed;
            }
        }
    }
}
