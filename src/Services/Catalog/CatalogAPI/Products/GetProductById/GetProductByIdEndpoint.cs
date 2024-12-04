﻿
using CatalogAPI.Products.CreateProduct;

namespace CatalogAPI.Products.GetProductById
{
    //public record GetProductByIdRequest();
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProducttByIdQuery(id));

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            }).WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product by Id")
            .WithDescription("Get Product by Id");
        }
    }
}
