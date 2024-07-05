using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.Auth;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<UserApp> _userManager;

        public UsersController(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<UserApp>> GetAll()
        {
            var result = await _userManager.Users.ToListAsync();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<UserApp> GetById(long id)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new Exception();

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UserApp user)
        {
            var model = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (model == null)
                throw new Exception();

            model.FullName = user.FullName;
            model.Birth = user.Birth;
            model.Gender = user.Gender;
            model.ProfilePhoto = user.ProfilePhoto;
            model.PhoneNumber = user.PhoneNumber;
            model.Addresses = user.Addresses;
            model.Cart = user.Cart;
            model.Favorite = user.Favorite;
            model.Cards = user.Cards;
            model.Role = user.Role;

            await _userManager.UpdateAsync(model);

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "User Updated Successfully",
                StatusCode = 201,
            };
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(long id)
        {
            var model = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                throw new Exception();

            await _userManager.DeleteAsync(model);

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "User Deleted Successfully",
                StatusCode = 201,
            };
        }
    }
}
