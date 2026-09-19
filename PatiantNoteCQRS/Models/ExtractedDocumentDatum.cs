using System;
using System.Collections.Generic;

namespace PatiantNoteCQRS.Models;

public partial class ExtractedDocumentDatum
{
    public int ExtractionId { get; set; }

    public int DocumentId { get; set; }

    public DateOnly? DocumentDate { get; set; }

    public string? DoctorName { get; set; }

    public string? EntityName { get; set; }

    public string? Diagnosis { get; set; }

    public string? RawAiOutput { get; set; }

    public virtual MedicalDocument Document { get; set; } = null!;

    public virtual ICollection<LabTestResult> LabTestResults { get; set; } = new List<LabTestResult>();

    public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
}
