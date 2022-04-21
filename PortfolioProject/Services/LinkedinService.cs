using Newtonsoft.Json;
using PortfolioProject.IServices;
using PortfolioProject.Models;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace PortfolioProject.Services
{
    /// <summary>
    /// Linkedin Service 
    /// </summary>
    public class LinkedinService : ILinkedinService<LinkedinService>
    {

        #region variables

        //Http client
        private readonly HttpClient _client;
        //Connection parameters
        private readonly string _key;
        private readonly string _urlApiLinkedin;
        private readonly string _endpointUsers;
        private readonly string _endpointAbout;
        private readonly string _endpointContact;

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LinkedinService(IConfiguration config)
        {
            //Connection values
            _urlApiLinkedin = config.GetValue<string>("LinkedinApi:UrlApiLinkedin");
            _key = config.GetValue<string>("LinkedinApi:Key");
            _endpointUsers = config.GetValue<string>("LinkedinApi:EnpointUsers");
            _endpointAbout = config.GetValue<string>("LinkedinApi:EnpointAbout");
            _endpointContact = config.GetValue<string>("LinkedinApi:EnpointContact");

            // Instance New http client
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Api-Key", _key);
        }

        /// <summary>
        /// Get user infos by email
        /// </summary>
        /// <param name="email">email of user</param>
        /// <returns>user object</returns>
        public async Task<User> GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                // Connexion to Linkedin API to get data
                var result = await _client.GetAsync(_urlApiLinkedin + _endpointUsers);

                //Check the statuts code
                if (!result.IsSuccessStatusCode)
                    throw new Exception(this.MessageException(result.StatusCode.ToString()));

                //Read the result
                string resultContent = await result.Content.ReadAsStringAsync();

                //Convert Json data to User Object
                var userObj = JsonConvert.DeserializeObject<User>(resultContent);

                //check if the obj is not null
                if (userObj != null)
                {
                    user = userObj;
                    // convert country code to name
                    if (user.language != null && user.language.Count > 0)
                    {
                        List<string> lg = user.language.FirstOrDefault().Split(',').ToList();
                        string language = "";
                        foreach (var item in lg)
                        {
                            var lang = new CultureInfo(item.Trim() + "-" + item.Trim().ToUpper());
                            language = language + lang.EnglishName + ", ";
                            string regex = "(\\(.*\\))";
                            language = Regex.Replace(language, regex, "");
                        }
                        language = language.Remove(language.Length - 2);
                        user.language.Clear();
                        user.language.Add(language);
                    }
                }
                else
                    throw new Exception("User is not exist !");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return user;
        }


        /// <summary>
        /// Get About Infos of User by email
        /// </summary>
        /// <param name="email">email of user</param>
        /// <returns>user object</returns>
        public async Task<User> GetAboutUserByEmail(string email)
        {
            User user = null;

            try
            {
                // Connexion to Linkedin API to get data
                var result = await _client.GetAsync(_urlApiLinkedin + _endpointAbout);

                //Check the statuts code
                if (!result.IsSuccessStatusCode)
                    throw new Exception(this.MessageException(result.StatusCode.ToString()));

                //Read the result
                string resultContent = await result.Content.ReadAsStringAsync();

                //Convert Json data to User Object
                var userObj = JsonConvert.DeserializeObject<User>(resultContent);

                //check if the obj is not null
                if (userObj != null)
                    user = userObj;
                else
                    throw new Exception("User is not exist !");
            }
            catch (Exception ex)
            {
                return null;
            }

            return user;
        }


        /// <summary>
        /// Post Contact
        /// </summary>
        /// <param name="cotent">UserContact object </param>
        /// <returns>True if Post is successful else false</returns> 
        public async Task<bool> PostContactByEmail(UserContact userContact)
        {
            bool result = false;
            try
            {
                //Convert UserContact object to httpContent
                string jsonContact = JsonConvert.SerializeObject(userContact);
                HttpContent cotent = new StringContent(jsonContact, Encoding.UTF8, "application/json");

                // Connexion vers l'API Linkedin Post Method

                HttpResponseMessage request = await _client.PostAsync(_urlApiLinkedin + _endpointContact, cotent);

                if (!request.IsSuccessStatusCode)
                    throw new Exception(this.MessageException(request.StatusCode.ToString()));
                else result = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error !" + ex.Message);
            }

            return result;
        }



        /// <summary>
        /// Method to return Exception Message Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string MessageException(string code)
        {
            string messageEx = string.Empty;
            switch (code)
            {
                case "400":
                    messageEx = "Header is missing or Empty";
                    break;

                case "401":
                    messageEx = "Header is missing or Empty";

                    break;
                case "404":
                    messageEx = "Email was not found or does not exists";
                    break;
                case "500":
                    messageEx = "Service unavailable";
                    break;

            }
            return messageEx;
        }
    }
}
