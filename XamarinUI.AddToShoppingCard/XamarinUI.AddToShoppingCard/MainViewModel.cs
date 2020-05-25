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
            CurrentCart = new ShoppingCart();
            CurrentMountItem = new List<Item>();
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
                Title = "S.C.L.C. jobs-income text",
                ImageUri = "https://images.unsplash.com/photo-1564052513728-d88c2f9d29e7?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60",
                ChildList = new List<Item>
                {
                    new Item
                    {
                        Title = "Combo",
                        Price = 50,
                        ImageUri = "https://images.unsplash.com/photo-1529738097101-93c2129413ed?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                    }.AddSubItens(new List<Item>
                    {
                        new Item
                        {
                            Title = "Hamburguer Hamburguer Hamburguer Hamburguer",
                            Price = 50,
                            ImageUri = "https://images.unsplash.com/photo-1529738097101-93c2129413ed?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                        },
                        new Item
                        {
                            Title = "Refrigerante",
                            Price = 100,
                            ImageUri = "https://images.unsplash.com/photo-1571115637015-f572abdfc43e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                        },
                        new Item
                        {
                            Title = "Extra",
                            Price = 100,
                            ImageUri = "https://images.unsplash.com/photo-1571115637015-f572abdfc43e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                        }
                    }, 3),
                    new Item
                    {
                        Title = "Dunhill perfume bottle",
                        Price = 50,
                        ImageUri = "https://images.unsplash.com/photo-1521305916504-4a1121188589?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=80"
                    },
                    new Item
                    {
                        Title = "White plastic container",
                        Price = 100,
                        ImageUri = "https://images.unsplash.com/photo-1573333515743-56d57731dd1f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=80"
                    },
                    new Item
                    {
                        Title = "Black Sony Android smartphone with water drops",
                        Price = 300,
                        ImageUri = "https://images.unsplash.com/photo-1546039907-7fa05f864c02?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=80"
                    },
                    new Item
                    {
                        Title = "Gray bottle opener beside opened bottle",
                        Price = 300,
                        ImageUri = "https://images.unsplash.com/photo-1481931715705-36f5f79f1f3d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=527&q=80"
                    },
                    new Item
                    {
                        Title = "Yellow envelopes",
                        Price = 300,
                        ImageUri = "https://images.unsplash.com/photo-1559916712-ae4427996e1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=80"
                    }
                }
            };

            ChildListItems = CurrentParent?.ChildList.ToObservableCollection();
        }

        private void AddItemInCurrentCart(Item item)
        {
            item.Quantity++;
            item.PriceByQuantityPresentation = item.Price.ToString("C");

            if (CurrentCart?.Itens == null || CurrentCart.Itens.Count.Equals(0))
                CurrentCart.Itens = new ObservableCollection<Item>
                {
                    item
                };

            else
                CurrentCart.Itens.Add(item);

            ReloadTotal();
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

            if (CurrentCart.Itens != null && CurrentCart.Itens.Contains(item))
            {
                CurrentCart.Itens.FirstOrDefault(x => x == item).Quantity++;
                CurrentCart.Itens.FirstOrDefault(x => x == item).PriceByQuantityPresentation = (CurrentCart.Itens.FirstOrDefault(x => x == item).Quantity * item.Price).ToString("C");
                return;
            }

            AddItemInCurrentCart(item);

            ReloadTotal();
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

            ReloadTotal();
        });

        public Command<Item> RmQuantityCommand => new Command<Item>((item) =>
        {
            item.Quantity--;
            item.PriceByQuantityPresentation = (item.Quantity * item.Price).ToString("C");

            CurrentMountItem.Remove(item);

            PhaseMore = CurrentParentItem.SubItens.Sum(x => x.Quantity);

            ConfirmSubItensButtonVisible = false;

            ReloadTotal();
        });

        public Command ConfirmSubitensCommand => new Command(() =>
        {
            var a = CurrentMountItem.MountByList();

            AddItemInCurrentCart(a);


            ResetSubItens();

            //CurrentParentItem.Quantity++;
            //CurrentMountItem.Add(CurrentParentItem);

            //var itens = CurrentParent.ChildList.Where(x => x.Quantity > 0);

            //var customItem = new Item { Price = CurrentParent.pa}

            //ResetProps();

            //SubItens = new ObservableCollection<Item>();
        });

        public Command<Item> RemoveItemCommand => new Command<Item>((itemToRemove) =>
        {
            CurrentCart.Itens.Remove(itemToRemove);

            ReloadTotal();
        });

        private void ReloadTotal()
        {
            if (CurrentCart.Itens == null)
                return;

            CurrentCart.TotalPresentation = CurrentCart.Itens.Sum(x => x.PriceByQuantity).ToString("C");
        }

        public Command ResumeCartCommand => new Command(() =>
        {
            CurrentCart.ContentVisible = CurrentCart.ContentVisible ? false : true;
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

        private ShoppingCart _currentCart;
        public ShoppingCart CurrentCart
        {
            set { SetProperty(ref _currentCart, value); }
            get { return _currentCart; }
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
