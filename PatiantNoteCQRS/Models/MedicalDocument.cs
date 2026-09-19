using System;
using System.Collections.Generic;

namespace PatiantNoteCQRS.Models;

public partial class MedicalDocument
{
    public int DocumentId { get; set; }

    public int PatientId { get; set; }

    public string DocumentType { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public DateTime? UploadDate { get; set; }

    public string? ProcessingStatus { get; set; }

    public virtual ExtractedDocumentDatum? ExtractedDocumentDatum { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
