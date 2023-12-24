using Hackathon.BLL.Service;
using Hackathon.DTO.Materials;
using Hackathon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.BLL.Manager
{
    public class RecyclerManager : IRecyclerService
    {
        private readonly ISessionService _sessionService;
        private readonly ITransactionService _transactionService;

        public RecyclerManager(ISessionService sessionService, ITransactionService transactionService)
        {
            _sessionService = sessionService;
            _transactionService = transactionService;
        }

        public void AddRecyclerItems(IEnumerable<SessionMaterialCreateDto> materials,string userId)
        {
            SessionRecord record = new SessionRecord()
            {
                CreateUserId = userId,
                UpdateUserId = userId,
            };
            record.SessionMaterials = materials.Select(material => new SessionMaterial()
            {
                MaterialId=material.Id,
                CreateUserId=userId,
                UpdateUserId=userId,
                Quantity =material.Count>0?material.Count:1

            }).ToList();
            _sessionService.AddSessionRecord(record, userId);
            var totalValueToAdd = CalculateTotalValue(materials);
            _transactionService.SystemTransaction(userId, totalValueToAdd);
        }

        public int CalculateTotalValue(IEnumerable<SessionMaterialCreateDto> materials)
        {
            return materials.Sum(x => x.Total);
        }
    }
}
