namespace users{
    public class UserInfo { 
        public int UserInfoId { get; set; }
        public string CompanyName { get; set; }
        public string Region { get; set; }
        public string Shehia { get; set; }
        public string Address { get; set; }

        public int UserLoginId { get; set; }
        public UserLogin UserLogin { get; set; }
     }
}