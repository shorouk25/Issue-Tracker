using IssueTracker.Domain.Models;

namespace IssueTracker.Application.Interfaces
{
    public interface ILabelRepository
    {
        Task<List<Label>> GetLabelByNameAsync(string name); //return a list of labels that match the given name while searching
        Task<Label> GetLabelByIdAsync(int labelId);
    }
}
