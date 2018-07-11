﻿using MyEverNote.BusinessLayer;
using MyEverNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace WebApplication1.Models
{
    public class CacheHelper
    {
        public static List<Category> GetCategoriesFromCache()
        {
            var result = WebCache.Get("category-cache");
            if (result == null)
            {
                CategoryManager categoryManager = new CategoryManager();
                result = categoryManager.List();
                WebCache.Set("category-cache",result,20,true);
            }
            return result;
        }
        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }
        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}