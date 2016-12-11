﻿using System.Threading.Tasks;

namespace Catalogo.Services
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, object obj);
    }
}