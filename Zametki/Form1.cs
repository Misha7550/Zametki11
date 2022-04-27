using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Data.SQLite;



namespace Zametki
{
    public partial class Form1 : Form
    {
        


        public Form1()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            notifyIcon1.Visible = true;
            ShowInTaskbar = false;
            textBox1.Text = "выкл";


            


        }




        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Zametki". При необходимости она может быть перемещена или удалена.
            this.zametkiTableAdapter.Fill(this.database1DataSet.Zametki);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Zametki". При необходимости она может быть перемещена или удалена.
            


        }

        

        private void but_add_Click(object sender, EventArgs e)
        {
            DataRow row = database1DataSet.Tables[0].NewRow(); // добавляем новую строку в DataTable
            database1DataSet.Tables[0].Rows.Add(row);
        }

        private void but_del_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            zametkiBindingSource.EndEdit();
            zametkiTableAdapter.Update(database1DataSet);
            MessageBox.Show("Изменения успешно сохранены");


            
        }














        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public bool www;

        private void button1_Click(object sender, EventArgs e)
        {
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            String value = (String)key.GetValue("Zametki");

            if (!String.IsNullOrEmpty(value))
            {
                www = false;
            }
                // открываем нужную ветку в реестре 
                // @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"
                if (www == true)
            {

                //добавляем первый параметр - название ключа
                // Второй параметр - это путь к 
                // исполняемому файлу нашей программы.
                key.SetValue("Zametki", Application.ExecutablePath);
                www = false;
                textBox1.Text = "вкл";
            }
            else
            {
                //удаляем
                key.DeleteValue("Zametki", false);
                
                www = true;
                textBox1.Text = "выкл";
            }
            key.Close();
        }

        
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
