using System;
using System.Collections.Generic;

namespace PatiantNoteCQRS.Models;

public partial class PrescriptionItem
{
    public int PrescriptionItemId { get; set; }

    public int ExtractionId { get; set; }

    public string MedicationName { get; set; } = null!;

    public string? Dosage { get; set; }

    public string? Frequency { get; set; }

    public string? Duration { get; set; }

    public virtual ExtractedDocumentDatum Extraction { get; set; } = null!;
}
