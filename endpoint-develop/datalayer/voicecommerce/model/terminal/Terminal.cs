using core_develop.cashflows.common;
using core_develop.cashflows.core.authorisation;
using core_develop.cashflows.core.common;
using core_develop.cashflows.core.model.terminal;
using datalayer.voicecommerce.entity.authorisation;
using datalayer.voicecommerce.model.card;

namespace datalayer.voicecommerce.model.terminal
{
    public interface Terminal
    {
        TerminalStatus Status { get; }
        AcceptorDetail DefaultAcceptorDetail { get; }
        int MCC { get; }
        string BID { get; }

        Terminal_Lock @lock(string v, Card card, AuthScheme authScheme);
        Terminal_Lock @lock(string v, object card, AuthScheme authScheme);

        Country Country { get; }
    }
    public interface Terminal_Lock
    {
        ActionStatistics CardStatistics { get; }
        ActionStatistics SchemeStatistics { get; }

        void unlock(Action action);
    }
}
