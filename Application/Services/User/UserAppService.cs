using Application.Contract.Common;
using Application.Contract.Criteria.Users;
using Application.Contract.Exceptions;
using Application.Contract.Model.Common;
using Application.Contract.Model.Users;
using Application.Logging;
using Application.Repository.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly string seviceName = nameof(UserAppService);
        private readonly IUserRepository _userRepository;
        private readonly JwTOption _options;


        public UserAppService(IMapper mapper,
            UserManager<Entities.User> userManager, 
            IHttpContextAccessor httpContextAccessor, 
            JwTOption options,
            IUserRepository userRepository)
            :base(mapper, userManager, httpContextAccessor)
        {
            _options = options;
            _userRepository = userRepository;

        }
        public async Task<JwTAuthRepsonseModel> LoginAsync(HttpContext context)
        {
            using(var stream = new StreamReader(context.Request.Body))
            {
                var body = await stream.ReadToEndAsync();
                if (!string.IsNullOrEmpty(body))
                {
                    var authRequest = JsonConvert.DeserializeObject<JwTAuthRequestModel>(body);
                    if(authRequest != null)
                    {
                        ClaimsIdentity identity = await GetIdentityAsync(authRequest.UserName, authRequest.Password);
                        if(identity != null)
                        {
                            return GenerateToken(identity);
                        }
                    }
                }
            }
            throw new LoginInvalidException();
        }
        public async Task<UserResponseModel> CreateAsync(CreateUserRequestModel createUserRequestModel)
        {
            const string actionName = nameof(CreateAsync);

            createUserRequestModel = createUserRequestModel ?? throw new ArgumentException(nameof(createUserRequestModel));

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, createUserRequestModel);
            var user = _Mapper.Map<Entities.User>(createUserRequestModel);

            var userResult = await _userManager.CreateAsync(user, createUserRequestModel.Password);
            if (userResult.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, createUserRequestModel.Role.ToString());
                if (!roleResult.Succeeded)
                {
                    await _userManager.DeleteAsync(user);
                    throw new InvalidDataException(nameof(createUserRequestModel));
                }

                Logger.LogInfomation(LoggingMessage.ActionSuccessfullyWithoutModel, actionName, seviceName);

                return _Mapper.Map<UserResponseModel>(user);
            }
            string errors = GetErrorResult(userResult.Errors);
            throw new InvalidDataException(errors);
        }
        private string GetErrorResult(IEnumerable<IdentityError> errors)
        {
            var builder = new StringBuilder();
            foreach (var error in errors)
            {
                builder.Append(error.Description);
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }

        public async Task DeleteAsync(int id)
        {
            const string actionName = nameof(DeleteAsync);

            if(CurrentUser.Id == id)
            {
                throw new SelfDeleteException();
            }

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, id);
            var user = await _userRepository.GetAsync(id);
            await _userManager.DeleteAsync(user);
            Logger.LogDebug(LoggingMessage.ProcessingInServiceSuccessfully , actionName, seviceName);

        }
        public async Task<PageResultData<UserResponseModel>> SearchAsync(UserCriteria criteria)
        {
            const string actionName = nameof(SearchAsync);

            criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, criteria);
            var response = await _userRepository.SearchAsync(criteria);
            Logger.LogInfomation(LoggingMessage.ActionSuccessfullyWithoutModel, actionName, seviceName);

            return _Mapper.Map<PageResultData<UserResponseModel>>(response);
        }

        public async Task<UserResponseModel> UpdateAsync(int id, UpdateUserRequestModel updateUserRequestModel)
        {
            const string actionName = nameof(UpdateAsync);

            updateUserRequestModel = updateUserRequestModel ?? throw new ArgumentNullException(nameof(updateUserRequestModel));

            if(id != updateUserRequestModel.Id)
            {
                throw new InconsistentException(nameof(updateUserRequestModel));
            }

            Logger.LogDebug(LoggingMessage.ProcessingInService, actionName, seviceName, updateUserRequestModel);
            var user = await _userRepository.GetAsync(id);
            _Mapper.Map(updateUserRequestModel, user);
            var respone = await _userRepository.UpdateAsync(user, true);
            Logger.LogInfomation(LoggingMessage.ActionSuccessfully, actionName, seviceName, respone);

            return _Mapper.Map<UserResponseModel>(respone);

        }
        private async Task<ClaimsIdentity> GetIdentityAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            user = user ?? throw new LoginInvalidException();

            if (!_userManager.CheckPasswordAsync(user, password).Result)
            {
                throw new LoginInvalidException();
            }
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim("roles", string.Join(",", roles)));

            return await Task.FromResult(new ClaimsIdentity(claims));
        }
        private JwTAuthRepsonseModel GenerateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: identity.Claims,
                notBefore: now,
                expires: now.AddHours(8),
                signingCredentials: _options.SigningCredentials);

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new JwTAuthRepsonseModel()
            {
                AccessToken = encodeJwt,
                ExpireIn = jwt.ValidTo
            };

            return response;
        }
    }
}
