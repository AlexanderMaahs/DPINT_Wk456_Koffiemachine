using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoffieMachineDomain;
using KoffieMachineDomain.Drinks;
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
            //_selectedDrink = null;
            //switch (drinkName)
            //{
            //    case "Coffee":
            //        _selectedDrink = new CoffeeDrink() { DrinkStrength = CoffeeStrength };
            //        break;
            //    case "Espresso":
            //        _selectedDrink = new EspressoDrink();
            //        break;
            //    case "Capuccino":
            //        _selectedDrink = new CapuccinoDrink();
            //        break;
            //    case "Wiener Melange":
            //        _selectedDrink = new WienerMelangeDrink();
            //        break;
            //    case "Caf� au Lait":
            //        _selectedDrink = new CafeAuLaitDrink();
            //        break;
            //    default:
            //        LogText.Add($"Could not make {drinkName}, recipe not found.");
            //        break;
            //}
            UpdateCoffeeInfo();
        });

        public ICommand DrinkWithSugarCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(drinkName, _coffeeStrength, ContainmentLevel.None, _sugarAmount);
            //_selectedDrink = null;
            //RemainingPriceToPay = 0;
            //switch (drinkName)
            //{
            //    case "Coffee":
            //        _selectedDrink = new CoffeeDrink() { DrinkStrength = CoffeeStrength, HasSugar = true, SugarAmount = SugarAmount };
            //        break;
            //    case "Espresso":
            //        _selectedDrink = new EspressoDrink() { HasSugar = true, SugarAmount = SugarAmount };
            //        break;
            //    case "Capuccino":
            //        _selectedDrink = new CapuccinoDrink() { HasSugar = true, SugarAmount = SugarAmount };
            //        break;
            //    case "Wiener Melange":
            //        _selectedDrink = new WienerMelangeDrink() { HasSugar = true, SugarAmount = SugarAmount };
            //        break;
            //    default:
            //        LogText.Add($"Could not make {drinkName} with sugar, recipe not found.");
            //        break;
            //}
            UpdateCoffeeInfo();
        });

        public ICommand DrinkWithMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(drinkName, _coffeeStrength, _milkAmount, ContainmentLevel.None);

            //switch (drinkName)
            //{
            //    case "Coffee":
            //        _selectedDrink = new CoffeeDrink() { DrinkStrength = CoffeeStrength, HasMilk = true, MilkAmount = MilkAmount };
            //        break;
            //    case "Espresso":
            //        _selectedDrink = new EspressoDrink() { HasMilk = true, MilkAmount = MilkAmount };
            //        break;
            //    default:
            //        LogText.Add($"Could not make {drinkName} with milk, recipe not found.");
            //        break;
            //}
            UpdateCoffeeInfo();
        });

        public ICommand DrinkWithSugarAndMilkCommand => new RelayCommand<string>((drinkName) =>
        {
            _selectedDrink = _drinkFactory.CreateDrink(drinkName, _coffeeStrength, _milkAmount, _sugarAmount);

            //_selectedDrink = null;
            //RemainingPriceToPay = 0;
            //switch (drinkName)
            //{
            //    case "Coffee":
            //        _selectedDrink = new CoffeeDrink() { DrinkStrength = CoffeeStrength, HasSugar = true, SugarAmount = SugarAmount, HasMilk = true, MilkAmount = MilkAmount };
            //        break;
            //    case "Espresso":
            //        _selectedDrink = new EspressoDrink() { HasSugar = true, SugarAmount = SugarAmount, HasMilk = true, MilkAmount = MilkAmount };
            //        break;
            //    default:
            //        LogText.Add($"Could not make {drinkName} with milk, recipe not found.");
            //        break;
            //}
            UpdateCoffeeInfo();
        });

        private void UpdateCoffeeInfo()
        {
            if (_selectedDrink != null)
            {
                RemainingPriceToPay = _selectedDrink.GetPrice() + Drink.SugarPrice + Drink.MilkPrice;
                LogText.Add($"Selected {_selectedDrink.Name} with sugar and milk, price: {RemainingPriceToPay}");
                RaisePropertyChanged(() => RemainingPriceToPay);
                RaisePropertyChanged(() => SelectedDrinkName);
                RaisePropertyChanged(() => SelectedDrinkPrice);
            }
        }

        #endregion Coffee buttons
    }
}