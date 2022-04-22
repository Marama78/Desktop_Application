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

    public partial class text_editor : Form
    {
        List<text_data> list_wrapper_document;
        string current_key_id_selected = string.Empty;
        int list_view_index_only = 0;

        bool is_new_Document = true; // [true] => empêcher de cloner un document lorsque lon clique sur le listView

        bool is_read_document = false;

        bool lock_selection = false;
        public text_editor(bool _is_reading)
        {
            InitializeComponent();
            is_read_document = _is_reading;
        }

        private void text_Load(object sender, EventArgs e)
        {
            list_wrapper_document = new List<text_data>();

            int key_book = Assistant_Code.Properties.Settings.Default.current_key_id_book;
            string key_classeur =
                Assistant_Code.Properties.Settings.Default.current_key_id_classeur;

            Data_Pipeline dp = new Data_Pipeline();
            list_wrapper_document = dp.Read_Document(key_book.ToString(), key_classeur);

            if (list_wrapper_document != null)
            {
                foreach (text_data td in list_wrapper_document)
                {
                    list_View_items.Items.Add(td.name);
                }
            }


            list_wrapper_document = Restore_Folder();

            if(is_read_document)
            {
                //-- ouvrir un document en lecture --

                foreach(text_data td in list_wrapper_document)
                {
                    if(td.key_id == Assistant_Code.Properties.Settings.Default.current_key_id_document)
                    {
                        tb_name.Text = td.name;
                        rtb_description.LoadFile(td.path_to_data);
                    }
                }


                current_key_id_selected = Assistant_Code.Properties.Settings.Default.current_key_id_document;

                is_new_Document = false;
                is_read_document = false;
            }
        }

        private List<text_data> Restore_Folder()
        {
            Console.WriteLine("\n Restore_Folder()-------------------------------------------");

            List<text_data> list_to_scan = list_wrapper_document;
            List<text_data> list_to_keep = new List<text_data>();

            string path_to_data = System.IO.Directory.GetCurrentDirectory() + '\\';
            Console.WriteLine("\n*** path_to_data _ " + path_to_data +"*** \n");

            bool kill_document = false;

            foreach (text_data td in list_to_scan)
            {
                string[] path = td.path_to_data.Split('\\');
                string old_path = string.Empty;

                //-- les 4 dernières entrées du tableau ne doivent pas être scannées --
                for(int i = 0; i<(path.Length-4);i++) 
                {
                    old_path += path[i] + '\\';
                }


                string[] path_to_keep_str = new string[4] ;
                int counter = 0;
                for (int j = path.Length-1;j> path.Length - 5;j--)
                {
                    if(counter==0)
                    {
                        path_to_keep_str[3] = path[j] ;
                        Console.WriteLine(path[j]);
                    }
                    else if (counter == 1)
                    {
                        path_to_keep_str[2] = path[j] + '\\';

                        Console.WriteLine(path[j]);
                    }
                    else if (counter == 2)
                    {
                        path_to_keep_str[1] = path[j] + '\\';

                        Console.WriteLine(path[j]);
                    }
                    else if (counter == 3)
                    {
                        path_to_keep_str[0] = path[j] + '\\';

                        Console.WriteLine(path[j]);
                    }

                    counter++;
                }

                string n_doc_path =path_to_keep_str[0]
                    + path_to_keep_str[1]
                    + path_to_keep_str[2]
                    + path_to_keep_str[3];

                Console.WriteLine("path_keep => " + n_doc_path);


                Console.WriteLine("old path _ " + old_path);
                
                text_data n_td = new text_data();
                n_td.key_id = td.key_id;
                n_td.name = td.name;

                if (path_to_data!=old_path)
                {
                    //-- les dossiers ne correspondent plus --               
                    n_td.path_to_data = path_to_data + n_doc_path;
                    kill_document = true;

                    Console.WriteLine("redone : " + path_to_data + n_doc_path);
                }
                else
                {
                    n_td.path_to_data = td.path_to_data;
                }

                list_to_keep.Add(n_td);

            }

        
            if(kill_document)
            {
                Data_Pipeline dp = new Data_Pipeline();

                string path_to_kill = 
                    System.IO.Directory.GetCurrentDirectory() +
                    "\\data\\data_book_" + Assistant_Code.Properties.Settings.Default.current_key_id_book +
                    "\\classeur_" + Assistant_Code.Properties.Settings.Default.current_key_id_classeur + ".dat";

                Console.WriteLine("is killing document at : " + path_to_kill);

                System.IO.File.Delete(path_to_kill);
                var newdata = System.IO.File.Create(path_to_kill);
                newdata.Close();


                foreach(text_data td in list_to_keep)
                {
                    string data = td.key_id + '|' + td.name + '|' + td.path_to_data;

                    dp.Write_Line_Data(path_to_kill, data);
                } 
            }

            Console.WriteLine("Restore_Folder()------------------------------------------- \n ");

            return list_to_keep;

        }

        private void get_keys(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    /// btn_save_click(sender, e);
                    MessageBox.Show("Le document a été correctement sauvegardé!");
                    break;

                case Keys.F2:
                    /// btn_ajouter_click(sender, e);
                    MessageBox.Show("Une nouvelle ligne a été rajoutée");
                    break;
            }
        }



        private void btn_new_page(object sender, EventArgs e)
        {
            tb_name.Text = "";
            rtb_description.Clear();

            is_new_Document = true;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez-vous enregistrer avant de quitter?", "Alerte", MessageBoxButtons.YesNo);

            switch (dr)
            {
                case DialogResult.Yes:
                    // to do : sauver le document en cours
                    break;

                case DialogResult.No:
                    this.Close();
                    break;
            }
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_reduce_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

        }
        private void btn_save_click(object sender, EventArgs e)
        {
            Save_Document_Inside_Classeur();
        }

        public void Save_Document_Inside_Classeur()
        {
            Console.WriteLine("\n savedocument()----------------------------------------------------");
            //-- [1.1] => vérifier tout les chemins d'accès vers 
            //-- [1.2] => voir si une clé est recyclable ou bien en créer une nouvelle
            //-- [2] => créer le contenu du rich text box et le sauver dans le dossier
            //-- Edit path to description file --

            #region vérifier tout les chemins d'accès et attribuer une nouvelle clé
            // -- [path_to_file] => y écrire le data
            // -- [path to user_key_file] => lire des clés disponibles
                 
            string path_to_folder =
                   System.IO.Directory.GetCurrentDirectory() +
                   "\\data\\data_book_" +
                   Assistant_Code.Properties.Settings.Default.current_key_id_book.ToString();

            if (!System.IO.Directory.Exists(path_to_folder))
            {
                System.IO.Directory.CreateDirectory(path_to_folder);
            }

            string path_to_file =
                path_to_folder +
                "\\classeur_"
                + Assistant_Code.Properties.Settings.Default.current_key_id_classeur.ToString()
                + ".dat";

            if (!System.IO.File.Exists(path_to_file))
            {
                var new_fit = System.IO.File.Create(path_to_file);
                new_fit.Close();
            }

            string path_to_user_key_file =
                System.IO.Directory.GetCurrentDirectory() + "\\data\\user_key.dat";

            //  int key_id_document_counter
            int new_key_id_for_document = -100;

          //  string key_classeur = Assistant_Code.Properties.Settings.Default.current_key_id_classeur.ToString();
            string new_key_identifiant = string.Empty;

            if (is_new_Document)
            {
                Console.WriteLine("path_too user_key is : " + path_to_user_key_file);
                
                List<string> list_to_keep = new List<string>();
                    int state_to_read = 0;

                if (!System.IO.File.Exists(path_to_user_key_file))
                {
                    //-- le document n'existe pas donc on va attribuer une nouvelle clé --
                    new_key_id_for_document = Assistant_Code.Properties.Settings.Default.document_id_counter;
                    new_key_id_for_document++;
                    Assistant_Code.Properties.Settings.Default.document_id_counter = new_key_id_for_document;

                    Assistant_Code.Properties.Settings.Default.Save();

                    new_key_identifiant =
                        Assistant_Code.Properties.Settings.Default.current_key_id_classeur.ToString() + '_' +
                        new_key_id_for_document.ToString();
                }
                else if (System.IO.File.Exists(path_to_user_key_file))
                {
                    //-- le document existe, donc on va y lire les clés (si elles y existent)
                    //-- si on ne trouve aucune clé valides, on en créé une nouvelle


                    List<string> list_content_keys = new List<string>(System.IO.File.ReadAllLines(path_to_user_key_file));

                    
                    foreach (string str in list_content_keys)
                    {

                        if(state_to_read ==1)
                        {
                            try
                            {
                                //-- une clé valide est trouvée --
                                string[] data_keys = str.Split('|');

                                if (data_keys[0].Length>2)
                                {
                                    state_to_read = 1111; // arbitraire!!
                                    new_key_identifiant = data_keys[0];
                                    Console.WriteLine("clé à recycler : " + new_key_identifiant);
                                    
                                    string keys_to_keep = string.Empty;


                                    for (int i = 1; i < data_keys.Length; i++)
                                    {
                                        if (data_keys[i].Length>2)
                                        {
                                            keys_to_keep += data_keys[i] + '|';
                                        }
                                    }
                                    list_to_keep.Add(keys_to_keep);
                                }
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            list_to_keep.Add(str);
                        }

                        if (str == "document")
                        {
                            state_to_read = 1;
                        }
                    }

                    // -- aucune clé valide, donc on va attribuer une nouvelle clé au document --
                    if (state_to_read != 1111)
                    {
                        Console.WriteLine("nouvelle clé : automatique");
                        new_key_id_for_document = Assistant_Code.Properties.Settings.Default.document_id_counter;
                        new_key_id_for_document++;
                        Assistant_Code.Properties.Settings.Default.document_id_counter = new_key_id_for_document;

                        Assistant_Code.Properties.Settings.Default.Save();

                        new_key_identifiant =
                            Assistant_Code.Properties.Settings.Default.current_key_id_classeur.ToString() + '_' +
                            new_key_id_for_document.ToString();
                    }


                  
                }

                if (state_to_read == 1111)
                { 
                    // -- destruction du document + création + recopie --
                    System.IO.File.Delete(path_to_user_key_file);
                    var new_user_key_data = System.IO.File.Create(path_to_user_key_file);
                    new_user_key_data.Close();

                    Data_Pipeline dpipe = new Data_Pipeline();

                    foreach (string str in list_to_keep)
                    {
                        dpipe.Write_Line_Data(path_to_user_key_file, str);
                    }

                    Console.WriteLine("toutes les clés ont été correctement réécrites");
                }
            }
            else if (!is_new_Document)
            {

                if (current_key_id_selected != string.Empty)
                {
                    new_key_identifiant =
                        current_key_id_selected;
                }
                else
                {
                    MessageBox.Show("violation d'écriture : opération rejetée");
                    return;
                }
            }
         

            // -- read id --
            Console.WriteLine("newkey is " + new_key_identifiant + " | is_new_document is :" + is_new_Document);

            if (new_key_identifiant == string.Empty)
            {
                return;
            }

            #endregion

            #region sauver le contenu du richtextbox
            // -- make the document path --
            string path_to_folder_document =
                path_to_folder + "\\classeur_" +
                Assistant_Code.Properties.Settings.Default.current_key_id_book.ToString();

            if (!System.IO.Directory.Exists(path_to_folder_document))
            {
                System.IO.Directory.CreateDirectory(path_to_folder_document);
            }

            string path_to_document =
                   path_to_folder_document +
                   "\\document_" + new_key_identifiant + ".dat";

            if (!System.IO.File.Exists(path_to_document))
            {
                var new_fil = System.IO.File.Create(path_to_document);
                new_fil.Close();
            }
            else
            {
                System.IO.File.Delete(path_to_document);
                var new_fis = System.IO.File.Create(path_to_document);
                new_fis.Close();
            }

            if (rtb_description.Text != null)
            {
                rtb_description.SaveFile(path_to_document);

            }
            else
            {
                rtb_description.Text = " ";
                rtb_description.SaveFile(path_to_document);
            }

            #endregion

            // -- editing the new data for my object --
            string _str_data =
                new_key_identifiant + '|' +
                tb_name.Text + '|' +
                path_to_document;



            List<string> list_content = new List<string>(System.IO.File.ReadAllLines(path_to_file));
            List<string> list_temp = new List<string>();
            foreach(string str  in list_content)
            {
                string[] str_data = str.Split('|');

                if(str_data[0]!=new_key_identifiant)
                {
                    list_temp.Add(str);
                }
            }


            System.IO.File.Delete(path_to_file);
            var new_fi = System.IO.File.Create(path_to_file);
            new_fi.Close();

            Data_Pipeline dp = new Data_Pipeline();
            foreach(string str in list_temp)
            {
                dp.Write_Line_Data(path_to_file, str);
            }
            
           dp.Write_Line_Data(path_to_file, _str_data);


            Assistant_Code.Properties.Settings.Default.Save();


            list_View_items.Items.Clear();

            int key_book = Assistant_Code.Properties.Settings.Default.current_key_id_book;
            string _key_classeur = Assistant_Code.Properties.Settings.Default.current_key_id_classeur;

            list_wrapper_document = dp.Read_Document(key_book.ToString(), _key_classeur);

            if (list_wrapper_document != null)
            {
                foreach (text_data td in list_wrapper_document)
                {
                    list_View_items.Items.Add(td.name);
                }
            }

            Console.WriteLine(" savedocument()---------------------------------------------------- \n");

        }



        #region commandes de l'éditeur de texte

        //------------------------------------------------
        //----EDITEUR DE TEXTE INTéGRé -------------------
        //------------------------------------------------


        private void btn_code_style_click(object sender, EventArgs e)
        {
            // RichTextBox rtb = sender as RichTextBox;

            var words = rtb_description.Text.Split(
                new char[]
                { ' ', '\n', '\t', '.', '{', '}',
                    ':', '(', ')', '/', '"', ',' ,';'
                ,'<','>'}, StringSplitOptions.RemoveEmptyEntries);
            // var words = rtb_description.Text.Split(new char[] { ' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            int index = -1;

            foreach (var word in words)
            {
                index = rtb_description.Text.IndexOf(word, (index + 1));

                if (index > -1)
                {
                    rtb_description.Select(index, word.Length);
                    rtb_description.SelectionFont = new Font("Consolas", 14f);
                    // If the selected text as the specified color
                    if (rtb_description.SelectionColor == Color.Black)
                    {

                        rtb_description.SelectionColor = Color.LemonChiffon;
                    }

                    else if (rtb_description.SelectionColor == Color.Blue)
                    {
                        rtb_description.SelectionColor = Color.SteelBlue;
                    }
                    else if (rtb_description.SelectionColor == Color.MediumBlue)
                    {
                        rtb_description.SelectionColor = Color.MediumPurple;
                    }
                    else if (rtb_description.SelectionColor == Color.DarkViolet)
                    {
                        rtb_description.SelectionColor = Color.Crimson;
                    }

                    else if (rtb_description.SelectionColor == Color.Green)
                    {
                        // rtb_description.SelectionColor = Color.LimeGreen;
                    }
                    else
                    {
                        rtb_description.SelectionColor = Color.HotPink;
                    }
                }
            }

            for (int i = 0; i < rtb_description.Text.Length; i++)
            {

                if (rtb_description.Text[i] == '{'
                    || rtb_description.Text[i] == '}'
                    || rtb_description.Text[i] == '('
                    || rtb_description.Text[i] == ')'
                    || rtb_description.Text[i] == '.'
                   || rtb_description.Text[i] == ';'
                   || rtb_description.Text[i] == ':'
                   || rtb_description.Text[i] == ','
                   || rtb_description.Text[i] == '"'
                   || rtb_description.Text[i] == '<'
                   || rtb_description.Text[i] == '>')
                {
                    rtb_description.SelectionStart = i;
                    rtb_description.SelectionLength = 1;
                    rtb_description.SelectionColor = Color.LemonChiffon;
                }

                if (rtb_description.Text[i] == '*'
                    || rtb_description.Text[i] == '&')
                {
                    rtb_description.SelectionStart = i;
                    rtb_description.SelectionLength = 1;
                    rtb_description.SelectionColor = Color.Cyan;
                }
            }
        }



        private void font_dialog_click(object sender, EventArgs e)
        {
            this.fdialog.ShowDialog();
            this.rtb_description.SelectionFont = fdialog.Font;
        }

        private void forecolore_font_dialog_click(object sender, EventArgs e)
        {
            this.cdialog.ShowDialog();
            this.rtb_description.SelectionColor = cdialog.Color;
        }

        private void font_background_color_click(object sender, EventArgs e)
        {
            this.cdialog.ShowDialog();
            this.rtb_description.SelectionBackColor = cdialog.Color;
        }

        private void align_left_click(object sender, EventArgs e)
        {
            this.rtb_description.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void align_center_click(object sender, EventArgs e)
        {
            this.rtb_description.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void align_right_click(object sender, EventArgs e)
        {
            this.rtb_description.SelectionAlignment = HorizontalAlignment.Right;

        }

        private void copy_click(object sender, EventArgs e)
        {
            this.rtb_description.Copy();
        }

        private void paste_click(object sender, EventArgs e)
        {
            this.rtb_description.Paste();

        }



        private void btn_rise_font_12(object sender, EventArgs e)
        {
            rtb_description.SelectionFont = new Font(Font.FontFamily, 12f);

        }
        private void btn_rise_font_14(object sender, EventArgs e)
        {

            rtb_description.SelectionFont = new Font(Font.FontFamily, 14f);
        }
        private void btn_rise_font_16(object sender, EventArgs e)
        {
            rtb_description.SelectionFont = new Font(Font.FontFamily, 16f);

        }

        private void btn_rise_font_18(object sender, EventArgs e)
        {
            rtb_description.SelectionFont = new Font(Font.FontFamily, 18f);

        }

        private void btn_style_regular(object sender, EventArgs e)
        {
            rtb_description.SelectionFont = new Font(Font.FontFamily, Font.Height, FontStyle.Regular);

        }

        private void btn_style_bold(object sender, EventArgs e)
        {
            rtb_description.SelectionFont = new Font(Font.FontFamily, Font.Height, FontStyle.Bold);

        }

        private void btn_style_italic(object sender, EventArgs e)
        {
            rtb_description.SelectionFont = new Font(Font.FontFamily, Font.Height, FontStyle.Italic);

        }

        private void btn_style_underline(object sender, EventArgs e)
        {
            rtb_description.SelectionFont = new Font(Font.FontFamily, Font.Height, FontStyle.Underline);

        }
        private void btn_color_red(object sender, EventArgs e)
        {
            rtb_description.SelectionColor = Color.Red;
        }

        private void btn_color_lemonchiffon(object sender, EventArgs e)
        {
            rtb_description.SelectionColor = Color.LemonChiffon;

        }

        private void btn_color_deepskyblue(object sender, EventArgs e)
        {
            rtb_description.SelectionColor = Color.DeepSkyBlue;

        }

        private void btn_color_fuschia(object sender, EventArgs e)
        {
            rtb_description.SelectionColor = Color.Fuchsia;

        }
        private void btn_color_forestgreen(object sender, EventArgs e)
        {
            rtb_description.SelectionColor = Color.ForestGreen;

        }

        private void btn_color_yellow(object sender, EventArgs e)
        {
            rtb_description.SelectionColor = Color.Yellow;
        }



        #endregion

        private void list_view_document_selected(object sender, EventArgs e)
        {
            
                ListView lv = sender as ListView;
                int current_index = 0;
                try
                {
                    current_index = lv.SelectedItems[0].Index;
                }
                catch
                {
                    return;
                }
                list_view_index_only = current_index;

                current_key_id_selected = list_wrapper_document[current_index].key_id;

                Console.WriteLine("key_identifiant of the document is " + current_key_id_selected);

                Assistant_Code.Properties.Settings.Default.current_key_id_document =
                    list_wrapper_document[current_index].key_id;


                is_new_Document = false;


                path_to_document.Text = list_wrapper_document[current_index].path_to_data;
                tb_name.Text = list_wrapper_document[current_index].name;
               
                try
                {
                    rtb_description.LoadFile(list_wrapper_document[current_index].path_to_data);
                }
                catch
                {

                }

            
        }

        private void btn_delete_document(object sender, EventArgs e)
        {
            //-- [1] => lire et écrire la clé effacée dans le fichier '...\data\user_key.dat'
            //-- [2] => lire et écrire la clé effacée dans le fichier '...\data\data_book_{clé book}\classeur_{clé classeur].dat'
            //-- [3] => détruire le document de description du fichier '...\data\classeur_{clé_classseur}\document_{full_clé_document}";
            //---------- rappel : full clé => {clé book} + '_' + {clé classeur} + '_' + {clé document}
            //-- [4] effacer la list_view et réécrire les nouvelles données

            Console.WriteLine("\n delete()");

            #region partie 1 : lire et écrire la clé effacée
            string key_to_save =
                    Assistant_Code.Properties.Settings.Default.current_key_id_document;
            // result is : 0_1_2

            bool is_valid = false;

            for(int i = 0; i<list_View_items.Items.Count;i++)
            {
                if (!is_valid)
                {
                    if (list_wrapper_document[i].key_id == key_to_save)
                    {
                        is_valid = true;
                    }
                }
            }

            if(!is_valid)
            {
                MessageBox.Show("erreur");
                return;
            }

            Console.WriteLine("key_to_save is : " + key_to_save);
            string path_to_file_user_keys =
                  System.IO.Directory.GetCurrentDirectory() +
                  "\\data\\user_key.dat";

            //-- créer le fichier si il n'existe pas --
            if (!System.IO.File.Exists(path_to_file_user_keys))
            {
                var new_file = System.IO.File.Create(path_to_file_user_keys);
                new_file.Close();
            }

            List<string> list_content = new List<string>(System.IO.File.ReadAllLines(path_to_file_user_keys));

            Data_Pipeline dp = new Data_Pipeline();


            if (list_content == null)
            {
                string[] data = { "book", "", "classeur", "", "document", "" };

                for (int i = 0; i < 6; i++)
                {
                    dp.Write_Line_Data(path_to_file_user_keys, data[i]);
                }
            }
            else if (list_content != null && list_content.Count == 0)
            {
                string[] data = { "book", "", "classeur", "", "document", "" };

                for (int i = 0; i < 6; i++)
                {
                    dp.Write_Line_Data(path_to_file_user_keys, data[i]);
                }
            }
            
            if (list_content != null && list_content.Count > 0)
            {
                Console.WriteLine("good way + " + list_content.Count);
                if (list_content.Count < 6) list_content.Add("");


                int state_data = 0;
                List<string> list_data_to_rewrite = new List<string>();

                foreach (string str in list_content)
                {
                    Console.WriteLine("str : " + str);
                    if (state_data == 1)
                    {
                        string new_data = str  + key_to_save+'|';

                        if (str == "")
                        {
                            new_data = key_to_save + '|';
                        }

                        list_data_to_rewrite.Add(new_data);
                        state_data = 0;
                    }
                    else
                    {
                        list_data_to_rewrite.Add(str);
                    }


                    if (str == "document")
                    {
                        state_data = 1;
                    }
                }

                //-- delete and recreate file --

                System.IO.File.Delete(path_to_file_user_keys);
                var new_fi = System.IO.File.Create(path_to_file_user_keys);
                new_fi.Close();


                if (list_data_to_rewrite.Count > 0)
                {
                    foreach (string str in list_data_to_rewrite)
                    {
                        dp.Write_Line_Data(path_to_file_user_keys, str);
                        Console.WriteLine(str);
                    }
                }

            }
            #endregion


            #region partie 2 : lire et effacer dans le répertoire du classeur

            string path_to_classeur_file =
                System.IO.Directory.GetCurrentDirectory() +
                "\\data\\data_book_" + Assistant_Code.Properties.Settings.Default.current_key_id_book.ToString() +
                "\\classeur_" + Assistant_Code.Properties.Settings.Default.current_key_id_classeur.ToString() + ".dat";

          
            // -- lecture --
            List<string> list_content_classeur = new List<string>(System.IO.File.ReadAllLines(path_to_classeur_file));
            List<string> list_data_to_keep_in_classeur = new List<string>();

            foreach(string str in list_content_classeur)
            {
                string[] data = str.Split('|');
                if(data[0]!=key_to_save)
                {
                    list_data_to_keep_in_classeur.Add(str);
                }
            }

            // -- écriture --
            System.IO.File.Delete(path_to_classeur_file);
            var new_classeur = System.IO.File.Create(path_to_classeur_file);
            new_classeur.Close();

            foreach (string str in list_data_to_keep_in_classeur)
            {
                dp.Write_Line_Data(path_to_classeur_file, str);
            }

            #endregion 

            #region partie 3 : détruire le document attachée à la donnée

            string path_to_description = list_wrapper_document[list_view_index_only].path_to_data;

            if(!System.IO.File.Exists(path_to_description))
            {
                // done;
            }
            else if (System.IO.File.Exists(path_to_description))
            {

                System.IO.File.Delete(path_to_description);
            }

            #endregion

            #region partie 4 : mise à jour de la list_view

            list_wrapper_document.Clear();
            list_View_items.Items.Clear();
            int key_book = Assistant_Code.Properties.Settings.Default.current_key_id_book;
            string key_classeur =
                Assistant_Code.Properties.Settings.Default.current_key_id_classeur;

            list_wrapper_document = dp.Read_Document(key_book.ToString(), key_classeur);

            if (list_wrapper_document != null)
            {
                foreach (text_data td in list_wrapper_document)
                {
                    list_View_items.Items.Add(td.name);
                }
            }

            #endregion


            Console.WriteLine("delete()\n");

        }

        private void unlock_btn(object sender, EventArgs e)
        {
           if(tb_name.Text.Length>0)
            {
                btn_save.Enabled = true;
                btn_delete.Enabled = true;
            }
           else
            {
                btn_save.Enabled = false;
                btn_delete.Enabled = false;
            }
        }
    }
}
