using Quizzen.Domain.Entities;
using Quizzen.Domain.enums;

namespace Quizzen.Application.Abstracts
{
    public interface IActionTokenRepository
    {
        public Task<ActionToken?> CreateActionTokenAsync(Guid userId);
        public Task<ActionToken?> GetActionTokenAsync(Guid userId, ActionTokenPurpose actionTokenPurpose);
        public Task UpdateActionTokenAsync(ActionToken resetPasswordToken);
    }
}
