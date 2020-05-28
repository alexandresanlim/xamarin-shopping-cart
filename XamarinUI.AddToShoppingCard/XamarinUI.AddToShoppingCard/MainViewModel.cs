using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUI.AddToShoppingCard.Extention;
using XamarinUI.AddToShoppingCard.Models;
using XamarinUI.AddToShoppingCard.Models.Base;

namespace XamarinUI.AddToShoppingCard
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ResetProps();

            LoadData();
        }

        private void ResetProps()
        {
            CurrentParentItem = new Item();
            CurrentMountItem = new List<Item>();
            CurrentShoppingCartVM = CurrentShoppingCartVM ?? new CurrentShoppingCartViewModel();
            ResetSubItens();
        }

        private void ResetSubItens()
        {
            PhaseCount = 0;

            PhaseMore = 0;

            SubItens = new ObservableCollection<Item>();

            ConfirmSubItensButtonVisible = false;

            if (CurrentParent?.ChildList?.Count > 0)
            {
                CurrentParent.ChildList
                    .SelectMany(x => x.SubItens)
                    .Where(x => x.Quantity > 0)
                    .Select(x =>
                    {
                        x.Quantity = 0;
                        return x;
                    }).ToList();
            }
        }

        private void LoadData()
        {
            CurrentParent = new Parent
            {
                Title = "Los Pollos Hermanos",
                ImageUri = "https://images-na.ssl-images-amazon.com/images/I/9169R9h4ASL._AC_SX450_.jpg",
                ChildList = new List<Item>
                {
                    new Item
                    {
                        Title = "Pizza Big",
                        Price = 50,
                        ImageUri = "https://images.unsplash.com/photo-1590083745251-4fdb0b285c6a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                    }.AddSubItens(new List<Item>
                    {
                        new Item
                        {
                            Title = "Flavor 1",
                            Description = "Mussum Ipsum, cacilds vidis litro abertis. Sapien in monti palavris qui num significa nadis i pareci latim. Nullam volutpat risus nec leo commodo, ut interdum diam laoreet. Sed non consequat odio. Nec orci ornare consequat. Praesent lacinia ultrices consectetur. Sed non ipsum felis. Cevadis im ampola pa arma uma pindureta.",
                            ImageUri = "https://images.unsplash.com/photo-1527133256227-fc3549f55332?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                        },
                        new Item
                        {
                            Title = "Falavor 2",
                            Description = "Mussum Ipsum, cacilds vidis litro abertis. Sapien in monti palavris qui num significa nadis i pareci latim. Nullam volutpat risus nec leo commodo, ut interdum diam laoreet. Sed non consequat odio. Nec orci ornare consequat. Praesent lacinia ultrices consectetur. Sed non ipsum felis. Cevadis im ampola pa arma uma pindureta.",
                            ImageUri = "https://images.unsplash.com/photo-1590083745251-4fdb0b285c6a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                        },
                        new Item
                        {
                            Title = "Flavor 3",
                            Description = "Mussum Ipsum, cacilds vidis litro abertis. Sapien in monti palavris qui num significa nadis i pareci latim. Nullam volutpat risus nec leo commodo, ut interdum diam laoreet. Sed non consequat odio. Nec orci ornare consequat. Praesent lacinia ultrices consectetur. Sed non ipsum felis. Cevadis im ampola pa arma uma pindureta.",
                            ImageUri = "https://images.unsplash.com/photo-1585238342024-78d387f4a707?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                        }
                    }, 3),
                    new Item
                    {
                        Title = "Salad Burger",
                        Description = "Mussum Ipsum, cacilds vidis litro abertis. Leite de capivaris, leite de mula manquis sem cabeça. Si u mundo tá muito paradis? Toma um mé que o mundo vai girarzis! Posuere libero varius. Nullam a nisl ut ante blandit hendrerit. Aenean sit amet nisi. Quem num gosta di mé, boa gentis num é.",
                        Price = 10,
                        ImageUri = "https://images.unsplash.com/photo-1586190848861-99aa4a171e90?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                    },
                    new Item
                    {
                        Title = "Beef Burger",
                        Description = "Mussum Ipsum, cacilds vidis litro abertis. Mé faiz elementum girarzis, nisi eros vermeio. Suco de cevadiss deixa as pessoas mais interessantis. Admodum accumsan disputationi eu sit. Vide electram sadipscing et per. Atirei o pau no gatis, per gatis num morreus.",
                        Price = 15,
                        ImageUri = "https://images.unsplash.com/photo-1551360021-0ff7982d13dc?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                    },
                    new Item
                    {
                        Title = "Fries",
                        Price = 3,
                        ImageUri = "https://images.unsplash.com/photo-1579047288156-bdc39e1b39e8?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                    },
                    new Item
                    {
                        Title = "Soda",
                        Price = 3,
                        ImageUri = "https://images.unsplash.com/photo-1570900652780-31674a93b68d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                    },
                    new Item
                    {
                        Title = "Juice",
                        Price = 3,
                        ImageUri = "https://images.unsplash.com/photo-1585600270404-543d0eac85e1?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                    }
                }
            };

            ChildListItems = CurrentParent?.ChildList.ToObservableCollection();
        }



        #region Commands

        public Command ResetSubItensCommand => new Command(() =>
        {
            ResetSubItens();
        });

        public Command<Item> SetChildCommand => new Command<Item>((item) =>
        {
            if (item.HasSubItens)
            {
                if (item.RequiredSubItensCount > 0)
                {
                    CurrentParentItem = item;
                    PhaseCount = item.RequiredSubItensCount;
                }

                SubItens = item.SubItens.ToObservableCollection();
                return;
            }




            CurrentShoppingCartVM.AddItemInCurrentCart(item);

            //ReloadTotal();
        });

        public Command<Item> AddQuantityCommand => new Command<Item>((item) =>
        {
            if (ConfirmSubItensButtonVisible && item.IsSubItem)
                return;

            item.Quantity++;
            item.PriceByQuantityPresentation = (item.Quantity * item.Price).ToString("C");

            if (CurrentMountItem.Contains(item))
                CurrentMountItem.Remove(item);

            CurrentMountItem.Add(item);

            PhaseMore = CurrentParentItem.SubItens.Sum(x => x.Quantity);

            if (PhaseMore >= PhaseCount)
                ConfirmSubItensButtonVisible = true;

            CurrentShoppingCartVM.ReloadTotal();
        });

        public Command<Item> RmQuantityCommand => new Command<Item>((item) =>
        {
            if (item.Quantity.Equals(0))
                return;

            item.Quantity--;
            item.PriceByQuantityPresentation = (item.Quantity * item.Price).ToString("C");

            CurrentMountItem.Remove(item);

            PhaseMore = CurrentParentItem.SubItens.Sum(x => x.Quantity);

            ConfirmSubItensButtonVisible = false;

            CurrentShoppingCartVM.ReloadTotal();
        });

        public Command ConfirmSubitensCommand => new Command(() =>
        {
            CurrentShoppingCartVM.AddItemInCurrentCart(CurrentMountItem.MountByList());

            ResetSubItens();
        });


      


        #endregion

        public List<Item> CurrentMountItem { get; set; } = new List<Item>();

        private ObservableCollection<Item> _childListItems;
        public ObservableCollection<Item> ChildListItems
        {
            set { SetProperty(ref _childListItems, value); }
            get { return _childListItems; }
        }

        private ObservableCollection<Item> _subItens;
        public ObservableCollection<Item> SubItens
        {
            set { SetProperty(ref _subItens, value); }
            get { return _subItens; }
        }



        private int _phaseCount;
        public int PhaseCount
        {
            set { SetProperty(ref _phaseCount, value); }
            get { return _phaseCount; }
        }

        private int _phaseMore;
        public int PhaseMore
        {
            set { SetProperty(ref _phaseMore, value); }
            get { return _phaseMore; }
        }

        private bool _confirmSubItensButtonVisible;
        public bool ConfirmSubItensButtonVisible
        {
            set { SetProperty(ref _confirmSubItensButtonVisible, value); }
            get { return _confirmSubItensButtonVisible; }
        }

        //private RequireSubItensPresentaion _curentPhase;
        //public RequireSubItensPresentaion CurentPhase
        //{
        //    set { SetProperty(ref _curentPhase, value); }
        //    get { return _curentPhase; }
        //}

        public Item SelectedItem { get; set; }

        public Item CurrentParentItem { get; set; }

        public Parent CurrentParent { get; set; }
    }

    //public class RequireSubItensPresentaion : NotifyObjectBase
    //{
    //    private string _to;
    //    public string To
    //    {
    //        set { SetProperty(ref _to, value); }
    //        get { return _to; }
    //    }

    //    private int _phaseCount;
    //    public int PhaseCount
    //    {
    //        set { SetProperty(ref _phaseCount, value); }
    //        get { return _phaseCount; }
    //    }

    //    private int _phaseMore;
    //    public int PhaseMore
    //    {
    //        set { SetProperty(ref _phaseMore, value); }
    //        get { return _phaseMore; }
    //    }
    //    private int _phaseLess;
    //    public int PhaseLess
    //    {
    //        set { SetProperty(ref _phaseLess, value); }
    //        get { return _phaseLess; }
    //    }
    //}
}
