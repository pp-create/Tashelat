using DAL.Database;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _userService;

        public DataSeeder(ApplicationDbContext userService)
        {
            _userService = userService;
        }

        public async Task SeedDataAsync()
        {
            Users obj = new Users();
            obj.password = "1234";
            obj.UserName = "Zaid";
            obj.RoleId = 1;
            obj.Email = "Zaid.com";
            obj.phone = 11;
            obj.RoleName = "مدير";
            var data = await _userService.User.FirstOrDefaultAsync(x => x.UserName == "Zaid" && x.password == "1234");
            if (data==null)
            {
                await _userService.User.AddAsync(obj);
                await _userService.SaveChangesAsync();
            }

         
        }
    }
}
