using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using KoffieMachineDomain.Drinks;
using KoffieMachineDomain.Drinks.Decorators;
using KoffieMachineDomain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Dpint_wk456_KoffieMachine.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private BaseDrink _selectedDrink;

        private BalanceFactory _balanceFactory;

        public ObservableCollection<string> LogText { get; private set; }
        public ObservableCollection<string> PaymentCardUsernames { get; set; }

        public ObservableCollection<string> TeaNames { get; set; }
        public string SelectedTeaName { get; set; }

        public MainViewModel()
        {
            _drinkFactory = new DrinkFactory();

            // Init values
            _coffeeStrength = ContainmentLevel.Normal;
            _sugarAmount = ContainmentLevel.Normal;
            _milkAmount = ContainmentLevel.Normal;

            //Log
            LogText = new ObservableCollection<string>();
            LogText.Add("Starting up...");
            LogText.Add("Done, what would you like to drink?");

            //Payment
            _balanceFactory = new BalanceFactory();
            PaymentCardUsernames = new ObservableCollection<string>(_balanceFactory.Users);
            SelectedPaymentCardUsername = PaymentCardUsernames[0];

            //Tea
            TeaNames = new ObservableCollection<string>(_drinkFactory.BlendRepo.BlendNames);
            SelectedTeaName = TeaNames[0];

        }

        #region Drink properties to bind to
        public string SelectedDrinkName
        {
            get { return _selectedDrink?.Name; }
        }

        public double? SelectedDrinkPrice
        {
            get { return _selectedDrink?.GetPrice(); }
        }
        #endregion Drink properties to bind to

        #region Payment
        public double PaymentCardRemainingAmount => _balanceFactory.GetBalance(SelectedPaymentCardUsername);

        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            PayByCard();
        });

        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            PayByCoin(coinValue);
        });

        private void PayByCard()
        {
            if (_selectedDrink == null)
                return;

            double insertedMoney = PaymentCardRemainingAmount;
            if (RemainingPriceToPay <= insertedMoney) // All payed with card
            {
                _balanceFactory.UpdateBalance(SelectedPaymentCardUsername, insertedMoney - RemainingPriceToPay);
                RemainingPriceToPay = 0;
            }
            else
            {
                _balanceFactory.UpdateBalance(SelectedPaymentCardUsername, 0);
                RemainingPriceToPay -= insertedMoney;
            }
            RaisePropertyChanged(() => PaymentCardRemainingAmount);
            LogText.Add($"Inserted €{insertedMoney.ToString()}, Remaining: €{RemainingPriceToPay.ToString()}.");

            if (RemainingPriceToPay == 0)
                CreateDrink();
        }

        private void PayByCoin(double insertedMoney)
        {
            if (_selectedDrink == null)
                return;
            RemainingPriceToPay = Math.Max(Math.Round(RemainingPriceToPay - insertedMoney, 2), 0);
            LogText.Add($"Inserted €{insertedMoney.ToString()}, Remaining: €{RemainingPriceToPay.ToString()}.");

            if (RemainingPriceToPay == 0)
                CreateDrink();
        }

        private string _selectedPaymentCardUsername;
        public string SelectedPaymentCardUsername
        {
            get { return _selectedPaymentCardUsername; }
            set
            {
                _selectedPaymentCardUsername = value;
                RaisePropertyChanged(() => SelectedPaymentCardUsername);
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
        }
        private void CreateDrink()
        {
            _selectedDrink.LogDrinkMaking(LogText);
            LogText.Add($"Finished making {_selectedDrink.Name}");
            LogText.Add("------------------");
            _selectedDrink = null;
        }
        #endregion Payment

        #region Coffee buttons

        private DrinkFactory _drinkFactory;
        
        private ContainmentLevel _coffeeStrength;
        public ContainmentLevel CoffeeStrength
        {
            get { return _coffeeStrength; }
            set { _coffeeStrength = value; RaisePropertyChanged(() => CoffeeStrength); }
        }

        private ContainmentLevel _sugarAmount;
        public ContainmentLevel SugarAmount
        {
            get { return _sugarAmount; }
            set { _sugarAmount = value; RaisePropertyChanged(() => SugarAmount); }
        }

        private ContainmentLevel _milkAmount;
        public ContainmentLevel MilkAmount
        {
            get { return _milkAmount; }
            set { _milkAmount = value; RaisePropertyChanged(() => MilkAmount); }
        }

        public ICommand DrinkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(drinkName, _coffeeStrength, ContainmentLevel.None, ContainmentLevel.None);
            UpdateDrinkInfo(false, false);
        });

        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(drinkName, _coffeeStrength, ContainmentLevel.None, _sugarAmount);
            UpdateDrinkInfo(true, false);
        });

        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(drinkName, _coffeeStrength, _milkAmount, ContainmentLevel.None);
            UpdateDrinkInfo(false, true);
        });

        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(drinkName, _coffeeStrength, _milkAmount, _sugarAmount);
            UpdateDrinkInfo(true, true);
        });

        public ICommand TeaCommand =>new RelayCommand(()=>
        {
            _selectedDrink = _drinkFactory.CreateDrink(SelectedTeaName, ContainmentLevel.None, ContainmentLevel.None, ContainmentLevel.None);
            UpdateDrinkInfo(false, false);
        });

        public ICommand TeaWithSugarCommand => new RelayCommand(() =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(SelectedTeaName, ContainmentLevel.None, _sugarAmount, ContainmentLevel.None);
            UpdateDrinkInfo(true, false);
        });

        private void UpdateDrinkInfo(bool hasSugar, bool hasMilk)
        {
            if (_selectedDrink != null)
            {
                if (hasSugar)
                {
                    if (hasMilk)
                    {
                        RemainingPriceToPay = _selectedDrink.GetPrice() + SugarDrinkDecorator.SUGAR_PRICE + MilkDrinkDecorator.MILK_PRICE;
                        LogText.Add($"Selected {_selectedDrink.Name} with sugar and milk, price: €{RemainingPriceToPay}");
                    }
                    else
                    {
                        RemainingPriceToPay = _selectedDrink.GetPrice() + SugarDrinkDecorator.SUGAR_PRICE;
                        LogText.Add($"Selected {_selectedDrink.Name} with sugar, price: €{RemainingPriceToPay}");
                    }
                }
                else if (hasMilk)
                {
                    RemainingPriceToPay = _selectedDrink.GetPrice() + MilkDrinkDecorator.MILK_PRICE;
                    LogText.Add($"Selected {_selectedDrink.Name} with milk, price: €{RemainingPriceToPay}");
                }
                else
                {
                    RemainingPriceToPay = _selectedDrink.GetPrice();
                    LogText.Add($"Selected {_selectedDrink.Name}, price: €{RemainingPriceToPay}");
                }
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        }

        #endregion Coffee buttons
    }
}