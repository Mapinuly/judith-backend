using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.SliderService
{
    public interface ISliderService
    {
        Slider CreateSlider(Slider model);
        List<Slider> AllSliderDetails();
        Slider GetSliderById(int id);
        Slider UpdateSliderDetails(Slider model);
        Slider DeleteSliderDetails(int id);
    }
}
