using DAOInterfaces.DTO;

namespace DAOInterfaces.Interfaces
{
    public interface IProjectDAO
    {
        /// <summary>
        /// Get all showcase items from a project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<List<ShowcaseItemDTO>> GetShowcaseItems(string projectId);

        /// <summary>
        /// Create a showcase item
        /// </summary>
        /// <param name="showcaseItem"></param>
        /// <returns></returns>
        Task CreateShowcaseItem(ShowcaseItemDTO showcaseItem);

        /// <summary>
        /// Get all showcase items from a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<ShowcaseItemDTO>> GetShowcaseItemsByUser(string userId);

        /// <summary>
        /// Delete all showcase items from a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task DeleteShowcaseItemsByUser(string userId);
    }
}
