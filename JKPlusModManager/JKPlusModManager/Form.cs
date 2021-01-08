using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using static JKPlusModManager.ParseData;

namespace JKPlusModManager
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            checkFolder();
            ifFolder();
        }
        private void checkFolder()
        {
            if (Directory.Exists(textBoxFolder.Text + "\\Content\\mods"))
            {
                Program.ModsFolder = true;
            } else
            {
                Program.ModsFolder = false;
            }

            if (File.Exists(textBoxFolder.Text + "\\Content\\mods\\mod.xml") && File.Exists(textBoxFolder.Text + "\\Content\\mods\\level.xnb"))
            {
                Program.CustomMod = true;
            } else
            {
                Program.CustomMod = false;
            }
        }

        private void ifFolder()
        {
            if (Program.ModsFolder)
            {
                var files = Directory.EnumerateFiles(textBoxFolder.Text + "\\Content\\mods", "*", SearchOption.AllDirectories);
                long sum = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();

                labelFolder.Text = textBoxFolder.Text + "\\Content\\mods";
                labelSize.Text = (sum/1048576).ToString()+" MB ("+sum.ToString()+" bytes)";
                
                if (!Program.CustomMod)
                {
                    labelName.Text = "No mod installed.";
                    buttonNewMod.Enabled = true;
                    buttonLoad.Enabled = true;
                    buttonUnload.Enabled = false;
                } else
                {
                    Program.CurrentMod = XmlSerializerHelper.Deserialize<Mod>(labelFolder.Text + "/mod.xml");
                    labelName.Text = Program.CurrentMod.About.title;
                    buttonNewMod.Enabled = false;
                    buttonLoad.Enabled = false;
                    buttonUnload.Enabled = true;
                }
                
            } else
            {
                labelFolder.Text = "mod folder";
                labelName.Text = "mod name";
                labelSize.Text = "mod size";
                buttonUnload.Enabled = false;
                buttonNewMod.Enabled = false;
                buttonLoad.Enabled = false;
            }
        }

        private void ifNewFolder()
        {
            var files = Directory.EnumerateFiles(textBoxNewFolder.Text, "*", SearchOption.AllDirectories);
            long sum = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();
            labelNewFolder.Text = textBoxNewFolder.Text;
            labelNewSize.Text = (sum / 1048576).ToString() + " MB (" + sum.ToString() + " bytes)";
            Program.NewMod = XmlSerializerHelper.Deserialize<Mod>(labelNewFolder.Text + "/mod.xml");
            labelNewName.Text = Program.NewMod.About.title;
        }

        private void buttonChangeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFolder.Text = folderBrowserDialog1.SelectedPath;
            }
            checkFolder();
            ifFolder();
        }

        private void textBoxFolder_TextChanged(object sender, EventArgs e)
        {
            checkFolder();
            ifFolder();
        }

        private void buttonUnload_Click(object sender, EventArgs e)
        {
            Directory.Delete(textBoxFolder.Text + "\\Content\\mods", true);
            progressBar1.Value = 50;
            System.Threading.Thread.Sleep(500);
            Directory.CreateDirectory(textBoxFolder.Text + "\\Content\\mods");
            progressBar1.Value = 100;
            DialogResult result = MessageBox.Show("Successfully cleared!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                progressBar1.Value = 0;
            }
            checkFolder();
            ifFolder();
        }

        private void buttonNewMod_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBoxNewFolder.Text = folderBrowserDialog2.SelectedPath;
            }
            checkFolder();
            ifNewFolder();
        }

        private void textBoxNewFolder_TextChanged(object sender, EventArgs e)
        {
            checkFolder();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Directory.Delete(textBoxFolder.Text + "\\Content\\mods", true);
            progressBar1.Value = 50;
            System.Threading.Thread.Sleep(500);
            Directory.Move(textBoxNewFolder.Text, textBoxFolder.Text + "\\Content\\mods");
            progressBar1.Value = 100;
            DialogResult result = MessageBox.Show("Successfully added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                progressBar1.Value = 0;
                textBoxNewFolder.Text = "";
                labelNewFolder.Text = "mod folder";
                labelNewName.Text = "mod name";
                labelNewSize.Text = "mod size";
            }
            checkFolder();
            ifFolder();
        }
    }
}
