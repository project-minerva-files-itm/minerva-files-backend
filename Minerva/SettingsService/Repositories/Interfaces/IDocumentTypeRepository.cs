using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Interfaces;

public interface IDocumentTypeRepository
{
    Task<ActionResponse<DocumentType>> AddAsync(DocumentTypeDTO DocumentTypeDTO);
}