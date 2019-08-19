﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyLeasing.Web.Helpers
{
    public interface ICombosHelpers
    {
        IEnumerable<SelectListItem> GetComboPropertyTypes();
        IEnumerable<SelectListItem> GetComboLessees();
    }
}