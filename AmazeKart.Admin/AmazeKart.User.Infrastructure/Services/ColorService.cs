using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IColorRepository _colorRepository;

        public ColorService(IUnitOfWork unitOfWork, IColorRepository colorRepository)
        {
            _unitOfWork = unitOfWork;
            _colorRepository = colorRepository;
        }

        public ResultMessage Create(Color color)
        {
            if (color == null) return ResultMessage.RecordNotFound;

            bool isColorExists = _colorRepository.Any(y => y.ColorName == color.ColorName && y.Active);

            if (isColorExists) return ResultMessage.RecordExists;

            _colorRepository.Create(color);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Update(Color color)
        {
            if (color == null) return ResultMessage.RecordNotFound;

            if (_colorRepository.Any(x => x.Id != color.Id && x.ColorName == color.ColorName && x.Active))
            {
                return ResultMessage.RecordExists;
            }

            Color dbColor = _colorRepository.FindOne(x => x.Id == color.Id && x.Active);

            if (dbColor == null) return ResultMessage.RecordNotFound;

            _colorRepository.SetValues(dbColor, color);
            _colorRepository.Update(dbColor);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int colorId)
        {
            Color dbColor = _colorRepository.FindOne(x => x.Id == colorId && x.Active);

            if (dbColor == null) return ResultMessage.RecordNotFound;

            _colorRepository.Delete(dbColor);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public Color GetById(int colorId)
        {
            return _colorRepository.FindOne(x => x.Id == colorId && x.Active);
        }

        public IQueryable<Color> GetAll()
        {
            return _colorRepository.Find(y => y.Active);
        }
    }
}