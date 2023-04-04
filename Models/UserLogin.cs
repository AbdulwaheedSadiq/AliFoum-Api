namespace users{
    public class UserLogin { 
        
        public int UserLoginId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string Status { get; set; }

        public List<UserInfo> UserInfo { get; set; }

    }
}