using Assistant_Code.data.forms;
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

namespace Assistant_Code
{
    public partial class Snake_Coder : Form
    {

        List<data_book> list_wrapper_book;
        List<data_book> list_wrapper_classeurs;
        List<text_data> list_wrapper_document;
        List<string> list_book_s_name;


        int key_id_book_selected_only, key_id_classeur_selected_only , key_id_document_selected_only;

        string current_key_id_book, current_key_id_classeur, current_key_id_document;

        public Snake_Coder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list_book_s_name = new List<string>();
            list_wrapper_book = new List<data_book>();
            list_wrapper_classeurs = new List<data_book>();
            list_wrapper_document = new List<text_data>();

            Data_Pipeline dpipe = new Data_Pipeline();
            list_wrapper_book = dpipe.Get_Books();
            list_wrapper_classeurs = dpipe.Get_All_Classeur_From_Book_ID("0");

            if (list_wrapper_book != null)
            {
                foreach (data_book str in list_wrapper_book)
                {
                    lv_book.Items.Add(str.name.ToString());
                }
            }

            if (list_wrapper_classeurs != null)
            {
                foreach (data_book str in list_wrapper_classeurs)
                {
                    lv_classeur.Items.Add(str.name.ToString());
                }
            }
        }


        #region commandes : ajouter book, classeur, document
        private void menu_add_new_book_click(object sender, EventArgs e)
        {
            new_book_form nbf = new new_book_form();
            nbf.ShowDialog();

            btn_refresh_book.Enabled = true;
        }

        private void btn_add_classeur_click(object sender, EventArgs e)
        {
            new_classeur_form npf = new new_classeur_form(true);
            npf.ShowDialog();
        }

        private void btn_add_document_Click(object sender, EventArgs e)
        {
            text_editor td = new text_editor(false);
            td.Show();
        }


        private void btn_read_document_Click(object sender, EventArgs e)
        {

            data.forms.text_editor t = new data.forms.text_editor(true);

            t.ShowDialog();
        }

     
        #endregion

        private void refresh_list_book(object sender, EventArgs e)
        {
            try
            {
                Data_Pipeline dpipe = new Data_Pipeline();
                list_wrapper_book.Clear();
                list_wrapper_book = dpipe.Get_Books();
                lv_book.Items.Clear();
                lv_document.Items.Clear();
                list_wrapper_classeurs.Clear();

                if (list_wrapper_book != null)
                {
                    foreach (data_book str in list_wrapper_book)
                    {
                        lv_book.Items.Add(str.name.ToString());
                    }
                }
            }
            catch
            {

            }
        }
       
        private void refresh_list_classeur(object sender, EventArgs e)
        {

            try
            {
                Data_Pipeline dpipe = new Data_Pipeline();
                list_wrapper_classeurs.Clear();
                list_wrapper_classeurs = dpipe.Get_All_Classeur_From_Book_ID(current_key_id_book);
                lv_classeur.Items.Clear();
                lv_document.Items.Clear();

                if (lv_classeur != null)
                {
                    foreach (data_book str in list_wrapper_classeurs)
                    {
                        lv_classeur.Items.Add(str.name.ToString());
                    }
                }
            }
            catch
            {

            }
        }
       
