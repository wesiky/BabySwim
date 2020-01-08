using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat
{
    public interface IConfigGeter
    {
        TConfig Get<TConfig>(string key);
        TConfig Get<TConfig>();
        String this[string key] { get; }
    }
}
