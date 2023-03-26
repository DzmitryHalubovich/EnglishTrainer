﻿// Copyright (c) 2020 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EnglishTrainer.Infrastructure.SortOptions
{
    public class SortFilterPageOptions
    {
        public const int DefaultPageSize = 2; //default page size is 10

        //-----------------------------------------
        //Paging parts, which require the use of the method

        private int _pageNum = 1;

        private int _pageSize = DefaultPageSize;

        public int ElementsCount { get;set; }
        
        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public bool HasNextPage(int pagesCount)
        {
            return PageNum <  pagesCount;
        }

        public bool HasPrevPage()
        {
            return PageNum>1;
        }

    }
}