namespace Shop
{
    public class ProductSoldEvent : IDomainEvent
    {
        private readonly User _customer;
        private readonly Product _product;

        public ProductSoldEvent(User customer, Product product)
        {
            _customer = customer;
            _product = product;
        }

        public string GetEventMessage()
        {
            return $"Your product has been bought by {_customer.Name}. Details: {_product}. Product must be shipped with {_product.ShipmentMethod} method.";
        }
    }
}