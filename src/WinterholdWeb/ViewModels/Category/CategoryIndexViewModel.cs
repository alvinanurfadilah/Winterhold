﻿using System.ComponentModel.DataAnnotations;

namespace WinterholdWeb.ViewModels.Category;

public class CategoryIndexViewModel
{
    public List<CategoryViewModel> Categories { get; set; }
    public PaginationViewModel Pagination { get; set; }

    public string Name { get; set; }
    
}