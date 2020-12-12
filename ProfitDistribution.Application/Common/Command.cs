using ProfitDistribution.Application.Abstraction.Common;
using ProfitDistribution.Exception;

namespace ProfitDistribution.Application.Common
{
    public abstract class Command
    {
        protected Command()
        {
        }

        protected CommandResponse CommandResponseOk()
        {
            return new CommandResponse();
        }

        protected CommandResponse CommandResponseFail(BaseException exception)
        {
            return new CommandResponse(exception);
        }
    }
}