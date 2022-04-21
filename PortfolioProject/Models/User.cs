using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
  /// <summary>
  /// User Model
  /// </summary>
    public class User
    {
        /// <summary>
        /// Name of User
        /// </summary>
        [Required]
        public string? displayName { get; set; }

        /// <summary>
        /// Phone Number of user
        /// </summary>
        public string? phone { get; set; }

        /// <summary>
        /// Adress of user
        /// </summary>
        public string? address { get; set; }

        /// <summary>
        /// Language of user
        /// </summary>
        public List<string>? language { get; set; }

        /// <summary>
        /// Job of user
        /// </summary>
        public string? job { get; set; }

        /// <summary>
        /// Age of user
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// Email of user
        /// </summary>
        public string? email { get; set; }


        /// <summary>
        /// Linkedin Adress
        /// </summary>
        public string? linkedinAdress { get; set; }


        /// <summary>
        /// About
        /// </summary>
        public string? about { get; set; }
        
    }
}
