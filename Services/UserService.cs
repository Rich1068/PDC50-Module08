using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module08.Services;
using System.Net.Http.Json;
using Module08.Model;


namespace Module08.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost/pdc50/"; 
        public UserService() 
        { 
            _httpClient = new HttpClient();
        }
        //GetFromJsonAsync - Method for HTTP get
        //PostAsJsonAsync - Method for HTTP post
        //ReadAsStringAsync - Method to read the content of HTTPContent


        //Get User
        public async Task<List<User>> GetUserAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<User>>($"{BaseUrl}get_user.php");
            return response ?? new List<User>();
        }

        //Add User
        public async Task<string> AddUserAsync(User user)
        {            
            var response = 
                await _httpClient.PostAsJsonAsync($"{BaseUrl}add_user.php", user);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        //Update User
        public async Task<string> UpdateUserAsync(User user)
        {
            var response =
                await _httpClient.PostAsJsonAsync($"{BaseUrl}update_user.php", user);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> DeleteUserAsync(int userId)
        {
            var response =
                await _httpClient.PostAsJsonAsync($"{BaseUrl}delete_user.php", new { id = userId });
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }


    }
}
