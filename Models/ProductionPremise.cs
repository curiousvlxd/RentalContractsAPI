using System;
using System.Collections.Generic;

namespace RentalContractsAPI.Models;

public partial class ProductionPremise
{
    public int Code { get; set; }

    public string? Name { get; set; }

    public decimal RegulatoryArea { get; set; }
}
