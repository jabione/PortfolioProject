using Microsoft.AspNetCore.Mvc;
using PortfolioProject.IServices;
using PortfolioProject.Models;
using PortfolioProject.Services;
using System.Net.Mime;

namespace PortfolioProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkedinController : ControllerBase
    {
        private readonly ILinkedinService<LinkedinService> _linkedinService;
        private const string email = "anthony@company.com";

        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="linkedinService"></param>
        public LinkedinController(ILinkedinService<LinkedinService> linkedinService)
        {
            _linkedinService = linkedinService;
        }

        /// <summary>
        /// Get User Infos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<User> GetAsync()
        {
            // get user infos by email
            return await _linkedinService.GetUserByEmail(email);

        }

        /// <summary>
        /// Get About User Infos
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public async Task<User> GetAboutAsync()
        {
            // get about infos of user by email
            return await _linkedinService.GetAboutUserByEmail(email);

        }

        /// <summary>
        /// Post Contact
        /// </summary>
        /// <param name="obj">User  contact dynamic object</param>
        /// <returns>True if Post is successful else false</returns>
        [HttpPost]
        public async Task<bool> PostAsync([FromForm] UserContact userContact)
        {
            bool result = false;

            if (userContact != null)
                result = await _linkedinService.PostContactByEmail(userContact);

            return result;
        }


    }
}