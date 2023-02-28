using Microsoft.EntityFrameworkCore;
using RentalContractsAPI.Context;
using RentalContractsAPI.Controllers;
using RentalContractsAPI.Models;

namespace RentalContractsAPI.Tests;

public class ControllerTests
{
    public static readonly RentalContractsContext _context;
    
    static ControllerTests()
    {
        var options = new DbContextOptionsBuilder<RentalContractsContext>()
            .UseInMemoryDatabase(databaseName: "RentalContracts")
            .Options;
        _context = new RentalContractsContext(options);
    }
    
    public class EquipmentPlacementContractControllerTests
    {
        [Fact]
        public void Get_EquipmentPlacementContract()
        {   
            var controller = new EquipmentPlacementContractController(_context);
            var result = controller.GetEquipmentPlacementContract(1);
            Assert.NotNull(result);        
        }
        
        [Fact]
        public void Get_EquipmentPlacementContracts()
        {
            var controller = new EquipmentPlacementContractController(_context);
            var result = controller.GetEquipmentPlacementContracts();
            Assert.NotNull(result);        
        }
        
        [Fact]
        public void Put_EquipmentPlacementContract()
        {
            var controller = new EquipmentPlacementContractController(_context);
            var result = controller.PutEquipmentPlacementContract(1, new EquipmentPlacementContract() { ProductionPremisesCode = 1, TechnologyEquipmentTypeCode = 1, NumOfUnits = 1});
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Post_EquipmentPlacementContract()
        {
            var controller = new EquipmentPlacementContractController(_context);
            var result = controller.PostEquipmentPlacementContract( 1, 1, 1 );
            Assert.NotNull(result);    
        }
        
        [Fact]
        public void Delete_EquipmentPlacementContract()
        {
            var controller = new EquipmentPlacementContractController(_context);
            var result = controller.DeleteEquipmentPlacementContract(1);
            Assert.NotNull(result);    
        }
    }

    public class ProductionPremiseControllerTests
    {
        [Fact]
        public void Get_ProductionPremise()
        {
            var controller = new ProductionPremiseController(_context);
            var result = controller.GetProductionPremise(1);
            Assert.NotNull(result);        
        }
        
        [Fact]
        public void Get_ProductionPremises()
        {
            var controller = new ProductionPremiseController(_context);
            var result = controller.GetProductionPremises();
            Assert.NotNull(result);        
        }
        
        [Fact]
        public void Put_ProductionPremise()
        {
            var controller = new ProductionPremiseController(_context);
            var result = controller.PutProductionPremise(1, new ProductionPremise() { Name = "Виробниче приміщення", RegulatoryArea = 999});
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Post_ProductionPremise()
        {
            var controller = new ProductionPremiseController(_context);
            var result = controller.PostProductionPremise( "Виробниче приміщення", 999 );
            Assert.NotNull(result);    
        }
        
        [Fact]
        public void Delete_ProductionPremise()
        {
            var controller = new ProductionPremiseController(_context);
            var result = controller.DeleteProductionPremise(1);
            Assert.NotNull(result);    
        }
    }
    
    public class TechnologyEquipmentTypeControllerTests
    {
        [Fact]
        public void Get_TechnologyEquipmentType()
        {
            var controller = new TechnologyEquipmentTypeController(_context);
            var result = controller.GetTechnologyEquipmentType(1);
            Assert.NotNull(result);        
        }
        
        [Fact]
        public void Get_TechnologyEquipmentTypes()
        {
            var controller = new TechnologyEquipmentTypeController(_context);
            var result = controller.GetTechnologyEquipmentTypes();
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Put_TechnologyEquipmentType()
        {
            var controller = new TechnologyEquipmentTypeController(_context);
            var result = controller.PutTechnologyEquipmentType(1, new TechnologyEquipmentType() { Name = "Технологічне обладнання", Area = 999});
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Post_TechnologyEquipmentType()
        {
            var controller = new TechnologyEquipmentTypeController(_context);
            var result = controller.PostTechnologyEquipmentType( "Технологічне обладнання", 999 );
            Assert.NotNull(result);    
        }
        
        [Fact]
        public void Delete_TechnologyEquipmentType()
        {
            var controller = new TechnologyEquipmentTypeController(_context);
            var result = controller.DeleteTechnologyEquipmentType(1);
            Assert.NotNull(result);    
        }
    }
}