using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charisma.MVC.Models
{
    public static class HistoryHelper
    {
        public static List<object> Items { get; set; } = new List<object>();

        public static void Clear()
        {
            Items.Clear();
        }
    }
}
