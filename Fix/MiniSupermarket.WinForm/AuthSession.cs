namespace MiniSupermarket.WinForms
{
    public static class AuthSession
    {
        public static string Token { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static string Username { get; set; } = string.Empty;
    }
}