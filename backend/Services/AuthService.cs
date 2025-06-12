using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MyntraCloneBackend.Data;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private static readonly ConcurrentDictionary<string, int> _sessions = new();

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Register(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
                return false;
            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password)
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public string Login(string username, string password)
        {
            var hash = HashPassword(password);
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);
            if (user == null) return null;
            var token = Guid.NewGuid().ToString();
            _sessions[token] = user.Id;
            return token;
        }

        public static int? GetUserId(string token)
        {
            return _sessions.TryGetValue(token, out var id) ? id : (int?)null;
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
