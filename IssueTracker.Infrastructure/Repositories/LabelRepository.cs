using IssueTracker.Application.Interfaces;
using IssueTracker.Domain.Models;

namespace IssueTracker.Infrastructure.Repositories
{
    public class LabelRepository: ILabelRepository
    {
        private readonly ApplicationDbContext _context;
        public LabelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<List<Label>> GetLabelByNameAsync(string name)
        {
            // Implementation to retrieve labels by name from the database
            throw new NotImplementedException();
        }

        public Task<Label> GetLabelByIdAsync(int labelId)
        {
            // Implementation to retrieve a label by ID from the database
            throw new NotImplementedException();
        }
        
        public async Task<int> AddLabelAsync(Label label)
        {
            _context.Labels.Add(label);
            await _context.SaveChangesAsync();
            return label.Id;
        }
        public async Task DeleteLabelAsync(int labelId)
        {
            var label = await _context.Labels.FindAsync(labelId);
            if (label != null)
            {
                _context.Labels.Remove(label);
                await _context.SaveChangesAsync();
            }
        }
    }
}