        private void Select_Book_Behaviour(object sender, EventArgs e)
        {

            // -- [1] => activer ou bien bloquer des boutons
            // -- [2] => trouver l'index de la listView
            // -- [3] => à partir de l'index de la listView, trouver le key_id du book
            // -- [4] => effacer le list_wrapper_book et le réécrire
            // -- [5] => effacer la listView et réécrire tout

            Lock_all_buttons();

            btn_refresh_book.Enabled = true;

            btn_add_classeur.Enabled = true;
            btn_delete_classeur.Enabled = false;
            btn_refresh_classeur.Enabled = true;

            btn_add_document.Enabled = false;
            btn_read_document.Enabled = false;
            btn_refresh_documents.Enabled = false;

            ListView lv = sender as ListView;
            int current_index;
            try
            {
                current_index = lv.SelectedItems[0].Index;
            }
            catch
            {
                return;
            }

            key_id_book_selected_only = current_index;
            int key_identifiant;
            int.TryParse(list_wrapper_book[current_index].key_id,out key_identifiant);
            Assistant_Code.Properties.Settings.Default.current_key_id_book = key_identifiant;
            current_key_id_book = key_identifiant.ToString();

            debug.Text = "Livre : " + list_wrapper_book[current_index].key_id.ToString();

            Console.WriteLine("current id_book :" + key_identifiant);

            //-- effacer --
            list_wrapper_classeurs.Clear();
            lv_classeur.Items.Clear();

            list_wrapper_document.Clear();
            lv_document.Items.Clear();

            //-- écrire --
            Data_Pipeline dpipe = new Data_Pipeline();
            list_wrapper_classeurs = dpipe.Get_All_Classeur_From_Book_ID(current_key_id_book);
            if (list_wrapper_classeurs != null)
            {
                foreach (data_book str in list_wrapper_classeurs)
                {
                    lv_classeur.Items.Add(str.name.ToString());
                }
            }
        }

        private void Select_Classeur_Behaviour(object sender, EventArgs e)
        {
            // -- [1] => activer ou bien bloquer des boutons
            // -- [2] => trouver l'index de la listView
            // -- [3] => à partir de l'index de la listView, trouver le key_id du classeur
            // -- [4] => effacer le list_wrapper_classeur et le réécrire
            // -- [5] => effacer la listView et réécrire tout

            //-- lock or unlock some buttons --
            Lock_all_buttons();

            btn_add_classeur.Enabled = true;
            btn_delete_classeur.Enabled = true;
            btn_refresh_classeur.Enabled = true;
            btn_change_classeur.Enabled = true;

            btn_add_document.Enabled = true;
            btn_read_document.Enabled = false;
            btn_refresh_documents.Enabled = true;

            //-- choper l'index --
            ListView lv = sender as ListView;
            int current_index;
            try
            {
                current_index = lv.SelectedItems[0].Index;
            }
            catch
            {
                return;
            }


            key_id_classeur_selected_only = current_index;
            Assistant_Code.Properties.Settings.Default.current_key_id_classeur =
                list_wrapper_classeurs[current_index].key_id;
            Assistant_Code.Properties.Settings.Default.Save();
            Console.WriteLine("current id_classeur :" + Assistant_Code.Properties.Settings.Default.current_key_id_classeur);

            debug.Text = "Classeur :" + Assistant_Code.Properties.Settings.Default.current_key_id_classeur;


            Data_Pipeline dp = new Data_Pipeline();
            list_wrapper_document.Clear();
            list_wrapper_document = dp.Read_Document(current_key_id_book, Assistant_Code.Properties.Settings.Default.current_key_id_classeur.ToString());
            lv_document.Items.Clear();

            foreach (text_data td in list_wrapper_document)
            {
                lv_document.Items.Add(td.name);
            }

        }

        private void Select_document_Behaviour(object sender, EventArgs e)
        {

            Lock_all_buttons();

            btn_add_document.Enabled = true;
            btn_read_document.Enabled = true;
            btn_refresh_documents.Enabled = true;

            ListView lv = sender as ListView;
            int current_index;
            try
            {
                current_index = lv.SelectedItems[0].Index;
            }
            catch
            {
                return;
            }

            key_id_document_selected_only = current_index;
            Assistant_Code.Properties.Settings.Default.current_key_id_document =
                list_wrapper_document[current_index].key_id.ToString();

            debug.Text = "document : " + list_wrapper_document[current_index].key_id.ToString() 
                + " ..... path => " + list_wrapper_document[current_index].path_to_data.ToString();
        }

