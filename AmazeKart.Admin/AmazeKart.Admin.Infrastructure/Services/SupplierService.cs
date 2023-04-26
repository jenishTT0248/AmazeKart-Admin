using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _SupplierRepository;

        public SupplierService(IUnitOfWork unitOfWork, ISupplierRepository SupplierRepository)
        {
            _unitOfWork = unitOfWork;
            _SupplierRepository = SupplierRepository;
        }

        public ResultMessage Create(Supplier Supplier)
        {
            if (Supplier == null) return ResultMessage.RecordNotFound;

            bool isSupplierExists = _SupplierRepository.Any(y => y.Email == Supplier.Email);

            if (isSupplierExists) return ResultMessage.RecordExists;

            _SupplierRepository.Create(Supplier);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Update(Supplier Supplier)
        {
            if (Supplier == null) return ResultMessage.RecordNotFound;

            if (_SupplierRepository.Any(x => x.Id != Supplier.Id && x.Email == Supplier.Email))
            {
                return ResultMessage.RecordExists;
            }

            Supplier dbSupplier = _SupplierRepository.FindOne(x => x.Id == Supplier.Id);
            if (dbSupplier == null) return ResultMessage.RecordNotFound;

            _SupplierRepository.SetValues(dbSupplier, Supplier);
            _SupplierRepository.Update(dbSupplier);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }


        public ResultMessage Delete(int SupplierId)
        {
            Supplier dbSupplier = _SupplierRepository.FindOne(x => x.Id == SupplierId);
            if (dbSupplier == null) return ResultMessage.RecordNotFound;

            _SupplierRepository.Delete(dbSupplier);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public Supplier GetById(int SupplierId)
        {
            return _SupplierRepository.FindOne(x => x.Id == SupplierId);
        }

        public IQueryable<Supplier> GetAll()
        {
            return _SupplierRepository.All();
        }
    }
}