using System;
using System.Collections.Generic;

namespace dotnet03_ebay.api.Models;

public partial class GetListingProductDetail
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Avatar { get; set; } = null!;

    public string? Address { get; set; }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal? CurrentPrice { get; set; }

    public decimal StartingPrice { get; set; }

    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string Email { get; set; } = null!;

    public int? GroupListing { get; set; }

    public string? ListImageDetail { get; set; }
}
