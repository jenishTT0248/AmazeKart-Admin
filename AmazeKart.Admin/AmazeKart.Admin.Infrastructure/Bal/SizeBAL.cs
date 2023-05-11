using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class SizeBAL : ISizeBAL
    {
        private readonly ISizeService _sizeService;
        private readonly IMapper _mapper;

        public SizeBAL(IMapper mapper, ISizeService sizeService)
        {
            _mapper = mapper;
            _sizeService = sizeService;
        }

        public ResultMessage Create(ViewModel.Size entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Size size = new ObjectModel.Size();
            _mapper.Map<ViewModel.Size, ObjectModel.Size>(entity, size);
            return _sizeService.Create(size);
        }

        public ResultMessage Update(ViewModel.Size entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Size size = new ObjectModel.Size();
            _mapper.Map<ViewModel.Size, ObjectModel.Size>(entity, size);
            return _sizeService.Update(size);
        }

        public ResultMessage Delete(int sizeId)
        {
            return _sizeService.Delete(sizeId);
        }

        public IQueryable<ViewModel.Size> GetAll()
        {
            var sizes = _sizeService.GetAll().ToList();
            List<ViewModel.Size> sizeList = new();
            sizeList = _mapper.Map<List<ObjectModel.Size>, List<ViewModel.Size>>(sizes);
            return sizeList.AsQueryable();
        }

        public ViewModel.Size GetById(int sizeId)
        {
            ObjectModel.Size size = _sizeService.GetById(sizeId);
            ViewModel.Size sizeViewModel = _mapper.Map<ObjectModel.Size, ViewModel.Size>(size);
            return sizeViewModel;
        }
    }
}