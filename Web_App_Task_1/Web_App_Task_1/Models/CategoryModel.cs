using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App_Task_1.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string DefaultImage { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool isActive { get; set; }
        public DateTime updatedOn { get; set; }

    }
}