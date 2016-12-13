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
            IsRefreshing = true;
            DataService.LoadProdutos(OnSucesso, OnErro);         
        }
        public override void Start()
        {
            DataService.LoadProdutos(OnSucesso, OnErro);
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

        public ICommand ItemSelected
        {
            get
            {
                return new MvxCommand<Produto>(produto =>
                {
                    ShowViewModel<DetalhamentoViewModel>(produto);
                });
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(() => IsRefreshing);
            }
        }
        public ICommand ReloadCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    IsRefreshing = true;
                    DataService.ReloadProdutos(OnSucesso, OnErro, AllProdutos);
                });
            }
        }

        private void OnSucesso(ObservableCollection<Produto> list)
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
            IsRefreshing = false;
        }
        private void OnErro(Exception obj)
        {
        }

    }
}