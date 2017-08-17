using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.MVVMDemo.ViewModel
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        //定义一个时间类型
        DateTime dateTime;

        //实现接口的事件属性
        public event PropertyChangedEventHandler PropertyChanged;

        //创建构造函数,定义一个定时执行程序
        public TimeViewModel()
        {
            this.DateTime = DateTime.Now;

            //定义定时执行程序,1秒刷新一下时间属性
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }

        //定义时间属性,创建SetGet方法,在Set中使用PropertyChanged事件,来更新这个时间
        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }
    }
}
