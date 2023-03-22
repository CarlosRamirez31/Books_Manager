﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Core.Application.Parameters
{
    public class FilterRequest : PaginationRequest
    {
        public int? NumFilter { get; set; }
        public string? TextFilter { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public bool? Download { get; set; }
    }
}
