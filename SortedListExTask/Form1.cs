using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SortedList<DateTime, string> taskList = new SortedList<DateTime, string>();

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            DateTime taskDate = dtpTaskDate.Value.Date;
                      
            if (txtTask.Text == string.Empty)
            {
                MessageBox.Show("You must enter a task.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (taskList.ContainsKey(taskDate))
            {
                MessageBox.Show("Only one task per date is allowed.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
            taskList.Add(taskDate, txtTask.Text);
            lstTasks.Items.Add(taskDate);

           
            txtTask.Clear();
            dtpTaskDate.Value = DateTime.Now;
          
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(lstTasks.SelectedIndex =! -1)
            //{

            //}
          
            lblTaskDetails.Text = taskList[Convert.ToDateTime(lstTasks.SelectedItem)];
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("You must seleted a task to remove", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            taskList.Remove(Convert.ToDateTime(lstTasks.SelectedItem));
            lstTasks.Items.Remove(lstTasks.SelectedIndex);

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (taskList.Count == 0)
            {
                MessageBox.Show("No tasks to display");
                return;
            }

            foreach (var item in taskList)
            {
                message += $"{item.Key} {item.Value} \n";
               
            }

            //foreach (KeyValuePair<DateTime, string> item in taskList)
            //{
            //    message += item.Key.ToShortDateString() + " " + item.Value + Environment.NewLine;
            //}

            MessageBox.Show(message);

        }
    }
}
