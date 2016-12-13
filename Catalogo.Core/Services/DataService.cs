using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using Catalogo.Models;
using SQLite;
using System;
using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;

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
        public async void LoadProdutos(Action<ObservableCollection<Produto>> sucesso, Action<Exception> erro)
        {
            var produtos = new ObservableCollection<Produto>(_connection.Table<Produto>());
            try
            {
                if (produtos.Count <= 0)
                {
                    produtos = await _httpService.GetAsync<ObservableCollection<Produto>>("W7tdL7NU");
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

        public async void ReloadProdutos(Action<ObservableCollection<Produto>> sucesso, Action<Exception> erro, ObservableCollection<Produto> produtos)
        {
            try
            {
                var newProdutos = await _httpService.GetAsync<ObservableCollection<Produto>>("W7tdL7NU");

                for (var i = 0; i < newProdutos.Count; i++)
                    newProdutos[i].IsFavorite = produtos[i].IsFavorite;

                _connection.DeleteAll<Produto>();
                _connection.InsertAll(produtos);
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

        public async void LoadCategorias(Action<ObservableCollection<Categoria>> sucesso, Action<Exception> erro)
        {
            var categorias = new ObservableCollection<Categoria>(_connection.Table<Categoria>());
            try
            {
                if (categorias.Count <= 0)
                    categorias = await _httpService.GetAsync<ObservableCollection<Categoria>>("YNR2rsWe");
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
