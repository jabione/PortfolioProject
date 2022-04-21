using System.ComponentModel.DataAnnotations;

namespace PortfolioProject.Models
{
    /// <summary>
    /// UserContact Model
    /// </summary>
    public class UserContact
    {
        /// <summary>
        /// First Name of Contact
        /// </summary>
        [Required]
        public string? firstName { get; set; }

        /// <summary>
        ///  Last Name of Contact
        /// </summary>
        public string? lastName { get; set; }

        /// <summary>
        /// Email of Contact
        /// </summary>
        public string? email { get; set; }

        /// <summary>
        /// Message of Contact
        /// </summary>
        public string? message { get; set; }

    }
}
