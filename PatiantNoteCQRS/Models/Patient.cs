using System;
using System.Collections.Generic;

namespace PatiantNoteCQRS.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public int UserId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? BloodType { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? ChronicDiseases { get; set; }

    public string? KnownAllergies { get; set; }

    public virtual ICollection<EmergencyAccessToken> EmergencyAccessTokens { get; set; } = new List<EmergencyAccessToken>();

    public virtual ICollection<MedicalDocument> MedicalDocuments { get; set; } = new List<MedicalDocument>();

    public virtual User User { get; set; } = null!;
}
