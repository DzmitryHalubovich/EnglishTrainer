﻿using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.QueryOptions;

namespace EnglishTrainer.Web.Services.QueryOptions
{
    public class VerbQueryOptions
    {
        public PageOptions PageOptions { get; set; }
        public VerbQueryOptions()
        {
            PageOptions = new PageOptions(100, 1, ApplicationConstants.VerbsPageSize);
        }
    }
}