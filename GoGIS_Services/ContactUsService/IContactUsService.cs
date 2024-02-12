using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.ContactUsService
{
    public interface IContactUsService
    {
        ContactUs CreateContactUs(ContactUs model);
        List<ContactUs> AllContactUsDetails();
        ContactUs DeleteContactUs(int id);
    }
}
