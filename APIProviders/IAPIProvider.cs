using NowMineCommon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NowMine.APIProviders
{
    interface IAPIProvider
    {
        Task<List<ClipInfo>> GetSearchClipInfos(string keyWord);
    }
}
