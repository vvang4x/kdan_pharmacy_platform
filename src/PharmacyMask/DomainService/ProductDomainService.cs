﻿using Mapster;
using PharmacyMask.DomainService.Entity;
using PharmacyMask.Fundation.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyMask.DomainService
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IPharmacyProductRepository _pharmacyProductRepository;
        private readonly IMaskService _maskService;

        public ProductDomainService(
            IPharmacyProductRepository pharmacyProductRepository,
            IMaskService maskService
            )
        {
            _pharmacyProductRepository = pharmacyProductRepository;
            _maskService = maskService;
        }

        public List<PharmacyProductEntity> GetPharmacyProductList(PharmacyProductSearchEntity searchEntity)
        => _pharmacyProductRepository.SelectByOption(
                searchEntity.IdList,
                searchEntity.PharmacyIdList,
                searchEntity.ProductDetailIdList,
                searchEntity.ProductTypeIdList,
                searchEntity.PriceFrom,
                searchEntity.PriceTo
                ).Select(s => s.Adapt<PharmacyProductEntity>()).ToList();

        public bool UpdateMask(ProductEntity productEntity)
        {
            return _maskService.UpdateMask(new MaskEntity
            {
                Id = productEntity.Id,
                Name = productEntity.ProductName
            });

        }

    }
}
