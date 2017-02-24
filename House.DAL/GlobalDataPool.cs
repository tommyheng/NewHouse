using FangChan.WPFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.DAL
{
    public class GlobalDataPool
    {
        private volatile static GlobalDataPool _instance = null;
        private static readonly object lockHelper = new object();
        private GlobalDataPool() { }
        public static GlobalDataPool CreateInstance(string path)
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        _instance = new GlobalDataPool();
                    }
                }
            }
            return _instance;
        }
        //用户ID
        public int Uid { get; set; }
        //用户登录数据（这里面有大量的数据,必要的时候可以单独拆出来存储）
        public LoginStateModel LoginData { get; set; }

    }
}
