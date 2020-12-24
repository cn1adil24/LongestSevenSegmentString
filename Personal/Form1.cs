using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal
{
    public partial class Form1 : Form
    {
        private List<char> AlphabetsNotSupported;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private string LongestWord = string.Empty;
        private string CurrentState = LocalizedStrings.Stopped;
        private long currentProgress = 0;
        CancellationTokenSource CancellationToken;

        public Form1()
        {
            InitializeComponent();
            AlphabetsNotSupported = new List<char>
            {
                'g', 'k', 'm', 'n', 'q', 'v', 'w', 'y', 'z'
            };
            openFileDialog.Filter = LocalizedStrings.FilterTxtFiles;
            buttonSelectFile.Click += ButtonSelectFile_Click;
            buttonCompute.Click += ButtonCompute_Click;
            buttonClipboard.Click += ButtonClipboard_Click;
        }

        private void ButtonSelectFile_Click(object sender, EventArgs e)
        {
            string filepath = GetFilePath();
            if (!string.IsNullOrWhiteSpace(filepath))
            {
                textBoxFilePath.Text = filepath;
            }
        }

        private async void ButtonCompute_Click(object sender, EventArgs e)
        {
            if (CurrentState.Equals(LocalizedStrings.Running))
            {
                CancellationToken.Cancel();
            }
            else
            {
                var file = openFileDialog.FileName;
                if (string.IsNullOrWhiteSpace(file))
                {
                    MessageBox.Show(LocalizedStrings.NoFilePathProvided, LocalizedStrings.Error,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                bool completed = false;
                var watch = System.Diagnostics.Stopwatch.StartNew();

                Initialize();

                try
                {
                    await ReadFileAsync(file);
                    completed = true;

                    watch.Stop();
                    MessageBox.Show(LocalizedStrings.ProcessCompletedSuccessfully, LocalizedStrings.Success,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(OperationCanceledException ex)
                {
                    watch.Stop();
                    MessageBox.Show(LocalizedStrings.ProcessStoppedSuccessfully, LocalizedStrings.Success,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    var elapsed = watch.ElapsedMilliseconds;

                    ShowResults(elapsed, completed);

                    CancellationToken.Dispose();
                }
            }
        }

        private void ButtonClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelResult.Text);
            MessageBox.Show(LocalizedStrings.CopiedToClipboard, LocalizedStrings.Success,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetFilePath()
        {
            string filepath = string.Empty;
            var response = openFileDialog.ShowDialog();

            if (response == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(openFileDialog.FileName))
                    return filepath;

                if (!openFileDialog.CheckPathExists)
                {
                    MessageBox.Show(LocalizedStrings.PathDoesNotExist, LocalizedStrings.InvalidFilePath,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!openFileDialog.CheckFileExists)
                {
                    MessageBox.Show(LocalizedStrings.FileDoesNotExist, LocalizedStrings.InvalidFilePath,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    filepath = Path.GetFullPath(openFileDialog.FileName);
            }

            return filepath;
        }
        private void Initialize()
        {
            labelElapsedTime.Visible = false;
            labelResult.Visible = false;
            buttonClipboard.Visible = false;

            labelProgress.Visible = true;

            CurrentState = LocalizedStrings.Running;
            buttonCompute.Text = "Stop";
            LongestWord = string.Empty;
        }
        private void ShowResults(long elapsed, bool completed)
        {
            if (completed)
            {
                labelElapsedTime.Text = string.Format(LocalizedStrings.ElapsedTimeT0Milliseconds, elapsed);
                labelElapsedTime.Visible = true;

                labelResult.Text = LongestWord;
                int x = labelResult.Width + labelResult.Location.X;
                buttonClipboard.Location = new Point(x, 62);

                labelResult.Visible = true;
                buttonClipboard.Visible = true;
            }

            labelProgress.Visible = false;
            currentProgress = 0;

            CurrentState = LocalizedStrings.Stopped;
            buttonCompute.Text = "Compute";
        }
        private async Task ReadFileAsync(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            long length = fileInfo.Length;
            CancellationToken = new CancellationTokenSource();

            // Progress<T> captures the UI context,
            // so it will update on the UI thread.
            var progress = new Progress<int>(percent =>
            {
                labelProgress.Text = string.Format(LocalizedStrings.ProgressP0Percent, percent);
            });
            
            await Task.Run(() => ReadAll(filepath, length, progress), CancellationToken.Token);
            
        }
        private void ReadAll(string filepath, long length, IProgress<int> progress)
        {
            var ct = CancellationToken.Token;
            ct.ThrowIfCancellationRequested();

            using (StreamReader reader = new StreamReader(filepath))
            {
                string word;
                int count = 0;

                while ((word = reader.ReadLine()) != null)
                {

                    if (ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                    }

                    Compare(word);
                    count++;
                    var value = GetProgressValue(word, length);

                    // Report after every 100 lines to avoid UI block
                    if (count % 100 == 0)
                    {
                        progress.Report(value);
                    }
                }
            }
        }

        private void Compare(string word)
        {
            lock (LongestWord)
            {
                var lword = word.ToLower();
                foreach (var alphabet in AlphabetsNotSupported)
                {
                    if (lword.Contains(alphabet))
                        return;
                }
                if (word.Length > LongestWord.Length)
                    LongestWord = word;
            }
        }

        private int GetProgressValue(string line, long length)
        {
            currentProgress += line.Length + "\r\n".Length;
            var value = (int)((decimal)currentProgress / length * 100);
            if (value > 100)
                value = 100;
            return value;
        }
    }
}
