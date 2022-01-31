using MediatR;
using VAZ.Application.Catalog.Cities.Commands.Models;
using VAZ.Application.Utilities.Messages;
using VAZ.Domain.Entities;
using VAZ.Infrastructure.Persistence;
using VAZ.Shared.Utilities.Results;

namespace VAZ.Application.Catalog.Cities.Commands.Handlers
{
	public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, IResult>
	{
		IRepository<City> _cityRepository;

		public DeleteCityCommandHandler(IRepository<City> cityRepository)
		{
			_cityRepository = cityRepository;
		}
		public async Task<IResult> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
		{
			City city = await _cityRepository.GetByIdAsync(request.Id);

			if (city == null)
				return new ErrorResult(Messages.NotFound);

			await _cityRepository.DeleteAsync(city);

			return new SuccessResult(Messages.Deleted);
		}
	}
}
