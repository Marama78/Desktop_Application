using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder_data_manager
{

    public struct data_book
    {
        public string key_id { get; set; }
        public string name { get; set; }
    }
    public struct data_parent
   {
        public string key_id { get; set; }
        public string name { get; set; }
        public string description_data { get; set; }
   }

    public struct text_data
    {
        public string key_id { get; set; }
        public string name { get; set; }
        public string path_to_data { get; set; }

    }

}
