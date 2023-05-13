using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
        }

        public ResultMessage Create(Supplier supplier)
        {
            if (supplier == null) return ResultMessage.RecordNotFound;

            bool isSupplierExists = _supplierRepository.Any(y => y.Email == supplier.Email && y.Active);

            if (isSupplierExists) return ResultMessage.RecordExists;

            _supplierRepository.Create(supplier);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Update(Supplier supplier)
        {
            if (supplier == null) return ResultMessage.RecordNotFound;

            if (_supplierRepository.Any(x => x.Id != supplier.Id && x.Email == supplier.Email && x.Active))
            {
                return ResultMessage.RecordExists;
            }

            Supplier dbSupplier = _supplierRepository.FindOne(x => x.Id == supplier.Id && x.Active);
            if (dbSupplier == null) return ResultMessage.RecordNotFound;

            _supplierRepository.SetValues(dbSupplier, supplier);
            _supplierRepository.Update(dbSupplier);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int supplierId)
        {
            Supplier dbSupplier = _supplierRepository.FindOne(x => x.Id == supplierId && x.Active);
            if (dbSupplier == null) return ResultMessage.RecordNotFound;

            _supplierRepository.Delete(dbSupplier);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public Supplier GetById(int supplierId)
        {
            return _supplierRepository.FindOne(x => x.Id == supplierId && x.Active);
        }

        public IQueryable<Supplier> GetAll()
        {
            return _supplierRepository.Find(x => x.Active);
        }
    }
}