namespace Pos.Contracts.Enums;

/// <summary>
/// different type of functions an stand could fullfil
/// </summary>
[Flags]
public enum StandType
{
    Bar,
    Pool,
    Lobby,
    Reception,
    Restaurant,
    ConferenceRoom,
    WareHouse,
    Kitchen,
    Store,
    Drugstore,
    Workshop,
    NotSpecified
}
