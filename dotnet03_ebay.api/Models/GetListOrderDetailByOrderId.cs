using System;
using System.Collections.Generic;

namespace dotnet03_ebay.api.Models;

public partial class GetListOrderDetailByOrderId
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? OrderDetail { get; set; }
}
