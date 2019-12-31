using WeChat.IReponsitory;
using WeChat.IServices;
using WeChat.Models;

namespace WeChat.Services
{
    public class FamilyService : IFamilyService
    {
        public IFamilyReponsitory FamilyReponsitory { get; set; }
        public BaseFamily GetFamily(string familyCode, string familyName)
        {
            BaseFamily family = FamilyReponsitory.GetSingleWhere(a => a.FamilyCode == familyCode && a.FamilyName == familyName);
            return family;
        }

        public bool Bind(BaseFamily model)
        {
            FamilyReponsitory.BatchUpdate(a => a.OpenId == model.OpenId, a => new BaseFamily { OpenId = null });
            return FamilyReponsitory.Edit(model);
        }
    }
}
