﻿using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelpers _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelpers combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public async Task<Contract> ToContractAsync(ContractViewModel model, bool IsNew)
        {
            return new Contract
            {
                //guardar registro con hora de londres
                EndDate = model.EndDate.ToUniversalTime(),
                Id = IsNew ? 0 : model.Id,
                IsActive = model.IsActive,
                Lessee = await _dataContext.Lessees.FindAsync(model.LesseeId),
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                Price = model.Price,
                Property = await _dataContext.Properties.FindAsync(model.PropertyId),
                Remarks = model.Remarks,
                StartDate = model.StartDate.ToUniversalTime(),

            };
        }

        public async Task<Property> ToPropertyAsync(PropertyViewModel model, bool isNew)
        {
            return new Property
            {
                Address = model.Address,
                Contracts = isNew ? new List<Contract>() : model.Contracts,
                HasParkingLot = model.HasParkingLot,
                Id = isNew ? 0 : model.Id,
                IsAvailable = model.IsAvailable,
                Neighborhood = model.Neighborhood,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                Price = model.Price,
                PropertyType = await _dataContext.PropertyTypes.FindAsync(model.PropertyTypeId),
                PropertyImages = isNew ? new List<PropertyImage>() : model.PropertyImages,
                Rooms = model.Rooms,
                SquareMeters = model.SquareMeters,
                Stratum = model.Stratum,
                Remarks = model.Remarks
            };
        }

        public PropertyViewModel ToPropertyViewModel(Property property)
        {
            return new PropertyViewModel
            {
                Address = property.Address,
                Contracts = property.Contracts,
                HasParkingLot = property.HasParkingLot,
                Id = property.Id,
                IsAvailable = property.IsAvailable,
                Neighborhood = property.Neighborhood,
                Owner = property.Owner,
                Price = property.Price,
                PropertyType = property.PropertyType,
                PropertyImages = property.PropertyImages,
                Rooms = property.Rooms,
                SquareMeters = property.SquareMeters,
                Stratum = property.Stratum,
                Remarks = property.Remarks,
                OwnerId = property.Owner.Id,
                PropertyTypeId = property.PropertyType.Id,
                PropertyTypes = _combosHelper.GetComboPropertyTypes()

            };
        }

        public ContractViewModel ToContractViewModel(Contract contract)
        {
            return new ContractViewModel
            {
                EndDate = contract.EndDate,
                IsActive = contract.IsActive,
                LesseeId = contract.Lessee.Id,
                OwnerId = contract.Owner.Id,
                Price = contract.Price,
                Remarks = contract.Remarks,
                StartDate = contract.StartDate,
                Id = contract.Id,
                Lessees = _combosHelper.GetComboLessees(),
                PropertyId = contract.Property.Id
            };
        }

    }
}
