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
        private readonly ISupplierService _SupplierService;
        private readonly IMapper _mapper;

        public SupplierBAL(IMapper mapper, ISupplierService SupplierService)
        {
            _mapper = mapper;
            _SupplierService = SupplierService;
        }

        public ResultMessage Create(ViewModel.Supplier entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Supplier Supplier = new ObjectModel.Supplier();
            _mapper.Map<ViewModel.Supplier, ObjectModel.Supplier>(entity, Supplier);
            return _SupplierService.Create(Supplier);
        }

        public ResultMessage Update(ViewModel.Supplier entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Supplier Supplier = new ObjectModel.Supplier();
            _mapper.Map<ViewModel.Supplier, ObjectModel.Supplier>(entity, Supplier);
            return _SupplierService.Update(Supplier);
        }

        public ResultMessage Delete(int SupplierId)
        {
            return _SupplierService.Delete(SupplierId);
        }

        public IQueryable<ViewModel.Supplier> GetAll()
        {
            var categories = _SupplierService.GetAll().ToList();
            List<ViewModel.Supplier> SupplierList = new();
            SupplierList = _mapper.Map<List<ObjectModel.Supplier>, List<ViewModel.Supplier>>(categories);
            return SupplierList.AsQueryable();
        }

        public ViewModel.Supplier GetById(int SupplierId)
        {
            ObjectModel.Supplier Supplier = _SupplierService.GetById(SupplierId);
            ViewModel.Supplier SupplierViewModel = _mapper.Map<ObjectModel.Supplier, ViewModel.Supplier>(Supplier);
            return SupplierViewModel;
        }
    }
}