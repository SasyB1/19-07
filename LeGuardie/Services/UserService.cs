using LeGuardie.Models.Dto;
using LeGuardie.Services.Dao;
using Microsoft.Data.SqlClient;

namespace LeGuardie.Services
{
    public class UserService
    {
        private readonly IConfiguration _config;
        private readonly UserDao _userDao;

        public UserService(IConfiguration config,UserDao userDao )
        {
            _config = config;
            _userDao = userDao;
        }
        public List<AnagraficaDto> GetUsers()
        {
            return _userDao.GetUsers();
        }

        public void RegisterUser(AnagraficaDto user)
        {
            _userDao.RegisterUser(user);
        }
    }
} 
