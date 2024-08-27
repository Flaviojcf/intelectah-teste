using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ConcessionariaCommands.CreateConcessionaria
{
    public class CreateConcessionariaCommandHandler(IConcessionariaRepository concessionariaRepository, IValidateConcessionariaRulesService validateConcessionariaRulesService) : IRequestHandler<CreateConcessionariaCommand, int>
    {
        private readonly IConcessionariaRepository _concessionariaRepository = concessionariaRepository;
        private readonly IValidateConcessionariaRulesService _validateConcessionariaRulesService = validateConcessionariaRulesService;

        public async Task<int> Handle(CreateConcessionariaCommand request, CancellationToken cancellationToken)
        {
            await _validateConcessionariaRulesService.ValidateConcessionaria(request);

            var concessionaria = new Concessionaria(request.Nome, request.Endereco, request.Cidade, request.Estado, request.CEP, request.Telefone, request.Email, request.CapacidadeMaximaVeiculos);

            await _concessionariaRepository.CreateAsync(concessionaria);

            return concessionaria.Id;
        }
    }
}
