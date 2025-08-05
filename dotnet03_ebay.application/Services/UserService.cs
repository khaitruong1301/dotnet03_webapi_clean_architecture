//Service sẽ tạo theo danh mục chức năng (Không tạo theo table database)

using dotnet03_ebay.Infrastructure.Models;

public interface IUserService
{
    public Task<bool> Login(UserLoginDTO model);
    public Task<bool> RegisterBuyer(UserBuyerRegister model);
}

public class UserService : IUserService
{
    public IUserRepository _userRepo;
    public IUserRoleRepository _userRoleRepo;
    IUnitOfWork _dbu;
    // public IUserRepository _userRepo;

    public UserService(IUserRepository userRepo, IUserRoleRepository userRoleRepo, IUnitOfWork dbu)
    {
        _userRepo = userRepo;
        _userRoleRepo = userRoleRepo;
        _dbu = dbu;
    }
    public Task<bool> Login(UserLoginDTO model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterBuyer(UserBuyerRegister model)
    {
        try
        {
            //thêm user vào bảng user và thêm role vào bảng userrole
            User user = new User();
            user.Username = model.userName;
            user.Email = model.email;
            user.PasswordHash = model.password;
            user.FullName = model.fullName;
            //thêm role vào bảng user role
            UserRole usRole = new UserRole();
            usRole.UserId = user.Id;
            usRole.RoleId = model.getRoleId();
            //add bảng tham chiếu 
            user.UserRoles.Add(usRole);
            await _dbu.SaveChangesAsync();
            return true;
        }
        catch (Exception err)
        {
            return false;
        }
    }
}