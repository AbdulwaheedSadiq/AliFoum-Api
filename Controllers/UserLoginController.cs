using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repo.Data;

namespace users{
    [ApiController]
    [Route("Api/UserLogin")]
    public class UserLoginController : ControllerBase{ 
        private readonly ApplicationDbContext dbContextRepo;
        
        public UserLoginController(ApplicationDbContext dbContext) {
            dbContextRepo = dbContext;
        }


[HttpGet]
        public ActionResult<List<UserLoginDto>> get() { 
            
            try{
                List<UserLogin> users = dbContextRepo.userLogins.ToList();

                List<UserLoginDto> response = new List<UserLoginDto>();
                foreach(UserLogin u in users){
                    UserLoginDto res = new UserLoginDto();
                    res.Fullname = u.Fullname;
                    res.Email = u.Email;
                    res.Phonenumber = u.Phonenumber;
                    res.Role = u.Role;
                    res.Username = u.Username;
                    res.Status = u.Status;
                    response.Add(res);
                }
                return(response);
            }catch(Exception){
                return StatusCode(500,"Ooops Something Whet Wrong");
            }
         }


         [HttpPost]
         public ActionResult<UserLoginDto> insert(UserLoginDto user) { 
            
            try {
                UserLogin u = new UserLogin();
                u.Fullname = user.Fullname;
                u.Email = user.Email;
                u.Phonenumber = user.Phonenumber;
                u.Role = user.Role;
                u.Password = user.Password;
                u.Username = user.Username;
                u.Status = user.Status;

                dbContextRepo.userLogins.Add(u);
                dbContextRepo.SaveChanges();


                UserLoginDto dto = new UserLoginDto();
                 dto.Fullname = u.Fullname;
                dto.Email = u.Email;
                dto.Phonenumber = u.Phonenumber;
                dto.Role = u.Role;
                dto.Password = "Not Allowed";
                dto.Username = u.Username;
                dto.Status = u.Status;
                return Ok(dto);
            }catch(Exception){
                return StatusCode(500,"Oops..SomeThng is wrong");
            }
          }

          [HttpGet("{id}")]
          public ActionResult<UserLoginDto> getById(int id) { 
            try{
                var user = dbContextRepo.userLogins.FirstOrDefault(x=> x.UserLoginId == id);
                if(user == null){
                   return StatusCode(404,"User is not found");
                }

                UserLoginDto dto = new UserLoginDto();
                 dto.Fullname = user.Fullname;
                dto.Email = user.Email;
                dto.Phonenumber = user.Phonenumber;
                dto.Role = user.Role;
                dto.Password = "Not Allowed";
                dto.Username = user.Username;
                dto.Status = user.Status;

                return  Ok(dto);
            }catch(Exception){
                return StatusCode(500,"Ooops Something is wrong");
            }

           }

           [HttpPut("{id}")]
         public ActionResult<UserLoginDto> update(int id, UserLoginDto user) {
             try{
                var u = dbContextRepo.userLogins.FirstOrDefault(x=> x.UserLoginId == id);
                if(u == null){
                    return StatusCode(404,"User is not found");
                }

                u.Fullname = user.Fullname;
                u.Email = user.Email;
                u.Phonenumber = user.Phonenumber;
                u.Role = user.Role;
                u.Password = user.Password;
                u.Username = user.Username;
                u.Status = user.Status;

                dbContextRepo.Entry(u).State = EntityState.Modified;
                dbContextRepo.SaveChanges();


                UserLoginDto dto = new UserLoginDto();
                 dto.Fullname = user.Fullname;
                dto.Email = user.Email;
                dto.Phonenumber = user.Phonenumber;
                dto.Role = user.Role;
                dto.Password = "Not Allowed";
                dto.Username = user.Username;
                dto.Status = user.Status;

                return  Ok(dto);
            }catch(Exception){
                return StatusCode(500,"Ooops Something is wrong");
            }

          }
     }
}