using StudentDocumentManagement.Models;
using System.Collections.Generic;

namespace StudentDocumentManagement.ViewModels
{
    public class PendingViewModel
    {
        public IEnumerable<DocumentRequest> DocumentRequests { get; set; }
    }
}
