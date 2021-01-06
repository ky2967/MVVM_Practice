using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                iNumber = value;
                OnPropertyChanged("Number");
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
