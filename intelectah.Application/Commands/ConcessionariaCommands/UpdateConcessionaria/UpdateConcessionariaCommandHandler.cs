using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ConcessionariaCommands.UpdateConcessionaria
{
    public class UpdateConcessionariaCommandHandler(IConcessionariaRepository concessionariaRepository) : IRequestHandler<UpdateConcessionariaCommand, Unit>
    {
        private readonly IConcessionariaRepository _concessionariaRepository = concessionariaRepository;

        public async Task<Unit> Handle(UpdateConcessionariaCommand request, CancellationToken cancellationToken)
        {
            var concessionaria = await _concessionariaRepository.GetByIdAsync(request.Id);

            concessionaria.Update(request.Nome, request.Endereco, request.Cidade, request.Estado, request.CEP, request.Telefone, request.Email, request.CapacidadeMaximaVeiculos);

            await _concessionariaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
