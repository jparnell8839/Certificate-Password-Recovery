/*
Copyright (c) 2012 Rion Carter

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CertificatePasswordRecovery
{
    public partial class CertPasswordRecoveryForm : Form
    {
        //
        // Class Variables
        //

        // Container for holding the generated cracked password
        int[] password;

        // Container which represents the character sequence to be used when cracking
        char[] sequence;

        // Log level (Defaults to Everything if nothing is selected
        //  0 == Off
        //  1 == Success Only (Default)
        //  2 == Every 10,000 + Success
        //  3 == Everything
        int LogLevel;

        // X509 Certificate object used while trying to decrypt the keystore / certificate
        X509Certificate2 certificate;

        public CertPasswordRecoveryForm()
        {
            InitializeComponent();

            // Set Default log-level to '2' (see above for the key)
            logLevelBx.SelectedIndex = 2;
            LogLevel = logLevelBx.SelectedIndex;

            // Set the 'Starting String' max character limit
            startStringBx.MaxLength = (int)maxGenBx.Value;
        }

        /// <summary>
        /// Main entry point for the password cracker. When you hit the 'Recover Password' button, everything starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recoverPasswordBtn_Click(object sender, EventArgs e)
        {
            // Make sure the user is warned when non-sequenced values are in the 'starting string' box
            char[] starting_chars = startStringBx.Text.ToCharArray();
            bool ContainsInvalidChars = false;
            foreach (char character in starting_chars)
            {
                if (symbolSequenceBx.Text.IndexOf(character) == -1)
                {
                    ContainsInvalidChars = true;
                }
            }
            if (ContainsInvalidChars)
            {
                // Don't continue if the user says 'no'
                DialogResult WarnUser = MessageBox.Show("There are characters in the 'Starting String' box that are not present in your Symbol Sequence. Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (WarnUser == DialogResult.No)
                    return;
            }


            // Make sure we have a valid path to a file entered in the certificate box
            if (!File.Exists(pathToCertBx.Text))
            {
                MessageBox.Show("No Certificate file selected. Please ensure one is selected before continuing!", "Error");
                return;
            }

            // Make sure we have a valid log file path entered (if logging is not set to 0)
            if((LogLevel != 0) && !(logPathBx.Text.Length > 0))
            {
                MessageBox.Show("No log file path selected. Please enter a path before continuing!", "Error");
                return;
            }

            // Disable controls (make them read-only)
            maxGenBx.ReadOnly = true;
            startStringBx.ReadOnly = true;
            prefixBx.ReadOnly = true;
            suffixBx.ReadOnly = true;
            symbolSequenceBx.ReadOnly = true;
            pathToCertBx.ReadOnly = true;
            logPathBx.ReadOnly = true;
            logLevelBx.Enabled = false;
            recoverPasswordBtn.Enabled = false;

            // Make the progress bar visible:
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;

            // If Logging is NOT set to 0, log a message indicating that we've started Logging
            if (LogLevel != 0)
            {
                Log("-----------------\r\n-----------------\r\nBeginning to Recover password (Brute-force)", logPathBx.Text, 0);
            }

            // Kick off a thread which does the work
            BackgroundWorker PasswordRecoveryWorker = new BackgroundWorker();
            PasswordRecoveryWorker.DoWork += new DoWorkEventHandler(PasswordRecoveryWorker_DoWork);
            PasswordRecoveryWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(PasswordRecoveryWorker_RunWorkerCompleted);
            PasswordRecoveryWorker.RunWorkerAsync();
        }

        void PasswordRecoveryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Create password character array of the size specified
            password = new int[(int)maxGenBx.Value];

            // Populate the character sequence we should use during the brute-force password recovery
            string[] character_candidates = symbolSequenceBx.Text.Split(',');
            sequence = new char[character_candidates.Length];
            int i = 0;
            foreach (string char_candidate in character_candidates)
            {
                // This password recovery tool does not support more than one character per symbol at this time
                //      If we detect that more than one character is present in the Symbol entry box, we will throw this message
                //
                // NOTE: The comma separated values SHOULD NOT contain spaces before or after the comma. Spaces are regarded as a character!
                // NOTE 2: To include a comma as a symbol, enter 'comma'
                string char_candidate_after_comma_check = char_candidate;
                if (char_candidate.Length > 1)
                {
                    if (char_candidate != "comma")
                    {
                        MessageBox.Show("The symbol sequence should be a list of comma separated single character values. If you enter multiple characters per entry, you will see this error", "Error");
                        return;
                    }

                    char_candidate_after_comma_check = ",";
                }

                // If the character is just a single character we can add it to the sequence list
                sequence[i] = char_candidate_after_comma_check[0];

                // Increment the position counter for sequence
                i++;
            }

            // Set the password to the 'starting string' value if one has been specified
            SetStartingString();

            // Recover the password
            RecoverPassword();
        }

        /// <summary>
        /// Set the starting string to the password array (if there is a starting string specified)
        /// </summary>
        private void SetStartingString()
        {
            // Get the characters of the 'starting string'
            //  Reverse them so we start with the 'lowest' order characters and work our way up
            char[] starting_chars = startStringBx.Text.ToCharArray();
            Array.Reverse(starting_chars);
            
            // Map them to integers that correspond with the character sequence
            int[] starting_chars_converted = new int[starting_chars.Length];
            int count = 0;
            foreach (char character in starting_chars)
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    if (character == sequence[i])
                    {
                        starting_chars_converted[count] = i;
                        break;
                    }
                }

                count++;
            }

            // Assign the characters one at a time (starting with the lowest) to the password array
            int pos = 0;
            for (int i = password.Length -1; i >= 0 ; i--)
            {
                // Exit if we have exausted the starting characters (don't want outofbounds exception)
                if (pos >= starting_chars_converted.Length)
                {
                    break;
                }
                password[i] = starting_chars_converted[pos];
                pos++;
            }
        }

        void PasswordRecoveryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Re-enable the controls
            maxGenBx.ReadOnly = false;
            startStringBx.ReadOnly = false;
            prefixBx.ReadOnly = false;
            suffixBx.ReadOnly = false;
            symbolSequenceBx.ReadOnly = false;
            pathToCertBx.ReadOnly = false;
            logPathBx.ReadOnly = false;
            logLevelBx.Enabled = true;
            recoverPasswordBtn.Enabled = true;

            // Make the progress bar invisible:
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Visible = false;
        }

        /// <summary>
        /// This method loops until a password is found
        /// </summary>
        private void RecoverPassword()
        {
            // Find the 'depth' of the password array
            int depth = password.Length - 1;

            // Incrementors needed to ensure we check every password combination
            BigInteger i = 0;
            BigInteger RepeatUntil = BigInteger.Pow((BigInteger)sequence.Length, password.Length);

            // Password found?
            bool password_found = false;

            // loop to find the password
            do
            {
                // Increment the highest position of the array
                password[depth]++;

                // Check for overflows in ALL array positions, starting from the "deepest" (The lowest)
                for (int ii = depth; ii >= 0; ii--)
                {
                    // If there is an overflow:
                    //      Clear the current position back to sequence[0]
                    //      Increment the next lower position
                    if (password[ii] > (sequence.Length - 1))
                    {
                        password[ii] = 0;

                        // Prevent array out of bounds problem
                        if (ii != 0)
                        {
                            password[ii - 1]++;
                        }
                    }
                }

                //
                // Create a string based on the sequenced characters
                //
                char[] password_sequenced = new char[password.Length];
                for (int pos = 0; pos < password.Length; pos++)
                {
                    password_sequenced[pos] = sequence[password[pos]];
                }
                string pw = new string(password_sequenced);
                pw = pw.Trim();
                // Prepend the 'prefix' string (if one is entered)
                if (prefixBx.Text.Length > 0)
                {
                    pw = prefixBx.Text + pw;
                }
                // Append the 'suffix' string (if one is entered)
                if (suffixBx.Text.Length > 0)
                {
                    pw = pw + suffixBx.Text;
                }

                // Check the password
                //  If it is found, exit the loop
                if (TestPassword(pathToCertBx.Text, pw, logPathBx.Text, i))
                {
                    password_found = true;
                    break;
                }

                // Loop counter. Keep counting!
                i++;
            }
            while (BigInteger.Compare(i, RepeatUntil) <= 0);

            if (!password_found)
                MessageBox.Show("Password not found. :(", "Info");
        }

        /// <summary>
        /// This method tests the password using .NET API
        /// </summary>
        /// <param name="CertificatePath">File system location of the certificate</param>
        /// <param name="CertificatePassword">Password we want to try</param>
        /// <param name="LogFileLocation">Log file path set in the UI</param>
        /// <returns>True if the password has been found</returns>
        private bool TestPassword(string CertificatePath, string CertificatePassword, string LogFileLocation, BigInteger PasswordNumber)
        {
            try
            {
                certificate = new X509Certificate2(CertificatePath, CertificatePassword);
                
                // Only log successful crack to a file if the logging is NOT set to 0!
                //      You may do this if you don't want to have a "paper trail" of your password
                if (LogLevel != 0)
                {
                    Log("Found Password: " + CertificatePassword, LogFileLocation, PasswordNumber);
                }

                // Notify the user of the success!
                MessageBox.Show("Your password has been found!\r\nPassword: " + CertificatePassword + "\r\n\r\nIf you have logging enabled, it has been saved to the log", "SUCCESS!!!");

                return true;
            }
            catch
            {
                // If we don't find the password (likely at first, given the sheer number of possible passwords)
                //  Handle logging in accordance with the user's settings
                switch (LogLevel)
                {
                    // Case 1 is handled in the "success" section above. We should ALWAYS log the success unless told not to.
                    // Case 0 is handled in the "success" section. We just don't log anything when told not to!
                    case 2:
                        // Every 10,000 + Succcess
                        if ((PasswordNumber % 10000) == 0 || PasswordNumber == 0)
                        {
                            Log("Password Failed: " + CertificatePassword, LogFileLocation, PasswordNumber);
                        }
                        break;
                    case 3:
                        // Everything
                        Log("Password Failed: " + CertificatePassword, LogFileLocation, PasswordNumber);
                        break;
                }
            }

            // Return 'false' if the password has not been found
            return false;
        }


        /// <summary>
        /// Writes a message to the log file
        /// </summary>
        /// <param name="logMessage">String to be written</param>
        /// <param name="LogFile">Location of the Log file in the file system</param>
        private void Log(string logMessage, string LogFile, BigInteger PasswordNumber)
        {
            using (TextWriter Logger = File.AppendText(LogFile))
            {
                    Logger.WriteLine("Log Entry #{0} : ", PasswordNumber);
                    Logger.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());
                    Logger.WriteLine("  :{0}", logMessage);
                    // Update the Log File
                    Logger.Flush();
            }
        }

        private void certBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog certificateBrowser = new OpenFileDialog();
            certificateBrowser.Title = "Select the PFX / P12 Certificate file";
            certificateBrowser.InitialDirectory = @"c:\";

            if (certificateBrowser.ShowDialog() == DialogResult.OK)
            {
                pathToCertBx.Text = certificateBrowser.FileName;
            }
        }

        /// <summary>
        /// Make sure that the max 'starting string' value is only as great as the password bucket to hold it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxGenBx_ValueChanged(object sender, EventArgs e)
        {
            startStringBx.MaxLength = (int)maxGenBx.Value;
        }

        /// <summary>
        /// Ensure that the log level gets set when the option is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logLevelBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogLevel = logLevelBx.SelectedIndex;
        }

        /// <summary>
        /// Take user to the BoredWookie page for the tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpAboutLinkLbl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://boredwookie.net/index.php/blog/certificate-password-recovery-tool/");
        }
    }
}
