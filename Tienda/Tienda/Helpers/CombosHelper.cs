using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda.Data;
using Tienda.Data.Entities;

namespace Tienda.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync()
        {
            //Video: https://youtu.be/w-CP_dnRYaI?si=iG84KJbAMh7cJivy, minuto 1.01.01

            List<SelectListItem> List = await _dataContext.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            })
                .OrderBy(c => c.Text)
                .ToListAsync();
            List.Insert(0,new SelectListItem { Value = "0", Text="[Seleccione una categoria...]" });
            return List;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId)
        {
            List<SelectListItem> List = await _dataContext.Cities
              .Where(s => s.state.Id == stateId)
              .Select(c => new SelectListItem
              {
                  Text = c.Name,
                  Value = c.Id.ToString()
              })
             .OrderBy(c => c.Text)
             .ToListAsync();
            List.Insert(0, new SelectListItem { Value = "0", Text = "[Seleccione una ciudad...]" });
            return List;

        }

        public async Task<IEnumerable<SelectListItem>> GetComboCountriesAsync()
        {
            List<SelectListItem> List = await _dataContext.Countries.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            })
                 .OrderBy(c => c.Text)
                 .ToListAsync();
            List.Insert(0, new SelectListItem { Value = "0", Text = "[Seleccione un pais...]" });
            return List;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId)
        {
            List<SelectListItem> List = await _dataContext.States
               .Where(s => s.country.Id == countryId)
               .Select(c => new SelectListItem
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               })
              .OrderBy(c => c.Text)
              .ToListAsync();
            List.Insert(0, new SelectListItem { Value = "0", Text = "[Seleccione un departamento...]" });
            return List;
        }
    }
}
