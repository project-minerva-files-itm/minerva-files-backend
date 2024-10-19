using Microsoft.AspNetCore.Mvc;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SettingsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentTypeController : GenericController<DocumentType>
{
    private readonly IDocumentTypeUnitOfWork _documentTypeUnitOfWork;

    public DocumentTypeController(IGenericUnitOfWork<DocumentType> unitOfWork, IDocumentTypeUnitOfWork documentTypeUnitOfWork) : base(unitOfWork)
    {
        _documentTypeUnitOfWork = documentTypeUnitOfWork;
    }
}