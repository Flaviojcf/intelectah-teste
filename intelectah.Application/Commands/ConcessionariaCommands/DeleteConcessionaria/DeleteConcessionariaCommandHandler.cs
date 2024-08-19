using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ConcessionariaCommands.DeleteConcessionaria
{

    public class DeleteConcessionariaCommandHandler(IConcessionariaRepository concessionariaRepository) : IRequestHandler<DeleteConcessionariaCommand, Unit>
    {
        private readonly IConcessionariaRepository _concessionariaRepository = concessionariaRepository;

        public async Task<Unit> Handle(DeleteConcessionariaCommand request, CancellationToken cancellationToken)
        {
            var concessionaria = await _concessionariaRepository.GetByIdAsync(request.Id);

            concessionaria.DeActive();

            await _concessionariaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
