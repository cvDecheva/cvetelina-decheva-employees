using Employees.Common.Controllers;
using Employees.Common.Coverters;
using Employees.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Employees.DesktopApp
{
    public partial class Form1 : Form
    {
        private bool _areEmpIdsDrawn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void openFileDialogButton_Click(object sender, EventArgs e)
        {
            string filePath;

            openFileDialog.Title = "Select text file";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if(openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                dataGridView.Rows.Clear();

                filePath = openFileDialog.InitialDirectory + openFileDialog.FileName;
                textPathBox.Text = filePath;

                if(File.Exists(filePath))
                {
                    List<Employee> employees = FileConverter.ConvertToEmployees(filePath);
                    EmployeesController employeesController = new EmployeesController(employees);
                    List<Couple> couplesWithMaxDays = employeesController.GetCouplesWithMaxDaysWorked();

                    foreach(Couple couple in couplesWithMaxDays)
                    {
                        _areEmpIdsDrawn = false;

                        foreach(Project project in couple.Projects)
                        {
                            int i = dataGridView.Rows.Add(couple.EmpId1, couple.EmpId2, project.ProjectID, project.Days);

                            if(_areEmpIdsDrawn)
                            {
                                dataGridView.Rows[i].Cells[0].Value = "";
                                dataGridView.Rows[i].Cells[1].Value = "";
                            }

                            _areEmpIdsDrawn = true;
                        }

                        dataGridView.Rows.Add();
                    }
                }
                else
                {
                   MessageBox.Show("The file does not exist or does not have sufficient permissions to read it!");
                }
            }
        }
    }
}
