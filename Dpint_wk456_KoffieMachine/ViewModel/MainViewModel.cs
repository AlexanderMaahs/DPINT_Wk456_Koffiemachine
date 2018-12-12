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
        private BalanceFactory _balanceFactory;
        public ObservableCollection<string> LogText { get; private set; }

        public MainViewModel()
        {
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

            _drinkFactory = new DrinkFactory();
        }

        #region Drink properties to bind to
        private IDrink _selectedDrink;
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
        public RelayCommand PayByCardCommand => new RelayCommand(() =>
        {
            PayDrink(payWithCard: true);
        });

        public ICommand PayByCoinCommand => new RelayCommand<double>(coinValue =>
        {
            PayDrink(payWithCard: false, insertedMoney: coinValue);
        });

        private void PayDrink(bool payWithCard, double insertedMoney = 0)
        {
            if (_selectedDrink != null && payWithCard)
            {
                insertedMoney = _balanceFactory.GetBalance(SelectedPaymentCardUsername);
                if (RemainingPriceToPay <= insertedMoney)
                {
                    _balanceFactory.UpdateBalance(SelectedPaymentCardUsername, insertedMoney - RemainingPriceToPay);
                    RemainingPriceToPay = 0;
                }
                else // Pay what you can, fill up with coins later.
                {
                    _balanceFactory.UpdateBalance(SelectedPaymentCardUsername, 0);

                    RemainingPriceToPay -= insertedMoney;
                }
                LogText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");
                RaisePropertyChanged(() => PaymentCardRemainingAmount);
            }
            else if (_selectedDrink != null && !payWithCard)
            {
                RemainingPriceToPay = Math.Max(Math.Round(RemainingPriceToPay - insertedMoney, 2), 0);
                LogText.Add($"Inserted {insertedMoney.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {RemainingPriceToPay.ToString("C", CultureInfo.CurrentCulture)}.");
            }

            if (_selectedDrink != null && RemainingPriceToPay == 0)
            {
                _selectedDrink.LogDrinkMaking(LogText);
                LogText.Add("------------------");
                _selectedDrink = null;
            }
        }

        public double PaymentCardRemainingAmount => _balanceFactory.GetBalance(SelectedPaymentCardUsername);

        public ObservableCollection<string> PaymentCardUsernames { get; set; }
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

        private DrinkFactory _drinkFactory;
        private double _remainingPriceToPay;
        public double RemainingPriceToPay
        {
            get { return _remainingPriceToPay; }
            set { _remainingPriceToPay = value; RaisePropertyChanged(() => RemainingPriceToPay); }
        }
        #endregion Payment

        #region Coffee buttons
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

        private void UpdateDrinkInfo(bool hasSugar, bool hasMilk)
        {
            if (_selectedDrink != null)
            {
                if (hasSugar)
                {
                    if (hasMilk)
                    {
                        RemainingPriceToPay = _selectedDrink.GetPrice() + SugarDrinkDecorator.SUGAR_PRICE + MilkDrinkDecorator.MILK_PRICE;
                        LogText.Add($"Selected {_selectedDrink.Name} with sugar and milk, price: {RemainingPriceToPay}");
                    }
                    else
                    {
                        RemainingPriceToPay = _selectedDrink.GetPrice() + SugarDrinkDecorator.SUGAR_PRICE;
                        LogText.Add($"Selected {_selectedDrink.Name} with sugar, price: {RemainingPriceToPay}");
                    }
                } else if (hasMilk)
                {
                    RemainingPriceToPay = _selectedDrink.GetPrice() + MilkDrinkDecorator.MILK_PRICE;
                    LogText.Add($"Selected {_selectedDrink.Name} with milk, price: {RemainingPriceToPay}");
                }
                else
                {
                    RemainingPriceToPay = _selectedDrink.GetPrice();
                    LogText.Add($"Selected {_selectedDrink.Name}, price: {RemainingPriceToPay}");
                }
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        }

        #endregion Coffee buttons
    }
}