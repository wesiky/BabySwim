using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Models;

namespace WeChat.IServices
{
    public interface IFamilyService
    {
        BaseFamily GetFamily(string familyCode, string familyName);

        bool Bind(BaseFamily model);
    }
}
