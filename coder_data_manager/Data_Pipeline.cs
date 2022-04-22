using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder_data_manager
{
    public class Data_Pipeline
    {

        public List<data_book> Get_Books()
        {
            string path = System.IO.Directory.GetCurrentDirectory();

            string folder_data = "\\data";
            string file = "\\initiate.ini";

            if (!System.IO.Directory.Exists(path + folder_data))
            {
                Directory.CreateDirectory(path + folder_data);
            }
           
            string final_path = path + folder_data + file;

            if (!File.Exists(final_path))
            {
                var new_file = File.Create(final_path);
                new_file.Close();
            }

            List<string> list_content = new List<string>(File.ReadAllLines(final_path));
            List<data_book> list_result = new List<data_book>();

            foreach (string str in list_content)
            {
                string[] data = str.Split('|');
                data_book dp = new data_book();
                dp.key_id = data[0];
                dp.name = data[1];
                list_result.Add(dp);
            }

            return list_result;
        }

        public List<data_book> Get_All_Classeur_From_Book_ID(string key_book)
        {
            string path = System.IO.Directory.GetCurrentDirectory();

            string folder_data = "\\data";
            string data_file = "\\data_book_" + key_book + ".dat";


            if (!System.IO.Directory.Exists(path + folder_data))
            {
                Directory.CreateDirectory(path + folder_data);
            }

            string final_path = path + folder_data + data_file;

            if (!File.Exists(final_path))
            {
                var new_file = File.Create(final_path);
                new_file.Close();
            }

            List<string> list_content = new List<string>(File.ReadAllLines(final_path));
            List<data_book> list_result = new List<data_book>();

            foreach (string str in list_content)
            {
                string[] data = str.Split('|');

                string[] str_key = data[0].Split('_');
                if (str_key[0] == key_book.ToString())
                {
                    data_book dp = new data_book();
                    dp.key_id = data[0];
                    dp.name = data[1];
                    list_result.Add(dp);
                }
            }

            return list_result;
        }

        public List<data_book> Get_All_Classeur_From_Book_ID(int key_book)
        {
            string path = System.IO.Directory.GetCurrentDirectory();

            string folder_data = "\\data";
            string data_file = "\\data_book_" + key_book + ".dat";


            if (!System.IO.Directory.Exists(path + folder_data))
            {
                Directory.CreateDirectory(path + folder_data);
            }

            string final_path = path + folder_data + data_file;

            if (!File.Exists(final_path))
            {
                var new_file = File.Create(final_path);
                new_file.Close();
            }

            List<string> list_content = new List<string>(File.ReadAllLines(final_path));
            List<data_book> list_result = new List<data_book>();

            foreach (string str in list_content)
            {
                string[] data = str.Split('|');

                string[] str_key = data[0].Split('_');
                if (str_key[0] == key_book.ToString())
                {
                    data_book dp = new data_book();
                    dp.key_id = data[0];
                    dp.name = data[1];
                    list_result.Add(dp);
                }
            }

            return list_result;
        }

        public List<text_data> Read_Document(string key_book, string _key_classeur)
        {
            string path = System.IO.Directory.GetCurrentDirectory();

            string folder_data = "\\data";
            string folder_data_book = "\\data_book_" + key_book;
            string file_data_book = "\\classeur_" + _key_classeur + ".dat";


            if (!System.IO.Directory.Exists(path + folder_data))
            {
                Directory.CreateDirectory(path + folder_data);
            }



            if (!System.IO.Directory.Exists(path + folder_data + folder_data_book))
            {
                Directory.CreateDirectory(path + folder_data + folder_data_book);

            }


            string final_path = path + folder_data + folder_data_book + file_data_book;


            if (!File.Exists(final_path))
            {
                var new_file = File.Create(final_path);
                new_file.Close();
            }



            List<string> list_content = new List<string>(File.ReadAllLines(final_path));
            List<text_data> list_result = new List<text_data>();

            string key_to_find = _key_classeur.ToString();

            if (list_content != null)
            {
                foreach (string str in list_content)
                {
                    string[] data = str.Split('|');
                    string[] str_key = data[0].Split('_');

                    string str_key_redone = str_key[0] + '_' + str_key[1];

                    if (str_key_redone == key_to_find)
                    {
                        text_data dp = new text_data();
                        dp.key_id = data[0];
                        dp.name = data[1];
                        dp.path_to_data = data[2];

                        list_result.Add(dp);
                    }
                }
            }

            return list_result;
        }

        public List<data_book> Kill_Classeur(string _key_book,string _key_classeur)
        {
            //------------------------------------------------------------------
            // -- data_book_ .. .dat                 -> contient la liste des classeur du livre
            // -- data_book_ .. \\ classeur_ .. .dat -> contient tout les documents attachés au classeurs
            //------------------------------------------------------------------

            // -- [1] accéder au gestionnaire : data_book_ {clé livre } --
            // -- [2] y supprimer la ligne correspondante au classeur --
            // -- [3] réécrire le contenu sans la ligne détruite --
            string key_classeur_to_kill;
            
            string path = System.IO.Directory.GetCurrentDirectory();

            string folder_data = "\\data";
            string data_file = "\\data_book_" + _key_book + ".dat";


            if (!System.IO.Directory.Exists(path + folder_data))
            {
                Console.WriteLine("nothing to destroy. violation processus");
                Directory.CreateDirectory(path + folder_data);
            }

            string final_path = path + folder_data + data_file;

            if (!File.Exists(final_path))
            {
                var new_filer = File.Create(final_path);
                new_filer.Close();
            }

            List<string> list_content = new List<string>(File.ReadAllLines(final_path));
            List<data_book> list_result = new List<data_book>();

            foreach (string str in list_content)
            {
                string[] data = str.Split('|');

                if (data[0] != _key_classeur.ToString())
                {
                    data_book dp = new data_book();
                    dp.key_id = data[0];
                    dp.name = data[1];
                    list_result.Add(dp);
                }
            }

            //-- override file --

            System.IO.File.Delete(final_path);
            var new_file = File.Create(final_path);
            new_file.Close();

            foreach (data_book item in list_result)
            {
                string data_to_write =
                item.key_id + '|' +
                item.name;

                Write_Line_Data(final_path, data_to_write);
            }


            //-- destroy all document linked --
            string path_to_classeur_data =
               path+ folder_data + "\\data_book_" + _key_book.ToString() + "\\classeur_" + _key_classeur + ".dat";
            Console.WriteLine("path_to_document to kill " + path_to_classeur_data);

            if(System.IO.File.Exists(path_to_classeur_data))
            {
                List<string> list_content_to_kill = new List<string>(File.ReadAllLines(path_to_classeur_data));

                foreach(string str in list_content_to_kill)
                {
                    string[] data = str.Split('|');

                    string document_to_delete = data[2];

                    try
                    {
                        System.IO.File.Delete(document_to_delete);

                    }
                    catch
                    {

                    }
                }

            }

            System.IO.File.Delete(path_to_classeur_data);

            return list_result;
        }

        /// <summary>
        /// Ecrire une nouvelle ligne dans le fichier spécifié
        /// </summary>
        /// <param name="_path_to_file"></param>
        /// <param name="_data_to_write"></param>
        public void Write_Line_Data(string _path_to_file, string _data_to_write)
        {
            if (!System.IO.File.Exists(_path_to_file))
            {
                var new_file = System.IO.File.Create(_path_to_file);
                new_file.Close();
            }

            System.IO.StreamWriter sr = new System.IO.StreamWriter(_path_to_file, append:true);
            sr.WriteLine(_data_to_write);
            sr.Close();
        }
    }
}
