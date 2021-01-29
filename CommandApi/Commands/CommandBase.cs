namespace CommandApi.Commands
{
    using MediatR;
    using Newtonsoft.Json;

    public abstract class CommandBase : IRequest<string>
    {
        [JsonRequired]
        public abstract string CommandName { get; }
    }
}
