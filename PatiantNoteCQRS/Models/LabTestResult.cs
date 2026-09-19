using System;
using System.Collections.Generic;

namespace PatiantNoteCQRS.Models;

public partial class LabTestResult
{
    public int LabTestResultId { get; set; }

    public int ExtractionId { get; set; }

    public string TestName { get; set; } = null!;

    public string ResultValue { get; set; } = null!;

    public string? Unit { get; set; }

    public string? ReferenceRange { get; set; }

    public bool? IsAbnormal { get; set; }

    public virtual ExtractedDocumentDatum Extraction { get; set; } = null!;
}
