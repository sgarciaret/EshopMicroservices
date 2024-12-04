namespace CatalogAPI.Products.GetProductById
{
    public record GetProducttByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIQuerydHandler(IDocumentSession session) : IQueryHandler<GetProducttByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProducttByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(query.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
