/*********************************************************************************************************

 * Project: Name Queue Application
 * 
 * File: Form Class
 * 
 * Langauge: VS C#
 * 
 *
 *
 * Description: This file will implement a queue using a link list.
 *
 *
 * College: Husson University
 * 
 * Course:  IT 325
 * 
 * Author: Gary Edward Ward
 * 
 * 
 * 
 * Change Log:
 * 
 * Date                         Description of Change
 * 
 * ---------------           ----------------------------------------------------------------------------
 * 
 * 11/10/2020               - Initial writing
 * 11/10/2020               - Data and constructor added to the form                          
 * 11/10/2020               - Methods added to display the queue and code for the enqueue button
 * 11/10/2020               - Methods added to display the queue and code for the enqueue button
 * 11/10/2020               - Code added to the deenqueue and peek buttons
 * 
*********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT325NameQueue_GEW {
    public partial class FormNameQueue : Form {

        // data
        CQueue nameLine = new CQueue();

        // constructor
        public FormNameQueue() {
            InitializeComponent();
        }

        // method

        /// <summary>
        /// This method takes th evalue entered by the user
        /// and adds it to the queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnqueue_Click(object sender, EventArgs e) {
            // get the value from the user
            String name = textBoxName.Text.Trim();

            // add it to the queue
            nameLine.Enqueue(name);

            // display the queue
            DisplayQueue(nameLine, listBoxNameQueue);

        }

        /// <summary>
        /// Thsi method will display the queue in the desired listbox
        /// </summary>
        /// <param name="theQueue"></param>
        /// <param name="theListBox"></param>
        private void DisplayQueue(CQueue theQueue, ListBox theListBox) {
            // clear the listbox
            theListBox.Items.Clear();

            // display a header
            theListBox.Items.Add("Front of the queue");

            // display the contents of the queue
            foreach (String value in theQueue) {
                theListBox.Items.Add(value);

            }

            // display trailer 
            theListBox.Items.Add("Back of the queue");

            // display a header
            theListBox.Items.Add(String.Empty);
            theListBox.Items.Add(String.Format("Count = {0}", nameLine.Count));
        }

        /// <summary>
        /// This method will return the first item from the queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDequeue_Click(object sender, EventArgs e) {
            try {
                String value = nameLine.Dequeue();
                MessageBox.Show(String.Format("Dequeue = {0}", value));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            // display the queue
            DisplayQueue(nameLine, listBoxNameQueue);
        }

        /// <summary>
        /// This method will return the first item in the queue
        /// without removing it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPeek_Click(object sender, EventArgs e) {
            try {
                String value = nameLine.Peek();
                MessageBox.Show(String.Format("Peek = {0}", value));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            // display the queue
            DisplayQueue(nameLine, listBoxNameQueue);
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e) {
            //allows only letters
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
