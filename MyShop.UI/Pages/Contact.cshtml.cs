﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.UI.ViewModels;

namespace MyShop.UI.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactViewModel Input { get; set; }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {

        }
    }
}
