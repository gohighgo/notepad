using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        string path;
        int counter = 0;
        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            this.Text = "New Text Document - Notepad";
          
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pageSetupToolStripMenuItem1_Click(object sender, EventArgs e)
        {


        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings =
        new System.Drawing.Printing.PageSettings();

            // Initialize dialog's PrinterSettings property to hold user
            // set printer settings.
            pageSetupDialog1.PrinterSettings =
                new System.Drawing.Printing.PrinterSettings();

            //Do not show the network in the printer dialog.
            pageSetupDialog1.ShowNetwork = false;

            //Show the dialog storing the result.
            DialogResult result = pageSetupDialog1.ShowDialog();

            // If the result is OK, display selected settings in
            // ListBox1. These values can be used when printing the
            // document.
            if (result == DialogResult.OK)
            {
                object[] results = new object[]{
            pageSetupDialog1.PageSettings.Margins,
            pageSetupDialog1.PageSettings.PaperSize,
            pageSetupDialog1.PageSettings.Landscape,
            pageSetupDialog1.PrinterSettings.PrinterName,
            pageSetupDialog1.PrinterSettings.PrintRange};
                // textBox.Items.AddRange(results);
                
            }
            }
        //NEW
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            textBox.Clear();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Text Documents|*.txt",
                ValidateNames = true,
                Multiselect = false
            }
            )
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        this.Text = ofd.FileName + " - Notepad";                    
                       path = ofd.FileName;
                        Task<string> text = sr.ReadToEndAsync();
                        textBox.Text = text.Result;

                    }
                }

            }

        }

        private async void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                           
                            await sw.WriteLineAsync();
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    await sw.WriteLineAsync();
                }
            }
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAbout frm = new frmAbout())
            {
                frm.ShowDialog();
            }
        }
        private async void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            await sw.WriteLineAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "non valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.bing.com/search?q=get+help+with+notepad+in+windows+10&filters=guid:%224466414-en-dia%22%20lang:%22en%22&form=T00032&ocid=HelpPane-BingIA");
            Process.Start(sInfo);
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            counter += 1;
            float csize;
            csize = textBox.Font.Size;
            csize += 2.0F;
            textBox.Font = new Font(textBox.Font.Name, csize, textBox.Font.Style, textBox.Font.Unit);

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.ClearUndo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = System.DateTime.Now.ToString();
        }

        private void searchWithBingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.bing.com/search");
            Process.Start(sInfo);
        }


        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog op = new FontDialog();
            if (op.ShowDialog() == DialogResult.OK)
                textBox.Font = op.Font;
        }
        int a = 0;
        int ab = 1;

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ab == 1)
            {
                ab = 0;
                Controls.Add(statusStrip1);
            }
            else if (ab == 0)
            {
                ab = 1;
                Controls.Remove(statusStrip1);
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            counter -= 1;
            float csize;
            csize = textBox.Font.Size;
            csize -= 2.0F;
            textBox.Font = new Font(textBox.Font.Name, csize, textBox.Font.Style, textBox.Font.Unit);
        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (counter < 0)
            {
                float csize;
                csize = textBox.Font.Size;
                for (int i = 0; i < -counter; i++)
                {
                    csize += 2.0F;
                    textBox.Font = new Font(textBox.Font.Name, csize, textBox.Font.Style, textBox.Font.Unit);
                }
            }
            else
            {
                float csize;
                csize = textBox.Font.Size;
                for (int i = 0; i < counter; i++)
                {

                    csize -= 2.0F;
                    textBox.Font = new Font(textBox.Font.Name, csize, textBox.Font.Style, textBox.Font.Unit);
                }
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox.Text, new Font("Time New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = "IO Notepad";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = System.DateTime.Now.ToString(" hh:mm tt ");
        }

        private void fontsize_Click(object sender, EventArgs e)
        {

        }
        private void fontSizeData(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
        }
       
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            toolStripStatusLabel5.Text = "row "+Cursor.Position.X + " col " + Cursor.Position.Y;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
