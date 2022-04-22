using coder_data_manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Assistant_Code.data.forms
{
    public partial class new_classeur_form : Form
    {
        bool is_new = true;

        public new_classeur_form(bool _is_new_classeur)
        {
            InitializeComponent();
            is_new = _is_new_classeur;
        }

        private void btn_cancel_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_classeur(object sender, EventArgs e)
        {
            if (is_new)
            {
                Data_Pipeline dp = new Data_Pipeline();



              
                //-- créer un classeur vierge --
                int current_key_book = Assistant_Code.Properties.Settings.Default.current_key_id_book;

                int key_this = Assistant_Code.Properties.Settings.Default.classeur_id_counter;
                key_this++;
                Assistant_Code.Properties.Settings.Default.classeur_id_counter = key_this;
                Assistant_Code.Properties.Settings.Default.Save();




                string path_to_classeur_list_file =
                    System.IO.Directory.GetCurrentDirectory() +
                    "\\data\\data_book_" + current_key_book + ".dat";


                List<string> list_content = new List<string>(System.IO.File.ReadAllLines(path_to_classeur_list_file));
                List<data_book> list_classeur = new List<data_book>();
               
                bool isLooping = true;
                while (isLooping)
                {

                    string key_to_write =
                      current_key_book.ToString() + '_' + key_this.ToString();

                    isLooping = false;

                    foreach (string str in list_content)
                    {
                        string[] data = str.Split('|');
                        if(data[0]==key_to_write)
                        {
                            key_this = Assistant_Code.Properties.Settings.Default.classeur_id_counter;
                            key_this++;
                            Assistant_Code.Properties.Settings.Default.classeur_id_counter = key_this;
                            Assistant_Code.Properties.Settings.Default.Save();

                            isLooping = true;
                        }
                    }

                }

                string data_to_write =
                       current_key_book.ToString() + '_' + key_this.ToString() + '|' +
                       tb_name.Text;

                string path_to_file =
                    System.IO.Directory.GetCurrentDirectory() +
                    "\\data\\data_book_" + current_key_book + ".dat";

                if (!System.IO.File.Exists(path_to_file))
                {
                    var new_file = System.IO.File.Create(path_to_file);

                    new_file.Close();
                }

                dp.Write_Line_Data(path_to_file, data_to_write);

                ///  MessageBox.Show("Le nouveau classeur a été sauvegardé");
            }
            else if (!is_new)
            {
                // -- modifier un classeur existant --
                int current_key_book = Assistant_Code.Properties.Settings.Default.current_key_id_book;
                string current_key_classeur = Assistant_Code.Properties.Settings.Default.current_key_id_classeur;
               
                string path_to_file =
                   System.IO.Directory.GetCurrentDirectory() +
                   "\\data\\data_book_" + current_key_book + ".dat";


                List<string> list_content = new List<string>(System.IO.File.ReadAllLines(path_to_file));
                List<string> list_to_keep = new List<string>();

                if (list_content.Count > 0)
                {
                    foreach (string str in list_content)
                    {
                        string[] data = str.Split('|');

                        if (data[0] != current_key_classeur)
                        {
                            list_to_keep.Add(str);
                        }
                        else if (data[0] == current_key_classeur)
                        {
                            string data_to_write =
                                data[0] + '|' +
                                tb_name.Text;

                            list_to_keep.Add(data_to_write);
                        }

                    }
                }


                System.IO.File.Delete(path_to_file);
                var new_path = System.IO.File.Create(path_to_file);
                new_path.Close();

                if(list_to_keep.Count>0)
                {
                    foreach(string str in list_to_keep)
                    {
                        Data_Pipeline dpi = new Data_Pipeline();
                        dpi.Write_Line_Data(path_to_file, str);
                    }
                }

            }



            this.Close();
        }

        private void read_key(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_add_classeur(sender, e);
                    break;

             
            }
        }
    }
}
