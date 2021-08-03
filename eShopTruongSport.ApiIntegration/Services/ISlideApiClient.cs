using eShopTruongSport.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopTruongSport.ApiIntegration.Services
{
    public interface ISlideApiClient
    {
        Task<List<SlideVm>> GetAll();
    }
}
