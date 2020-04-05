using DamageParser.ClientApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamageParser
{
    public partial class RaidParser : Form
    {
        private string CharacterName { get; set; }
        private FightOverlay _overlay { get; set; }
        private FightOverlayPosition _fightOverlayPosition { get; set; }
        public RaidParser()
        {
            InitializeComponent();
            _overlay = new FightOverlay("");

            if (displayOverlayCheckBox.Checked)
            {
                _overlay.Show();
            }
        }

        private void FileUploadButton_Click(object sender, EventArgs e)
        {
            if (logFileUploadDialog.ShowDialog() == DialogResult.OK)
            {
                SetUploadFileName(logFileUploadDialog.SafeFileName);
                CharacterName = GetCharacterName(logFileUploadDialog.SafeFileName);
                _overlay.PlayerName = CharacterName;

                FileWatcher fileWatcher = new FileWatcher(logFileUploadDialog.FileName, logFileUploadDialog.SafeFileName);
                Thread fileWatcherThread = new Thread(() => fileWatcher.Start());
                fileWatcherThread.Start();

                BattleWatcher battleWatcher = new BattleWatcher(fileWatcher, CharacterName);
                Thread battleWatcherThread = new Thread(() => battleWatcher.Start());
                battleWatcherThread.Start();

                PetWatcher petWatcher = new PetWatcher(fileWatcher, battleWatcher, CharacterName);
                Thread petWatcherThread = new Thread(() => petWatcher.Start());
                petWatcherThread.Start();

                _overlay.AddBattleWatcher(battleWatcher);
            }
        }

        private string GetCharacterName(string logFile)
        {
            if(Regex.IsMatch(logFile, EnumsAndConstants.LogFileCharNameRegex))
            {
                Match matches = Regex.Match(logFile, EnumsAndConstants.LogFileCharNameRegex);
                return matches.Groups[1].Value;
            }
            else
            {
                throw new FileLoadException($"Invalid log file: {logFile}");
            }
        }

        private void SetUploadFileName(string text)
        {
            fileUploadLabel.Text = text;
        }

        private void DisplayOverlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (displayOverlayCheckBox.Checked)
                _overlay.Show();
            else
                _overlay.Hide();
        }

        private void SetOverlayPositionButton_Click(object sender, EventArgs e)
        {
            _fightOverlayPosition = new FightOverlayPosition();
            _fightOverlayPosition.FormClosing += OutputPositionerThing;
            _fightOverlayPosition.Show();
            _fightOverlayPosition.UpdateDimensions(_overlay);
        }

        private void OutputPositionerThing(object sender, EventArgs e)
        {
            _overlay.Width = _fightOverlayPosition.Width;
            _overlay.Height = _fightOverlayPosition.Height;
            _overlay.Location = new Point(_fightOverlayPosition.Location.X, _fightOverlayPosition.Location.Y);
        }

        private void RaidIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateRaidIdButton_Click(object sender, EventArgs e)
        {

        }

        private void ResetOverlayButton_Click(object sender, EventArgs e)
        {
            _overlay.Location = new Point(100, 100);
            _overlay.Width = 500;
            _overlay.Height = 300;
        }

        private void RaidParser_Load(object sender, EventArgs e)
        {

        }
    }
}
