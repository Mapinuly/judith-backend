using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.SynopsisService
{
    public interface ISynopsisService
    {
        Synopsis CreateUpcomingSynopsis(Synopsis model);
        List<Synopsis> AllUpcomingSynopsisDetails();
        Synopsis GetSynopsisById(int id);
        //Synopsis UpdateUpcomingSynopsisDetails(Synopsis model);
        Synopsis DeleteUpcomingSynopsisDetails(int id);
    }
}
