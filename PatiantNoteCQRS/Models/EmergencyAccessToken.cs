using System;
using System.Collections.Generic;

namespace PatiantNoteCQRS.Models;

public partial class EmergencyAccessToken
{
    public int TokenId { get; set; }

    public int PatientId { get; set; }

    public string AccessToken { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
