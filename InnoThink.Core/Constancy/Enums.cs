namespace InnoThink.Core.Constancy
{
    public enum DataBaseName
    {
        InnoThinkMain = 0
    }

    public enum SessionKeys
    {
        Captcha = 0,
        Trading,
        VerifyCode
    }

    public enum TopicStatus
    {
        InProcess = 0,
        Closed
    }

    public enum SignalRMessageType
    {
        Unit1,
        BoardWide,
        BoardInside
    }

    public enum BestType
    {
        B,
        E,
        S,
        T
    }

    public enum ResultType
    {
        DRAFT,
        DASHBOARD,
        PRESENTATION,
        SCENARIO_1,
        SCENARIO_3,
        SCENARIO_7
    }
}