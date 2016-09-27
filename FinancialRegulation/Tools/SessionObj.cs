using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancialRegulation.Tools
{
    /// <summary>
    /// 模拟Session对象
    /// </summary>
    /// <typeparam name="T">存储对象类型</typeparam>
    public class SessionObj<T> : Dictionary<string, T> where T : new()
    {
        new public T this[string id]
        {
            get
            {
                T oo = default(T);
                base.TryGetValue(id, out oo);
                return oo;
            }
            set
            {
                T oo = default(T);
                if (base.TryGetValue(id, out oo))
                {
                    base[id] = value;
                }
                else
                {
                    this.Add(id, value);
                }
            }
        }
    }
}
