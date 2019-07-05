namespace TexTuto.API.Data{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context){
            this._context = context;
        }
        public async Task<User> Register(User user, string password){
             byte[] password_hash, password_salt;
             CreatePasswordHash(password, out password_hash, out password_salt);

             user.password_hash = password_hash;
             user.password_salt = password_salt;

             await _context.Users.AddAsync(user);
             await _context.SaveChangesAsync();

             return user;
        }

        private void CreatePasswordHash(string password, out byte[] password_hash, out byte[] password_salt){
            using(var hmac = new System.Security.Cryptography.HMACSHA256()) {
                password_salt = hmac.Key;
                password_hash = hmac.ComputeHas(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }
        public async Task<User> Login(string username, string password){
            var user = await _context.Users.FirstOrDefault(x=>x.username == username);

            if(user == null){
                return null;
            }

            if(!VerifyPasswordHash(password,user.password_hash,user.password_salt)){
                return null;
            }

            return user;
        }

        public async Task<bool> VerifyPasswordHash(string password, byte[] password_hash, byte[]  password_salt){
            using(var hmac = new System.Security.Cryptography.HMACSHA256(password_salt)) {
                var computedHash = hmac.ComputeHas(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0;i<computedHash.Length;i++){
                    if(computedHash[i] != password_hash[i]){
                        return false;
                    }
                }
            }
        }
        public async Task<bool> UserExists(string username){
            if(await _context.Users.AnyAsync(x=>x.username == username)){
                return true;
            }

            return false;
        }
    }
}