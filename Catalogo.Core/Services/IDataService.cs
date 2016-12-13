using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Catalogo.Models;

namespace Catalogo.Services
{
    public interface IDataService
    {
        void Save(Produto produto);
        void LoadProdutos(Action<ObservableCollection<Produto>> sucesso, Action<Exception> erro);
        void ReloadProdutos(Action<ObservableCollection<Produto>> sucesso, Action<Exception> erro, ObservableCollection<Produto> produtos);

        void LoadCategorias(Action<ObservableCollection<Categoria>> sucesso, Action<Exception> erro);
    }

}