using System;

namespace GoGIS_Model.ViewModel
{
    public class UserDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public DateTime createdDate { get; set; }
    }
}
