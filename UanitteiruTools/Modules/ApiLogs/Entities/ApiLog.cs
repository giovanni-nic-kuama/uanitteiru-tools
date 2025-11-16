using System.ComponentModel.DataAnnotations;
using UanitteiruTools.Common.Entities;

namespace UanitteiruTools.Modules.ApiLogs.Entities;

public class ApiLog : BaseEntity
{
    [MaxLength(12)]
    public required string Code { get; set; }
    [MaxLength(200)]
    public required string Error { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}