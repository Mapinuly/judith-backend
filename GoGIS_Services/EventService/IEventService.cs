using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.EventService
{
    public interface IEventService
    {
        Events CreateUpcomingEvents(Events model);
        List<Events> AllUpcomingEventsDetails();
        Events GetEventsById(int id);
        Events UpdateUpcomingEventsDetails(Events model);
        Events DeleteUpcomingEventsDetails(int id);
        List<Events> AllEventsDetails();
    }
}
