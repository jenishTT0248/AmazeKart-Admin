﻿using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;
using ViewModelResponse = AmazeKart.Admin.Core.ViewModel.Response;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class ProductBAL : IProductBAL
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IMapper _mapper;

        public ProductBAL(IMapper mapper, IProductService productService, IProductDetailService productDetailService)
        {
            _productService = productService;
            _productDetailService = productDetailService;
            _mapper = mapper;
        }

        public ResultMessage Create(ViewModel.Product entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Product product = new ObjectModel.Product();
            _mapper.Map<ViewModel.Product, ObjectModel.Product>(entity, product);
            _productService.Create(product);

            foreach (var detail in entity.ProductDetails)
            {
                ObjectModel.ProductDetail productDetail = new ObjectModel.ProductDetail();
                _mapper.Map<ViewModel.ProductDetail, ObjectModel.ProductDetail>(detail, productDetail);
                productDetail.ProductId = product.Id;
                _productDetailService.Create(productDetail);
            }

            return ResultMessage.Success;
        }

        public ResultMessage Update(ViewModel.Product entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Product product = new ObjectModel.Product();
            _mapper.Map<ViewModel.Product, ObjectModel.Product>(entity, product);
            return _productService.Update(product);
        }

        public ResultMessage Delete(int productId)
        {
            return _productService.Delete(productId);
        }

        public IQueryable<ViewModelResponse.ProductResponse> GetAll()
        {
            var products = _productService.GetAll().ToList();
            List<ViewModelResponse.ProductResponse> productList = new();
            productList = _mapper.Map<List<ObjectModel.Product>, List<ViewModelResponse.ProductResponse>>(products);
            return productList.AsQueryable();
        }

        public ViewModelResponse.ProductResponse GetById(int productId)
        {
            ObjectModel.Product product = _productService.GetById(productId);
            ViewModelResponse.ProductResponse productViewModel = _mapper.Map<ObjectModel.Product, ViewModelResponse.ProductResponse>(product);
            return productViewModel;
        }
    }
}