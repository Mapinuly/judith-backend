using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.HereService
{
    public interface IHereService
    {
        Here CreateHere(Here model);
        List<Here> AllHereDetails();
        Here GetHereById(int id);
        //Here UpdateHereDetails(Here model);
        Here DeleteHereDetails(int id);
    }
}
