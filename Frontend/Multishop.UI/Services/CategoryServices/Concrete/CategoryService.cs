﻿using Multishop.UI.Areas.Admin.Models.ViewModels.CategoryVMs;
using Multishop.UI.Models.ViewModels.CategoryVMs;
using Multishop.UI.Services.CategoryServices.Abstract;
using System.Net;

namespace Multishop.UI.Services.CategoryServices.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;
        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> AddAsync(CategoryAddVM categoryAddVM) =>
            (await httpClient.PostAsJsonAsync("category/add", categoryAddVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> DeleteAsync(string categoryId) =>
            (await httpClient.DeleteAsync($"category/delete/{categoryId}")).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<bool> UpdateAsync(CategoryUpdateVM categoryUpdateVM) =>
            (await httpClient.PutAsJsonAsync("category/update", categoryUpdateVM)).StatusCode is HttpStatusCode.OK ? true : false;

        public async Task<CategoryVM> GetFirstOrDefaultAsync(string categoryId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"category/getby/{categoryId}");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<CategoryVM>() : null;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var httpResponseMessage = await httpClient.GetAsync("category/categories");
            return httpResponseMessage.StatusCode is HttpStatusCode.OK ? await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<CategoryVM>>() : null;
        }
    }
}