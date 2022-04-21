using PortfolioProject.Models;

namespace PortfolioProject.IServices
{
    public interface ILinkedinService<T>
    {

        /// <summary>
        /// Get user infos by email
        /// </summary>
        /// <param name="email">email of user</param>
        /// <returns>user object</returns>
        Task<User> GetUserByEmail(string email);


        /// <summary>
        /// Get About Infos of User by email
        /// </summary>
        /// <param name="email">email of user</param>
        /// <returns>user object</returns>
        Task<User> GetAboutUserByEmail(string email);


        /// <summary>
        /// Post Contact
        /// </summary>
        /// <param name="userContact">UserContact object</param>
        /// <returns>True if Post is successful else false</returns> 
        Task<bool> PostContactByEmail(UserContact userContact);



    }
}
