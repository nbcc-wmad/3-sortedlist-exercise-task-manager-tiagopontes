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
            lstTasks.Sorted = true;
            txtTask.Clear();
                         
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(lstTasks.SelectedItem);

            lblTaskDetails.Text = taskList[selectedDate];
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("You must seleted a task to remove", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime selectedDate = Convert.ToDateTime(lstTasks.SelectedItem);
                //taskList.Remove();
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            foreach (var item in taskList)
            {
                message += $"{item.Key} {item.Value} \n";
               
            }

            MessageBox.Show(message);

        }
    }
}
