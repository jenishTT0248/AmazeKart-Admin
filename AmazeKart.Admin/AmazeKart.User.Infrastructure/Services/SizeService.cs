using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository, IUnitOfWork unitOfWork)
        {
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
        }

        public ResultMessage Create(Size size)
        {
            if (size == null) return ResultMessage.RecordNotFound;

            bool isSizeExists = _sizeRepository.Any(y => y.SizeName == size.SizeName && y.Active);

            if (isSizeExists)
                return ResultMessage.RecordExists;

            _sizeRepository.Create(size);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int sizeId)
        {
            Size dbSize = _sizeRepository.FindOne(x => x.Id == sizeId && x.Active);
            if (dbSize == null) return ResultMessage.RecordNotFound;

            _sizeRepository.Delete(dbSize);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public IQueryable<Size> GetAll()
        {
            return _sizeRepository.Find(x => x.Active);
        }

        public Size GetById(int sizeId)
        {
            return _sizeRepository.FindOne(x => x.Id == sizeId && x.Active);
        }

        public ResultMessage Update(Size size)
        {
            if (size == null) return ResultMessage.RecordNotFound;

            if (_sizeRepository.Any(x => x.Id != size.Id && x.SizeName == size.SizeName && x.Active))
            {
                return ResultMessage.RecordExists;
            }

            Size dbSize = _sizeRepository.FindOne(x => x.Id == size.Id && x.Active);
            if (dbSize == null) return ResultMessage.RecordNotFound;

            _sizeRepository.SetValues(dbSize, size);
            _sizeRepository.Update(dbSize);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
    }
}