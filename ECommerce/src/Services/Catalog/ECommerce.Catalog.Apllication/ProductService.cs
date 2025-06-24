using ECommerce.Catalog.Apllication.Features.Products.Commands.CreateProduct;
using ECommerce.Catalog.Domain.Aggregates;

namespace ECommerce.Catalog.Apllication
{
    /*
     * Bu yöntem; sınırlı veya nadir diğişiklik durumunda kullanılabilir
     */
    public class ProductService
    {
        public void CreateNewProduct()
        {
            //CreateProductCommandHandler createProductCommandHandler = new CreateProductCommandHandler();
            //var respnse = createProductCommandHandler.Handle(new CreateProductCommandRequest("Falan", "Filan",0,0));
            //return respnse;
            //_mediator.Send(request)

        }

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>();
        }
        /*
         * 1. Eylemin (INSERT) gerçekleşeceği nesne. (HANDLER)
         * 2. Eylemin ihtiyaç duyduğu verileri taşıyan nesne. (Request)
         * 3. Eylem gerçekleştikten sonra olup biteni tutan nesne! (Response)
         */

    }
}
