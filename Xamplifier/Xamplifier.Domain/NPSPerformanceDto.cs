using System;
using Dapper.Contrib.Extensions;

namespace Xamplifier.Domain
{
    [Table("Campaign.CampaignMaster")]
    public class NPSPerformanceDto
    {
        [Key]
        public int CampaignId { get; set; }
        public int EnterpriseId { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public int Promotor { get; set; }
        public int Detractors { get; set; }
        public int Passive { get; set; }
    }
}
