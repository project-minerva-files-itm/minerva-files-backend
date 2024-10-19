using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace SettingsService.UnitsOfWork.Implementations;

public class DocumentTypeUnitOfWork : GenericUnitOfWork<DocumentType>, IDocumentTypeUnitOfWork
{
    private readonly IDocumentTypeRepository _documentTypeRepository;

    public DocumentTypeUnitOfWork(IGenericRepository<DocumentType> repository, IDocumentTypeRepository documentTypeRepository) : base(repository)
    {
        _documentTypeRepository = documentTypeRepository;
    }

    public async Task<ActionResponse<DocumentType>> AddAsync(DocumentTypeDTO documentTypeDTO) => await _documentTypeRepository.AddAsync(documentTypeDTO);
}