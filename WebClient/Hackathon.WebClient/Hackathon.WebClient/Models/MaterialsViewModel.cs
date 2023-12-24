using Hackathon.DTO.Materials;
using Hackathon.Entities.Concrete;

namespace Hackathon.WebClient.Models
{
    public class MaterialsViewModel
    {
        public IEnumerable<SessionMaterialCreateDto> Materials { get; set; }
    }
}
