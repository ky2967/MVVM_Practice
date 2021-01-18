using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Test.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region > 생성자
        public MainViewModel()
        {
            Number = 0;
        }

        #endregion

        #region > PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        #region > Data Binding
        private int iNumber;

        public int Number
        {
            get
            {
                return iNumber;
            }
            set
            {
                if(value < 0 || value > 10)
                {
                    MessageBox.Show("올바르지 않은 숫자입니다.");
                    return;
                }

                iNumber = value;
                OnPropertyChanged("Number");

                MainText = value.ToString();

                OnPropertyChanged("PlusEnable");
                OnPropertyChanged("MinusEnable");
            }
        }

        public bool PlusEnable
        {
            get
            {
                return Number >= 10 ? false : true;
            }
        }

        public bool MinusEnable
        {
            get
            {
                return Number < 1 ? false : true;
            }
        }

        private string sMainText;

        public string MainText
        {
            get
            {
                return sMainText;
            }
            set
            {
                sMainText = $"선택된 숫자는 {value}입니다.";
                OnPropertyChanged("MainText");
            }
        }
        #endregion

        #region > Command
        private ICommand minusCommand;

        public ICommand MinusCommand
        {
            get
            {
                return minusCommand ?? (minusCommand = new DelegateCommand(Minus));
            }
        }

        private ICommand plusCommand;

        public ICommand PlusCommand
        {
            get
            {
                return plusCommand ?? (plusCommand = new DelegateCommand(Plus));
            }
        }

        #endregion

        #region > Method
        private void Minus()
        {
            Number--;
        }

        private void Plus()
        {
            Number++;
        }
        #endregion
    }
}
