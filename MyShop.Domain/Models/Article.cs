﻿using System;

namespace MyShop.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Preview { get; set; }
        public string Text { get; set; }
        public string ImageName { get; set; }
    }
}
