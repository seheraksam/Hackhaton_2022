using Hackathon.DTO.Materials;
using Hackathon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.BLL.Service
{
    public interface IRecyclerService
    {
        void AddRecyclerItems(IEnumerable<SessionMaterialCreateDto> materials, string userId);
        int CalculateTotalValue(IEnumerable<SessionMaterialCreateDto> materials);
    }
}
