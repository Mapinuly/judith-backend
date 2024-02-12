using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.RegisterEventsService
{
    public interface IRegisterEventsService
    {
        RegisterEvents CreateRegisterEvents(RegisterEvents model);
        List<RegisterEvents> AllRegisterEventsDetails();
        RegisterEvents GetEventsById(int id);
        RegisterEvents UpdateRegisterEventsDetails(RegisterEvents model);
        RegisterEvents DeleteRegisterEventsDetails(int id);
    }
}
