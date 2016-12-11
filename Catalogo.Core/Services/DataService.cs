using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using Catalogo.Models;
using SQLite;
using System;

namespace Catalogo.Services
{
    public class DataService : IDataService
    {
        private readonly SQLiteConnection _connection;
        private readonly IHttpService _httpService;

        public DataService(IMvxSqliteConnectionFactory factory, IHttpService httpService)
        {
            _httpService = httpService;
            _connection = factory.GetConnection("data.dat");
            _connection.CreateTable<Produto>();
            _connection.CreateTable<Categoria>();
        }

        public void Save(Produto produto)
        {
            _connection.InsertOrReplace(produto);
        }
        public async void LoadProdutos(Action<List<Produto>> sucesso, Action<Exception> erro)
        {
            var produtos = _connection.Table<Produto>().ToList();
            try
            {
                if (produtos.Count <= 0)
                {
                    produtos = await _httpService.GetAsync<List<Produto>>("W7tdL7NU");
                    _connection.InsertAll(produtos);
                }
            }
            catch (Exception ex)
            {
                erro(ex);
            }
            finally
            {
                sucesso(produtos);
            }
        }

        public async void LoadCategorias(Action<List<Categoria>> sucesso, Action<Exception> erro)
        {
            var categorias = _connection.Table<Categoria>().ToList();
            try
            {
                if (categorias.Count <= 0)
                    categorias = await _httpService.GetAsync<List<Categoria>>("YNR2rsWe");
            }
            catch (Exception ex)
            {
                erro(ex);
            }
            finally
            {
                foreach (var categoria in categorias)
                    _connection.InsertOrReplace(categoria);

                sucesso(categorias);
            }
        }
    }
}
