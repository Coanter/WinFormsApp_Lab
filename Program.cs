using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace WinFormsApp
{
    public class MainForm : Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button selectFolderButton;
        private TextBox pathTextBox;
        private ListBox folderListBox;
        private DataGridView filesDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Button processFilesButton;

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size((int)(Screen.PrimaryScreen.WorkingArea.Width * 0.75), (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.75));
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            selectFolderButton = new Button();
            pathTextBox = new TextBox();
            folderListBox = new ListBox();
            filesDataGridView = new DataGridView();
            processFilesButton = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(986, 28);
            menuStrip1.TabIndex = 0;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(64, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // selectFolderButton
            // 
            selectFolderButton.Location = new Point(10, 40);
            selectFolderButton.Name = "selectFolderButton";
            selectFolderButton.Size = new Size(75, 23);
            selectFolderButton.TabIndex = 1;
            selectFolderButton.Text = "Select Folder";
            selectFolderButton.Click += SelectFolderButton_Click;
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(10, 70);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.ReadOnly = true;
            pathTextBox.Size = new Size(282, 27);
            pathTextBox.TabIndex = 2;
            // 
            // folderListBox
            // 
            folderListBox.Location = new Point(10, 100);
            folderListBox.Name = "folderListBox";
            folderListBox.Size = new Size(200, 244);
            folderListBox.TabIndex = 3;
            folderListBox.DoubleClick += FolderListBox_DoubleClick;
            // 
            // filesDataGridView
            // 
            filesDataGridView.ColumnHeadersHeight = 29;
            filesDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            filesDataGridView.Location = new Point(216, 100);
            filesDataGridView.Name = "filesDataGridView";
            filesDataGridView.RowHeadersWidth = 51;
            filesDataGridView.Size = new Size(628, 253);
            filesDataGridView.TabIndex = 4;
            filesDataGridView.CellDoubleClick += FilesDataGridView_CellDoubleClick;
            // 
            // processFilesButton
            // 
            processFilesButton.Location = new Point(10, 253);
            processFilesButton.Name = "processFilesButton";
            processFilesButton.Size = new Size(75, 23);
            processFilesButton.TabIndex = 5;
            processFilesButton.Text = "Process Files";
            processFilesButton.Visible = false;
            processFilesButton.Click += ProcessFilesButton_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Last Modified";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Size (Bytes)";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Delay (Seconds)";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // MainForm
            // 
            ClientSize = new Size(986, 471);
            Controls.Add(menuStrip1);
            Controls.Add(selectFolderButton);
            Controls.Add(pathTextBox);
            Controls.Add(folderListBox);
            Controls.Add(filesDataGridView);
            Controls.Add(processFilesButton);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)filesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer: Your Name\nContact: your.email@example.com", "About");
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = fbd.SelectedPath;
                    pathTextBox.Text = selectedPath;
                    PopulateFolderListBox(selectedPath);
                    PopulateFilesDataGridView(selectedPath);
                    processFilesButton.Visible = true;
                }
            }
        }

        private void PopulateFolderListBox(string path)
        {
            folderListBox.Items.Clear();
            string[] directories = Directory.GetDirectories(path);
            foreach (string dir in directories)
            {
                folderListBox.Items.Add(Path.GetFileName(dir));
            }
        }

        private void PopulateFilesDataGridView(string path)
        {
            filesDataGridView.Rows.Clear();
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                filesDataGridView.Rows.Add(fileInfo.Name, fileInfo.LastWriteTime, fileInfo.Length);
            }
        }

        private void FolderListBox_DoubleClick(object sender, EventArgs e)
        {
            if (folderListBox.SelectedItem != null)
            {
                string selectedFolder = folderListBox.SelectedItem.ToString();
                string folderPath = Path.Combine(pathTextBox.Text, selectedFolder);
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
                Form2 newform = new Form2(dirInfo.Name, dirInfo.LastWriteTime.ToString());
                newform.Show();
            }
        }

        private void FilesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string fileName = filesDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string filePath = Path.Combine(pathTextBox.Text, fileName);

                DialogResult result = MessageBox.Show("Do you want to duplicate this file?", "Duplicate File", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string newFileName = Path.Combine(pathTextBox.Text, Path.GetFileNameWithoutExtension(fileName) + "_copy" + Path.GetExtension(fileName));
                    File.Copy(filePath, newFileName);
                    PopulateFilesDataGridView(pathTextBox.Text);
                }
            }
        }

        private async void ProcessFilesButton_Click(object sender, EventArgs e)
        {
            int fileCount = filesDataGridView.Rows.Count;
            Random random = new Random();

            for (int i = 0; i < fileCount; i++)
            {
                int delaySeconds = random.Next(1, fileCount + 1);
                int rowIndex = i;

                Task.Run(async () =>
                {
                    await Task.Delay(delaySeconds * 1000);
                    this.Invoke((Action)(() =>
                    {
                        filesDataGridView.Rows[rowIndex].Cells["Delay"].Value = delaySeconds;
                    }));
                });
            }
        }
        private void folderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
