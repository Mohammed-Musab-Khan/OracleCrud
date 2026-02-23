using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleCrud.Models;

[Table("REF_DATA_ENTRIES")]
public class ReferenceData
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("FROM_ID")]
    public string FromId { get; set; } = string.Empty;

    [Column("DOMAIN_ENTITY")]
    public string? DomainEntity { get; set; }

    [Column("DOMAIN_NAME")]
    public string? DomainName { get; set; }

    [Column("ENTITY_NAME")]
    public string? EntityName { get; set; }

    [Column("DEPARTMENT")]
    public string? Department { get; set; } // HR or IT

    [Column("IS_ACTIVE")]
    public int IsActive { get; set; }

    [Column("CREATED_BY")]
    public string? CreatedBy { get; set; }

    [Column("CREATED_ON")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    [Column("CHECKER_BY")]
    public string? CheckerBy { get; set; }

    [Column("CHECKER_ON")]
    public DateTime? CheckerOn { get; set; }

    [Column("STATUS")]
    public int Status { get; set; } // 0=Pending, 1=Approved, 2=Rejected
}