        private void btn_kill_all_data(object sender, EventArgs e)
        {
            Assistant_Code.Properties.Settings.Default.book_id_counter = 0;
            Assistant_Code.Properties.Settings.Default.classeur_id_counter = 0;
            Assistant_Code.Properties.Settings.Default.document_id_counter = 0;
            Assistant_Code.Properties.Settings.Default.Save();

            string path_to_data = System.IO.Directory.GetCurrentDirectory() + "\\data";

            System.IO.Directory.Delete(path_to_data, true);

            lv_book.Items.Clear();
            lv_classeur.Items.Clear();
            lv_document.Items.Clear();

            MessageBox.Show("tout les documents ont été détruits");
        }

        private void btn_delete_click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment supprimer?", "Quelle est votre décision?", MessageBoxButtons.OKCancel);


            switch(dr)
            {
                case DialogResult.OK:

                    string key_id_classeur = list_wrapper_classeurs[key_id_classeur_selected_only].key_id;



                    //-- effacer --
                    list_wrapper_classeurs.Clear();
                    lv_classeur.Items.Clear();
                    lv_document.Items.Clear();
                    list_wrapper_document.Clear();

                    //-- écrire --


                    Data_Pipeline dpipe = new Data_Pipeline();
                    
                    
                    list_wrapper_classeurs = dpipe.Kill_Classeur(current_key_id_book, key_id_classeur);

                    if (list_wrapper_classeurs != null)
                    {
                        foreach (data_book str in list_wrapper_classeurs)
                        {
                            lv_classeur.Items.Add(str.name.ToString());
                        }
                    }

                    break;

                case DialogResult.Cancel:
                    break;
            }
        }

        private void btn_rename_classeur(object sender, EventArgs e)
        {
            new_classeur_form npf = new new_classeur_form(false);
            npf.ShowDialog();
        }

        private void add_book_Click(object sender, EventArgs e)
        {
            new_book_form nbf = new new_book_form();
            nbf.ShowDialog();
        }

        private void read_document(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            int current_index;
            try
            {
                current_index = lv.SelectedItems[0].Index;
            }
            catch
            {
                return;
            }

            key_id_document_selected_only = current_index;
            Assistant_Code.Properties.Settings.Default.current_key_id_document =
                list_wrapper_document[current_index].key_id.ToString();

            debug.Text = "document : " + list_wrapper_document[current_index].key_id.ToString()
                + " ..... path => " + list_wrapper_document[current_index].path_to_data.ToString();

            Assistant_Code.Properties.Settings.Default.Save();


            data.forms.text_editor t = new data.forms.text_editor(true);
            t.ShowDialog();
        }

        private void btn_refresh_classeur_Click(object sender, EventArgs e)
        {
            try
            {
                Data_Pipeline dpipe = new Data_Pipeline();
                list_wrapper_classeurs = dpipe.Get_All_Classeur_From_Book_ID(current_key_id_book);
                lv_classeur.Items.Clear();

                if (lv_classeur != null)
                {
                    foreach (data_book str in list_wrapper_classeurs)
                    {
                        lv_classeur.Items.Add(str.name.ToString());
                    }
                }
            }
            catch
            {

            }
        }

        private void btn_refresh_documents_Click(object sender, EventArgs e)
        {
            try
            {
                Data_Pipeline dp = new Data_Pipeline();
                list_wrapper_document.Clear();
                list_wrapper_document = dp.Read_Document(current_key_id_book, Assistant_Code.Properties.Settings.Default.current_key_id_classeur.ToString());
                lv_document.Items.Clear();

                foreach (text_data td in list_wrapper_document)
                {
                    lv_document.Items.Add(td.name);
                }
            }
            catch
            {

            }
           
        }

        private void quitterLeProgrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lock_all_buttons()
        {
            btn_refresh_book.Enabled = false;

            btn_add_classeur.Enabled = false;
            btn_delete_classeur.Enabled = false;
            btn_refresh_classeur.Enabled = false;
            btn_change_classeur.Enabled = false;

            btn_add_document.Enabled = false;
            btn_read_document.Enabled = false;
            btn_refresh_documents.Enabled = false;
        }
    }
}
