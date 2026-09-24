using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    // Lớp tĩnh quản lý thông tin phiên làm việc
    public static class SessionManager
    {
        public static string JwtToken { get; set; } = string.Empty;
        public static string UserRole { get; set; } = string.Empty; // Thống nhất dùng UserRole

        public static bool IsLoggedIn => !string.IsNullOrEmpty(JwtToken);

        public static void Logout()
        {
            JwtToken = string.Empty;
            UserRole = string.Empty;
        }
    }

    // Lớp dịch vụ hỗ trợ gọi Web API
    public static class ApiClientService
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7221/api/") // Nhớ chỉnh đúng cổng Port của API
        };

        // 1. Gọi API đăng nhập lấy Token
        public static async Task<bool> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await _client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);

                SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                SessionManager.UserRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;

                return true;
            }
            return false;
        }

        // 2. Gán Bearer Token vào Header trước mỗi request
        private static void SetAuthorizationHeader()
        {
            if (SessionManager.IsLoggedIn)
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
        }

        // 3. Hàm GET lấy dữ liệu chuyển sang Kiểu dữ liệu T (List, Object...)
        public static async Task<T?> GetAsync<T>(string endpoint)
        {
            SetAuthorizationHeader();
            var response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Phiên làm việc đã hết hạn hoặc bạn chưa đăng nhập!");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new Exception("Bạn không có quyền thực hiện chức năng này!");
            }

            throw new Exception($"Lỗi máy chủ API: {response.StatusCode}");
        }

        // 4. Các hàm POST, PUT, DELETE bổ sung (dành cho Thêm/Sửa/Xóa)
        public static async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
        {
            SetAuthorizationHeader();
            return await _client.PostAsJsonAsync(endpoint, data);
        }

        public static async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T data)
        {
            SetAuthorizationHeader();
            return await _client.PutAsJsonAsync(endpoint, data);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(string endpoint)
        {
            SetAuthorizationHeader();
            return await _client.DeleteAsync(endpoint);
        }
    }
}