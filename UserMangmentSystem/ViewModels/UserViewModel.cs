using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMangmentSystem.Models;

namespace UserMangmentSystem.ViewModels
{
    public class UserViewModel
    {
        public User user { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
