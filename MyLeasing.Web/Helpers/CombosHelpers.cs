using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLeasing.Web.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyLeasing.Web.Helpers
{
    public class CombosHelpers : ICombosHelpers
    {
        private readonly DataContext _dataContext;

        public CombosHelpers(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboPropertyTypes()
        {
            var list = _dataContext.PropertyTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                //Conversion con interpolacion
                Value = $"{pt.Id}"
            })
                .OrderBy(p => p.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a property type...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboLessees()
        {
            var list = _dataContext.Lessees.Include(l => l.User).Select(l => new SelectListItem
            {
                Text = l.User.FullNameWithDocument,
                Value = l.Id.ToString()
            }).OrderBy(pt => pt.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a lessee...)",
                Value = "0"
            });

            return list;
        }

    }
}
