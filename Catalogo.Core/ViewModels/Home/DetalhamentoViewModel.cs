using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Catalogo.Models;
using Catalogo.Services;
using MvvmCross.Core.ViewModels;

namespace Catalogo.Core.ViewModels
{
	public class DetalhamentoViewModel : BaseViewModel
    {
        public DetalhamentoViewModel(IDataService dataservice) : base(dataservice)
        {

        }

        public void Init(Produto produto)
        {
            _produto = produto;
        }

        private Produto _produto;
        public string Name
        {
            get { return _produto.Name; }
            set
            {
                _produto.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }
        public string Description
        {
            get { return _produto.Description; }
            set
            {
                _produto.Description = value;
                RaisePropertyChanged(() => Description);
            }
        }
        public string Photo
        {
            get { return _produto.Photo; }
            set
            {
                _produto.Photo = value;
                RaisePropertyChanged(() => Photo);
            }
        }
        public float Price
        {
            get { return _produto.Price; }
            set
            {
                _produto.Price = value;
                RaisePropertyChanged(() => Price);
            }
        }
        public int? CategoryId
        {
            get { return _produto.CategoryId; }
            set
            {
                _produto.CategoryId = value;
                RaisePropertyChanged(() => CategoryId);
            }
        }
        public bool IsFavorite
        {
            get { return _produto.IsFavorite; }
            set
            {
                _produto.IsFavorite = value;
                RaisePropertyChanged(() => IsFavorite);
            }
        }
        public MvxCommand IsFavoriteChanged
        {
            get
            {
                return new MvxCommand(() =>
                {
                    DataService.Save(_produto);
                });
            }
        }

    }
}