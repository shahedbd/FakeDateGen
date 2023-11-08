using FakeDateGen.Models;

namespace FakeDateGen.Service
{
    public interface IFakeDataService
    {
        public List<List<Product>> GetFakeProductList();
    }
}