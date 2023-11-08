using Bogus;
using FakeDateGen.Models;

namespace FakeDateGen.Service
{
    public class FakeDataService : IFakeDataService
    {
        public List<List<Product>> GetFakeProductList()
        {
            try
            {
                var faker = new Faker<Product>();
                faker.RuleFor(p => p.Code, f => f.Commerce.Ean13());
                faker.RuleFor(p => p.Description, f => f.Commerce.ProductName());
                faker.RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0]);
                faker.RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000));

                var products = faker.Generate(1_000_000);

                var batches = products
                .Select((p, i) => (Product: p, Index: i))
                .GroupBy(x => x.Index / 100_000)
                .Select(g => g.Select(x => x.Product).ToList())
                .ToList();

                return batches;
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}