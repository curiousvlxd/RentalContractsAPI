using System;
using System.Collections.Generic;

namespace RentalContractsAPI.Models;

public partial class EquipmentPlacementContract
{
    public int ContractId { get; set; }

    public int ProductionPremisesCode { get; set; }

    public int TechnologyEquipmentTypeCode { get; set; }

    public int NumOfUnits { get; set; }
}
