using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniEshop.Database.Entities;
using MiniEshop.Models;
using MiniEshop.Models.Actions;
using MiniEshop.Repositories.Interfaces;
using MiniEshop.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MiniEshop.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IMapper _mapper;

        public UserService(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,
            IShoppingCartRepository cartRepository,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUser request)
        {
            var entity = new User
            {
                Created = DateTime.UtcNow,
                Name = request.Name,
                Email = request.Email.ToLower(),
                PhoneNumber = request.PhoneNumber,
                Surname = request.Surname,
                Password = request.Password,
                IsAdministration = false,
            };

            await _userRepository.AddUserAsync(entity);

            if (!entity.IsAdministration) 
            {
                var cartEntity = new ShoppingCart
                {
                    IsActive = true,
                    User = entity
                };

                await _cartRepository.AddShoppingCartAsync(cartEntity);
            }
            

            
            

            var rq = _httpContextAccessor.HttpContext.Request;
            var user = _mapper.Map<UserDto>(entity);
            return new CreatedResult(new Uri($"{rq.Scheme}://{rq.Host}/api/users/{user.Id}"), user);
        }

        public async Task<ActionResult<UserDto>> GetUserInfo(int userId)
        {
            var entity = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserDto>(entity);
        }
    }
}
