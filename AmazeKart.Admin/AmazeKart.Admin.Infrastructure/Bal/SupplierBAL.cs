using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class SupplierBAL : ISupplierBAL
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierBAL(IMapper mapper, ISupplierService SupplierService)
        {
            _mapper = mapper;
            _supplierService = SupplierService;
        }
        
        public ResultMessage Create(ViewModel.Supplier entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Supplier supplier = new ObjectModel.Supplier();
            _mapper.Map<ViewModel.Supplier, ObjectModel.Supplier>(entity, supplier);
            return _supplierService.Create(supplier);
        }

        public ResultMessage Update(ViewModel.Supplier entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Supplier supplier = new ObjectModel.Supplier();
            _mapper.Map<ViewModel.Supplier, ObjectModel.Supplier>(entity, supplier);
            return _supplierService.Update(supplier);
        }

        public ResultMessage Delete(int supplierId)
        {
            return _supplierService.Delete(supplierId);
        }

        public IQueryable<ViewModel.Supplier> GetAll()
        {
            var suppliers = _supplierService.GetAll().ToList();
            List<ViewModel.Supplier> supplierList = new();
            supplierList = _mapper.Map<List<ObjectModel.Supplier>, List<ViewModel.Supplier>>(suppliers);
            return supplierList.AsQueryable();
        }

        public ViewModel.Supplier GetById(int supplierId)
        {
            ObjectModel.Supplier supplier = _supplierService.GetById(supplierId);
            ViewModel.Supplier supplierViewModel = _mapper.Map<ObjectModel.Supplier, ViewModel.Supplier>(supplier);
            return supplierViewModel;
        }
    }
}