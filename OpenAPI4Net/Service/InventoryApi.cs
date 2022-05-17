
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 存货 API
    /// </summary>
    public class InventoryApi : BasicApi
    {
        public const string RESOURCE_ID = "inventory";

        public InventoryApi()
            : base(RESOURCE_ID) { }
    }
}
