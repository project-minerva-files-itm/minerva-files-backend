using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.UnitsOfWork.Interfaces;

public interface IDocumentTypeUnitOfWork
{
    Task<ActionResponse<DocumentType>> AddAsync(DocumentTypeDTO documentTypeDTO);
}