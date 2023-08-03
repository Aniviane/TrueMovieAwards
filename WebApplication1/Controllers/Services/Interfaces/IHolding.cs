using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers.Services.Interfaces
{
    public interface IHolding
    {
        public HoldingDTO AddHolding(HoldingDTO Holding);

        public List<HoldingDTO> GetHoldings();

        public HoldingDTO GetHolding(long id);

        public HoldingDTO UpdateHolding(HoldingDTO Holding);

        public void DeleteHolding(long id);

    }
}
