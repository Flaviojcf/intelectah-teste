using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ConcessionariaCommands.CreateConcessionaria
{
    public class CreateConcessionariaCommandHandler(IConcessionariaRepository concessionariaRepository) : IRequestHandler<CreateConcessionariaCommand, int>
    {
        private readonly IConcessionariaRepository _concessionariaRepository = concessionariaRepository;

        public async Task<int> Handle(CreateConcessionariaCommand request, CancellationToken cancellationToken)
        {
            var concessionaria = new Concessionaria(request.Nome, request.Endereco, request.Cidade, request.Estado, request.CEP, request.Telefone, request.Email, request.CapacidadeMaximaVeiculos);

            await _concessionariaRepository.CreateAsync(concessionaria);

            return concessionaria.Id;
        }
    }
}
