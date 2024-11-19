using SettingsService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Implementations;

public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
{
    private readonly IDataConext _context;

    public DocumentTypeRepository(IDataConext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<DocumentType>> AddAsync(DocumentTypeDTO DocumentTypeDTO)
    {
        DocumentType documentType = new DocumentType
        {
            Name = DocumentTypeDTO.Name,
            Description = DocumentTypeDTO.Description,
            LastUser = DocumentTypeDTO.LastUser,
        };
        return await AddAsync(documentType);
    }
}