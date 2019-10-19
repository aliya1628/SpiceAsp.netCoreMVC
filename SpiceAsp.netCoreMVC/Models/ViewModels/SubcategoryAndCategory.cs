using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceAsp.netCoreMVC.Models.ViewModels
{
    public class SubcategoryAndCategory
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<string> SubcategoryList { get; set; }
        public string StatusMessage { get; set; }

    }
}
