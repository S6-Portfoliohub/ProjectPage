using DAOInterfaces.DTO;
using DAOInterfaces.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DAL.DAO
{
    public class ProjectDAO : IProjectDAO
    {
        private readonly IMongoCollection<ShowcaseItemDTO> _projectCollection;

        public ProjectDAO(IOptions<ProjectDatabaseSettings> projectDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            projectDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectDatabaseSettings.Value.DatabaseName);

            _projectCollection = mongoDatabase.GetCollection<ShowcaseItemDTO>(
                projectDatabaseSettings.Value.ProjectCollectionName);
        }

        public async Task<List<ShowcaseItemDTO>> GetShowcaseItems(string projectId)
        {
            List<ShowcaseItemDTO> showcaseItems = await _projectCollection.Find<ShowcaseItemDTO>(showcaseItem => showcaseItem.ProjectId == projectId).ToListAsync();
            return showcaseItems;
        }

        public async Task CreateShowcaseItem(ShowcaseItemDTO showcaseItem)
        {
            await _projectCollection.InsertOneAsync(showcaseItem);
        }
    }
}
