using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.HTTPClientDemo.Model
{
    public class ContextModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public string Context { get; set; }
    }
}
