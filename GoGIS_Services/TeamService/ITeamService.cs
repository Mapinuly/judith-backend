using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.TeamService
{
    public interface ITeamService
    {
        Team CreateTeam(Team model);
        List<Team> AllTeamDetails();
        Team GetTeamById(int id);
        Team UpdateTeamDetails(Team model);
        Team DeleteTeamDetails(int id);
    }
}
