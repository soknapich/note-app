using APIApplication.Entities;
using APIApplication.Models.Request;
using APIApplication.Models.Respone;

namespace APIApplication.Services.Interfaces
{
    public interface INoteService
    {

        Task<IEnumerable<NoteRespone>> GetAll(Guid userId);
        Task<NoteRespone?> GetById(Guid id, Guid userId);
        Task<int?> Create(NoteRequest request, Guid userId);
        Task<bool?> Update(Guid userId, Guid id, NoteRequest request);
        Task<bool?> Delete(Guid id, Guid userId);
       
    }
}
