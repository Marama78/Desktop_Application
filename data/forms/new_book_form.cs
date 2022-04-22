using coder_data_manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant_Code.data.forms
{
    public partial class new_book_form : Form
    {
        public new_book_form()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            int new_key = Assistant_Code.Properties.Settings.Default.book_id_counter;
            new_key++;
            Assistant_Code.Properties.Settings.Default.book_id_counter= new_key;
            Assistant_Code.Properties.Settings.Default.Save();

            string data_to_write =
                new_key.ToString() + '|' +
                tb_name.Text;

            string path_to_file =
                System.IO.Directory.GetCurrentDirectory() +
                "\\data\\initiate.ini";

            if(!System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() +
                "\\data"))
            {
                System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() +
                "\\data");
            }

            if (!System.IO.File.Exists(path_to_file))
            {
                var new_file = System.IO.File.Create(path_to_file);

                new_file.Close();
            }

            Data_Pipeline dp = new Data_Pipeline();
            dp.Write_Line_Data(path_to_file, data_to_write);

          //  MessageBox.Show("Le nouveau livre a été sauvegardé");

            this.Close();
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
