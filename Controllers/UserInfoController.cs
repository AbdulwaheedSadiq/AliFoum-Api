using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repo.Data;

namespace users{
    [ApiController]
    [Route("Api/UserInfo")]
    public class UserInfoController : ControllerBase{ 
        private readonly ApplicationDbContext dbContextRepo;
        
        public  UserInfoController(ApplicationDbContext dbContext) { 
            dbContextRepo = dbContext;
        }

    [HttpGet]
        public ActionResult<List<UserInfoRes>> get() { 
            
            try{
                List<UserInfo> users = dbContextRepo.userInfos.ToList();

                List<UserInfoRes> response = new List<UserInfoRes>();
                foreach(UserInfo u in users){
                    UserInfoRes res = new UserInfoRes();
                    res.Address = u.Address;
                    res.CompanyName = u.CompanyName;
                    res.Region = u.Region;
                    res.Shehia = u.Shehia;
                    res.UserLogin = u.UserLogin;
                   
                    response.Add(res);
                }
                return(response);
            }catch(Exception){
                return StatusCode(500,"Ooops Something Whet Wrong");
            }
         }


         [HttpPost]
         public ActionResult<UserInfoRes> insert(UserInfoReq user) { 
            
            try {
                UserInfo u = new UserInfo();
                u.Address = user.Address;
                u.CompanyName = user.CompanyName;
                u.Region = user.Region;
                u.Shehia = user.Shehia;
                u.UserInfoId = user.UserLoginId;

                dbContextRepo.userInfos.Add(u);
                dbContextRepo.SaveChanges();

                    UserInfoRes res = new UserInfoRes();
                    res.Address = u.Address;
                    res.CompanyName = u.CompanyName;
                    res.Region = u.Region;
                    res.Shehia = u.Shehia;
                    res.UserLogin = u.UserLogin;
                return Ok(res);
            }catch(Exception){
                return StatusCode(500,"Oops..SomeThng is wrong");
            }
          }

          [HttpGet("{id}")]
          public ActionResult<UserInfoRes> getById(int id) { 
            try{
                var u = dbContextRepo.userInfos.FirstOrDefault(x=> x.UserInfoId == id);
                if(u == null){
                   return StatusCode(404,"User is not found");
                }

                UserInfoRes res = new UserInfoRes();
                    res.Address = u.Address;
                    res.CompanyName = u.CompanyName;
                    res.Region = u.Region;
                    res.Shehia = u.Shehia;
                    res.UserLogin = u.UserLogin;

                return  Ok(res);
            }catch(Exception){
                return StatusCode(500,"Ooops Something is wrong");
            }

           }

           [HttpPut("{id}")]
         public ActionResult<UserInfoRes> update(int id, UserInfoReq user) {
             try{
                var u = dbContextRepo.userInfos.FirstOrDefault(x=> x.UserInfoId == id);
                if(u == null){
                    return StatusCode(404,"User is not found");
                }

                 u.Address = user.Address;
                u.CompanyName = user.CompanyName;
                u.Region = user.Region;
                u.Shehia = user.Shehia;
                u.UserInfoId = user.UserLoginId;

                dbContextRepo.Entry(u).State = EntityState.Modified;
                dbContextRepo.SaveChanges();


                       UserInfoRes res = new UserInfoRes();
                    res.Address = u.Address;
                    res.CompanyName = u.CompanyName;
                    res.Region = u.Region;
                    res.Shehia = u.Shehia;
                    res.UserLogin = u.UserLogin;

                return  Ok(res);
            }catch(Exception){
                return StatusCode(500,"Ooops Something is wrong");
            }

          }
        

     }
}