using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.IO;

namespace FileCreationListener
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        

        string pathSource;

        string pathDest ;
        FileSystemWatcher watcher;
        private void watch()
        {
            btnStart.Enabled = false;
            watcher = new FileSystemWatcher();
            watcher.Path = pathSource;
            watcher.NotifyFilter = NotifyFilters.Attributes |
                                    NotifyFilters.CreationTime |
                                    NotifyFilters.FileName |
                                    NotifyFilters.LastAccess |
                                    NotifyFilters.LastWrite |
                                    NotifyFilters.Size |
                                    NotifyFilters.Security;
            //watcher.Filter = "*.*";
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;
            watcher.Renamed += Watcher_Renamed;
            watcher.Deleted += Watcher_Deleted;
            watcher.Filter = txtFilter.Text;
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            

        }


        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show(e.FullPath + " deleted");
            BeginInvoke(new Action(() =>
            {
                lblMessage.Text = e.FullPath + " deleted";
            }));
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string flName;
            if (e.Name.Contains("\\"))
            {
                string[] brk = e.Name.Split('\\');
                flName = brk[brk.Length - 1];
            }
            else
            {
                flName = e.Name;
            }
            //throw new NotImplementedException();
            //WaitForFile(e.FullPath);
            //File.Copy(e.FullPath, pathDest + "\\" + flName, true);
            processNewFile(e.FullPath, pathDest, flName);
            BeginInvoke(new Action(() =>
            {

                lblMessage.Text = e.Name + " ; " + e.ChangeType.ToString();
            }));

        }


        private void processNewFile(string sourceFileFullPath, string destFilePath, string destFileName )
        {
            try
            {
                WaitForFile(sourceFileFullPath);

                FileInfo fInfo = new FileInfo(sourceFileFullPath);



                // validate file (must be greater than 6 characters... first 6 chars must be numeric
                string valMessage = validateFile(destFileName);
                if (valMessage.Length > 0)
                {
                    BeginInvoke(new Action(() =>
                    {

                        lbLog.Items.Add(destFileName + " not added: " + valMessage + " ; " + DateTime.Now.ToString());
                    }));
                }
                else
                {

                    // only want the first 6 characters
                    string newName = destFileName.Substring(0, 6) + ".pdf";
                    File.Copy(sourceFileFullPath, destFilePath + "\\" + newName, true);
                    BeginInvoke(new Action(() =>
                    {
                        lbLog.Items.Add(newName + " successfully added: " + DateTime.Now.ToString());
                    }));

                }

                // delete source file
                if (chkDeleteSource.Checked)
                {
                    File.Delete(sourceFileFullPath);
                    BeginInvoke(new Action(() =>
                    {
                        lbLog.Items.Add(sourceFileFullPath + " deleted: " + DateTime.Now.ToString());
                    }));
                }
            }
            catch (Exception e)
            {
                BeginInvoke(new Action(() =>
                {
                    lbLog.Items.Add("Unexpected Error: " + e.Message + " ; " + DateTime.Now.ToString());
                }));
            }

            

            
        }


        private string validateFile(string fileName)
        {
            string errors = "";
            string[] brk = fileName.Split('.');
            if (brk[0].Length < 6)
            {
                errors = " file name contains < 6 characters ";
            }
            if (!CheckNumeric(brk[0].Substring(0,6)))
            {
                errors = errors + " ; file name contains alpha characters ";
            }

            // check for exclusion keyword patterns
            brk = txtExcludeKeyWords.Text.Trim().ToLower().Split(',');

            foreach (string s in brk)
            {
                if (fileName.ToLower().Contains(s))
                {
                    errors = errors + " ; file name contains excluded key word '" + s + "'";
                }
            }


            return errors;

        }



        /// <summary>
        /// Blocks until the file is not locked any more.
        /// </summary>
        /// <param name="fullPath"></param>
        bool WaitForFile(string fullPath)
        {
            int numTries = 0;
            while (true)
            {
                ++numTries;
                try
                {
                    // Attempt to open the file exclusively.
                    using (FileStream fs = new FileStream(fullPath,
                        FileMode.Open, FileAccess.ReadWrite,
                        FileShare.None, 100))
                    {
                        fs.ReadByte();

                        // If we got this far the file is ready
                        break;
                    }
                }
                catch (Exception ex)
                {
                    //Log.LogWarning(
                    //   "WaitForFile {0} failed to get an exclusive lock: {1}",
                    //    fullPath, ex.ToString());

                    if (numTries > 10)
                    {
                        //Log.LogWarning(
                        //    "WaitForFile {0} giving up after 10 tries",
                        //    fullPath);
                        return false;
                    }

                    // Wait for the lock to be released
                    System.Threading.Thread.Sleep(500);
                }
            }

            //Log.LogTrace("WaitForFile {0} returning true after {1} tries",
            //    fullPath, numTries);
            return true;
        }

        FileStream WaitForFile(string fullPath, FileMode mode, FileAccess access, FileShare share)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fullPath, mode, access, share);
                    return fs;
                }
                catch (IOException)
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                    
                    Thread.Sleep(50);
                }
            }

            return null;
        }


        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //string flName;
            //if (e.Name.Contains("\\"))
            //{
            //    string[] brk = e.Name.Split('\\');
            //    flName = brk[brk.Length - 1];
            //}
            //else
            //{
            //    flName = e.Name;
            //}
            ////throw new NotImplementedException();

            //BeginInvoke(new Action(() =>
            //{
            //    File.Copy(e.FullPath, pathDest + flName, true);
            //    lblMessage.Text = e.Name + " ; " + e.ChangeType.ToString();
            //}));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.searchPattern = txtFilter.Text;
            Properties.Settings.Default.sourceDir = lblSource.Text;
            Properties.Settings.Default.destinationDir = lblDestination.Text;
            Properties.Settings.Default.exclusionKeyWords = txtExcludeKeyWords.Text;
            Properties.Settings.Default.deleteSourceFile = chkDeleteSource.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            pathSource = lblSource.Text;

            pathDest = lblDestination.Text;

            lblMessage.Text = "Listening...";

            watch();
            //watchCustom();
            lbLog.Items.Clear();
        }

        private void lblDestination_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowNewFolderButton = true;
            //Environment.SpecialFolder sf = Environment.SpecialFolder.Templates;
            //f.RootFolder = sf;
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
            {
                lblDestination.Text = f.SelectedPath;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            validatePaths();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            this.Text = "Directory Listener (version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";
            //pathSource = "C:\\Users\\ChristopherBlack\\AutoCAD\\test_drawings";
            //pathDest = "C:\\Users\\ChristopherBlack\\AutoCAD\\test_copy\\";
            //pathSource = "C:\\Users";
            //pathDest = "C:\\Users";
            pathSource = Properties.Settings.Default.sourceDir;
            pathDest = Properties.Settings.Default.destinationDir;

            txtFilter.Text = Properties.Settings.Default.searchPattern;
            txtExcludeKeyWords.Text = Properties.Settings.Default.exclusionKeyWords;

            chkDeleteSource.Checked = Properties.Settings.Default.deleteSourceFile;

            lblDestination.Text = pathDest;
            lblSource.Text = pathSource;

            validatePaths();
            btnStart_Click(sender, e);

           // txtExcludeKeyWords.Text = "coating";
            
        }

        private void lblSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowNewFolderButton = true;
            //Environment.SpecialFolder sf = Environment.SpecialFolder.Templates;
            //f.RootFolder = sf;
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
            {
                lblSource.Text = f.SelectedPath;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            validatePaths();
        }


        private string validatePaths()
        {
            string validationError = "";
            if (!Directory.Exists(lblSource.Text))
            {
                validationError = lblSource.Text + " does not exist!";
            }
            if (!Directory.Exists(lblDestination.Text))
            {
                validationError = validationError + "\n" + lblDestination.Text + " does not exist!";

            }
            if (validationError.Length > 0)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = false;
                lblMessage.Text = validationError;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = true;
                lblMessage.Text = "";
            }
            return validationError;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (watcher != null)
            {
                watcher.EndInit();
                watcher.Dispose();
                validatePaths();
                lblMessage.Text = "Process Stopped";
            }

            // dump the logging info to a text file
            createLogFile();
        }

        private void createLogFile()
        {
            try
            {
                // check for 'logs' folder - if not exist, create it
                string logDirectory = pathSource + "\\logs";
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                string logFilePath = logDirectory + "\\Log.txt";
                string uniqFil = getUniqueFileName(logFilePath);

                string[] logItems = lbLog.Items.OfType<string>().ToArray();

                File.WriteAllLines(uniqFil, logItems);

                //foreach (string l in lbLog.Items)
                //{
                    
                //}
            }
            catch (Exception e)

            {
                MessageBox.Show(e.Message);

            }
        }


        int fileRev = 0;
        public  string getUniqueFileName(string flName, string flExt = ".txt")
        {
            string newFileName = "";
            if (System.IO.File.Exists(flName))
            {
                string[] brk = flName.Split('_');
                if (brk.Length > 1)
                {
                    string rev = brk[brk.Length - 1].Replace(flExt, "");
                    if (CheckNumeric(rev))
                    {
                        string newFl = "";
                        fileRev++;



                        for (int i = 0; i < brk.Count() - 1; i++)
                        {
                            if (newFl.Length > 0)
                            {
                                newFl = newFl + "\\" + brk[i];
                            }
                            else
                            {
                                newFl = brk[i];
                            }
                        }
                        flName = newFl;
                    }

                }
                newFileName = flName.Replace(flExt, "") + "_" + fileRev.ToString() + flExt;
                // see if this is unique
                newFileName = getUniqueFileName(newFileName, flExt);
            }
            else
            {
                newFileName = flName;
            }

            return newFileName;
        }




        public static bool CheckNumeric(string checkString, bool allowNegativeValue = true)
        {
            // loop through each character.  Can have one decimal place... and can have a leading
            // dash (for negative numbers)
            int intStringLength = checkString.Trim().Length;
            bool returnValueBool = true;
            int decimalCountInt = 0;
            if (intStringLength > 0)
            {
                for (int i = 0; i < intStringLength; i++)
                {
                    char stringChar = Convert.ToChar(checkString.Substring(i, 1));
                    int ascCode = (int)stringChar;
                    if (ascCode < 48 || ascCode > 57)
                    // is invalid
                    {
                        returnValueBool = false;
                        // check if it is a . or -
                        // - can only exist at the first character
                        if (checkString.Substring(i, 1) == "-" && i == 0)
                        {
                            if (checkString.Length > 1)
                                returnValueBool = true;
                        }
                        // one decimal can exist
                        else if (checkString.Substring(i, 1) == ".")
                        {
                            decimalCountInt++;
                            if (decimalCountInt == 1)
                            {
                                returnValueBool = true;
                            }
                        }
                    }
                }
                if (!allowNegativeValue)
                {
                    if (returnValueBool == true && Convert.ToDouble(checkString) > -1)
                    {
                        returnValueBool = true;
                    }
                    else
                    {
                        returnValueBool = false;
                    }
                }
                return returnValueBool;
            }
            else
            {
                return false;
            }
        }
    }
}
