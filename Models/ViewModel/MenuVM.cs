using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Models.ViewModel
{
    public class MenuVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<MenuMenuItem> MenuMenuItems { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public int MenuId { get; set; }
        public string[] MenuItems { get; set; }

        public class CreateMenuViewModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Menu name is required")]
            [Display(Name = "Menu Name:")]
            public string Name { get; set; }

            public DateTime CreatedAt { get; set; }

            [Required(ErrorMessage = "Image is required")]
            [Display(Name = "Image")]
            public IFormFile Image { get; set; }

            [Required(ErrorMessage = "Image is required")]
            [Display(Name = "Description")]
            public string Description { get; set; }

            public string[] MenuItems { get; set; }
        }

        public class UpdateMenuViewModel
        {
            public int Id { get; set; }

            public DateTime CreatedAt { get; set; }

            [Display(Name = "Menu Name:")]
            public string Name { get; set; }

            [Display(Description = "Image:")]
            public string Image { get; set; }
        }
    }
}
