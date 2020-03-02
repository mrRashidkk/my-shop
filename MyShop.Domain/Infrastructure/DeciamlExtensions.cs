using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Infrastructure
{
    public static class DeciamlExtensions
    {
        public static string GetValueString(this decimal value) => $"$ {value.ToString("N2")}";
    }
}
