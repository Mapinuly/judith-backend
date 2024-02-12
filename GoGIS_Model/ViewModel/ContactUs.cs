using System.Collections.Generic;

namespace GoGIS_Model.ViewModel
{
    public class ContactUs
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sub_title { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public List<Tech_Interest> Technology_of_interest { get; set; }
        public string message { get; set; }
    }

    public class Tech_Interest
    {
        public string title { get; set; }
        public string options { get; set; }
    }
}
