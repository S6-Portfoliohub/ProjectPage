﻿using DAOInterfaces.DTO;

namespace DAOInterfaces.Interfaces
{
    public interface IProjectDAO
    {
        /// <summary>
        /// Method that retrives all projects from a user to show on their user page
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProjectDTO> GetProjectById(string projectId);

        /// <summary>
        /// Adds a new project to a user
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        Task AddProjectForUser(ProjectDTO projectDTO);

        /// <summary>
        /// Replaces existing project with new project
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        Task UpdateProjectForUser(ProjectDTO projectDTO);

        /// <summary>
        /// Deletes project based on the project Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task DeleteProjectFromUser(string projectId);
    }
}
