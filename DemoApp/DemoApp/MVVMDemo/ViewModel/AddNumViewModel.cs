using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoApp.MVVMDemo.ViewModel
{
    public class AddNumViewModel : INotifyPropertyChanged
    {
        //定义属性值
        double num1, num2, num3,numSun;
        public event PropertyChangedEventHandler PropertyChanged;
        //定义清空的命令
        public ICommand CleanCommand { protected set; get; }

        public AddNumViewModel()
        {
            //实现清空
            this.CleanCommand = new Command<string>((key) =>
            {
                this.NumSun = 0;
                this.Num1 = 0;
                this.Num2 = 0;
                this.Num3 = 0;
            });

        }

        /// <summary>
        /// 统一的属性变更事件判断方法
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void  OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        public double Num1
        {
            set
            {
                if (num1 != value)
                {
                    num1 = value;
                    OnPropertyChanged("Num1");
                    SetNewSunNum();
                }
            }
            get
            {
                return num1;
            }
        }

        public double Num2
        {
            set
            {
                if (num2 != value)
                {
                    num2 = value;
                    OnPropertyChanged("Num2");
                    SetNewSunNum();
                }
            }
            get
            {
                return num2;
            }
        }

        public double Num3
        {
            set
            {
                if (num3 != value)
                {
                    num3 = value;
                    OnPropertyChanged("Num3");
                    SetNewSunNum();
                }
            }
            get
            {
                return num3;
            }
        }

        public double NumSun
        {
            set
            {
                if (numSun != value)
                {
                    numSun = value;
                    OnPropertyChanged("NumSun");
                   
                }
            }
            get
            {
                return numSun;
            }
        }

        /// <summary>
        /// 把数值加起来的方法(业务逻辑)
        /// </summary>
        void SetNewSunNum()
        {
            this.NumSun = this.Num1 + this.Num2 + this.Num3;
        }



    }
}
