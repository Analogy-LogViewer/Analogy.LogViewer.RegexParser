using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.RegexParser.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.LogViewer.RegexParser
{
    public partial class RegexSettingsUC : UserControl
    {
        private RegexSettings Settings => UserSettingsManager.UserSettings.Settings;
        public RegexSettingsUC()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        public void SaveSettings()
        {
            Settings.Directory = txtbDirectory.Text;
            Settings.FileOpenDialogFilters = txtbOpenFileFilters.Text;
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
                    File.WriteAllText(saveFileDialog.FileName, System.Text.Json.JsonSerializer.Serialize(Settings));
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
                    RegexSettings settings = System.Text.Json.JsonSerializer.Deserialize<RegexSettings>(json);
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
            txtbSupportedFiles.Text = string.Join(";", logSettings.SupportFormats);
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

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadSettings(UserSettingsManager.UserSettings.Settings);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbRegEx.Text) || string.IsNullOrEmpty(txtbSupportedFiles.Text))
            {
                return;
            }

            var files = GetFiles();
            var rp = new RegexPattern(txtbRegEx.Text, txtbDateTimeFormat.Text, txtbGuidFormat.Text, files);
            lstbRegularExpressions.Items.Add(rp);
        }

        private List<string> GetFiles()
        {
            var files = txtbSupportedFiles.Text.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return files;
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
            var files = GetFiles();
            RegexPattern p = new RegexPattern(txtbRegEx.Text, txtbDateTimeFormat.Text, "", files);
            bool valid = AnalogyRegexParser.CheckRegex(txtbTest.Text, p, out AnalogyLogMessage m);
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

        private void btnTestFilter_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = txtbOpenFileFilters.Text,
                    Title = @"Test Open Files",
                    Multiselect = true,
                };
                openFileDialog1.ShowDialog(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Incorrect filter: {exception.Message}", "Invalid filter text", MessageBoxButtons.OK);
            }
        }

        private void lstbRegularExpressions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbRegularExpressions.SelectedItem is RegexPattern regexPattern)
            {
                txtbRegEx.Text = regexPattern.Pattern;
                txtbDateTimeFormat.Text = regexPattern.DateTimeFormat;
                txtbGuidFormat.Text = regexPattern.GuidFormat;
                txtbSupportedFiles.Text = string.Join(";", regexPattern.SupportFormats);
            }
        }
    }
}