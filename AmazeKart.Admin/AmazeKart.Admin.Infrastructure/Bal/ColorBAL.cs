using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class ColorBAL : IColorBAL
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ColorBAL(IMapper mapper, IColorService colorService)
        {
            _mapper = mapper;
            _colorService = colorService;
        }

        public ResultMessage Create(ViewModel.Color entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Color color = new ObjectModel.Color();
            _mapper.Map<ViewModel.Color, ObjectModel.Color>(entity, color);
            return _colorService.Create(color);
        }

        public ResultMessage Update(ViewModel.Color entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Color color = new ObjectModel.Color();
            _mapper.Map<ViewModel.Color, ObjectModel.Color>(entity, color);
            return _colorService.Update(color);
        }

        public ResultMessage Delete(int colorId)
        {
            return _colorService.Delete(colorId);
        }

        public IQueryable<ViewModel.Color> GetAll()
        {
            var colors = _colorService.GetAll().ToList();
            List<ViewModel.Color> colorList = new();
            colorList = _mapper.Map<List<ObjectModel.Color>, List<ViewModel.Color>>(colors);
            return colorList.AsQueryable();
        }

        public ViewModel.Color GetById(int colorId)
        {
            ObjectModel.Color color = _colorService.GetById(colorId);
            ViewModel.Color colorViewModel = _mapper.Map<ObjectModel.Color, ViewModel.Color>(color);
            return colorViewModel;
        }
    }
}