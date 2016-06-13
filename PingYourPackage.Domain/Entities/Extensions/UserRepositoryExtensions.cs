using System.Linq;

namespace PingYourPackage.Domain.Entities
{
    public static class UserRepositoryExtensions
    {
        public static User GetSingleByUserName(this IEntityRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Name == username);
        }
    }
}
