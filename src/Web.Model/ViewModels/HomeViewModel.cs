﻿#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.ViewModels
{
    public class HomeViewModel : LayoutViewModel
    {
        public IEnumerable<EntrySummaryViewModel> Entries { get; set; }
    }
}
