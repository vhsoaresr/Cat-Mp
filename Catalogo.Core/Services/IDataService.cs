using System;
using System.Collections.Generic;
using Catalogo.Models;

namespace Catalogo.Services
{
    public interface IDataService
    {
        void Save(Produto produto);
        void LoadProdutos(Action<List<Produto>> sucesso, Action<Exception> erro);

        void LoadCategorias(Action<List<Categoria>> sucesso, Action<Exception> erro);
    }

}