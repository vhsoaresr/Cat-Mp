using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Catalogo.Models;
using Catalogo.Services;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Core.ViewModels
{
    public class CatalogoViewModel : BaseViewModel
    {
        public CatalogoViewModel(IDataService dataservice) : base(dataservice)
        {
            dataservice.LoadProdutos(OnSucesso, OnErro);         
        }

        public ObservableCollection<Produto> AllProdutos;
        private ObservableCollection<Produto> _produtos;
        public ObservableCollection<Produto> Produtos
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                RaisePropertyChanged(() => Produtos);
            }
        }

        public virtual ICommand ItemSelected
        {
            get
            {
                return new MvxCommand<Produto>(produto => {
                    ShowViewModel<DetalhamentoViewModel>(produto);
                });
            }
        }

        private void OnSucesso(List<Produto> list)
        {
            Produtos = new ObservableCollection<Produto>(list.Select(produto =>
            {
                produto.IsFavoriteChanged = new MvxCommand(() =>
                {
                    DataService.Save(produto);
                });
                return produto;
            }));

            AllProdutos = Produtos;
        }
        private void OnErro(Exception obj)
        {
        }

    }
}