namespace CommandApi.Commands
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class Handler : IRequestHandler<AlterarEnderecoCommand, string>, IRequestHandler<AlterarTelefoneCommand, string>
    {

        public Task<string> Handle(AlterarEnderecoCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Endereço alterado para: {request.Logradouro}, {request.Numero} {request.Complemento} - {request.Bairro}, {request.Cidade}/{request.Estado}");
        }

        public Task<string> Handle(AlterarTelefoneCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Telefone alterado para: ({request.DDD}) {request.Numero}");
        }
    }
}
