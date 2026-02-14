using System.ComponentModel;
using System.Runtime.Serialization;

namespace Memori_Care.Enums;

public enum TipoSanguineo
{
    [EnumMember(Value = "APositivo")]
    APositivo = 1,
    [EnumMember(Value = "ANegativo")]
    ANegativo = 2,
    [EnumMember(Value = "BPositivo")]
    BPositivo = 3,
    [EnumMember(Value = "BNegativo")]
    BNegativo = 4,
    [EnumMember(Value = "ABPositivo")]
    ABPositivo = 5,
    [EnumMember(Value = "ABNegativo")]
    ABNegativo = 6,
    [EnumMember(Value = "OPositivo")]
    OPositivo = 7,
    [EnumMember(Value = "ONegativo")]
    ONegativo = 8,
    [EnumMember(Value = "Não Informado")]
    NãoInformou = 9


}
