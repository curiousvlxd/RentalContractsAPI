using System;
using System.Collections.Generic;

namespace RentalContractsAPI.Models;

public partial class TechnologyEquipmentType
{
    public int Code { get; set; }

    public string? Name { get; set; }

    public decimal Area { get; set; }
}
