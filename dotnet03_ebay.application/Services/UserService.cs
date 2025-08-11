//Service sẽ tạo theo danh mục chức năng (Không tạo theo table database)

using dotnet03_ebay.Infrastructure.Models;
using EbayProject.Api.Helpers;

public interface IUserService
{
    public Task<string> Login(UserLoginDTO model);
    public Task<bool> RegisterBuyer(UserBuyerRegister model);
    public Task<bool> RegisterSeller(UserSellerRegister model);
}

public class UserService : IUserService
{
    public IUserRepository _userRepo;
    public IUserRoleRepository _userRoleRepo;
    IUnitOfWork _dbu;
    JwtAuthService _jwtAuthService;
    // public IUserRepository _userRepo;

    EbayContext _context;
    public UserService(IUserRepository userRepo, IUserRoleRepository userRoleRepo, IUnitOfWork dbu, JwtAuthService jwtAuthService)
    {
        _userRepo = userRepo;
        _userRoleRepo = userRoleRepo;
        _dbu = dbu;
        _jwtAuthService = jwtAuthService;
    }
    public async Task<string> Login(UserLoginDTO model)
    {
        try
        {
            var user = await _userRepo.SingleOrDefaultAsync(us => us.Email == model.UsernameOrEmail || us.Username == model.UsernameOrEmail);
            if (user == null)
            {
                return MessageLogin.UserNotFound; // Người dùng không tồn tại        
            }

            //Nếu user tồn tại thì kiểm tra mật khẩu
            if (PasswordHelper.VerifyPassword(model.Password, user.PasswordHash))
            {
                //Trả về access token 
                return _jwtAuthService.GenerateToken(user);
            }
            return MessageLogin.PasswordIncorrect;
        }
        catch (Exception ex)
        {
            // Xử lý lỗi nếu cần
            return MessageLogin.ErrorInServer;
        }
    }
    
    public async Task<bool> RegisterBuyer(UserBuyerRegister model)
    {
        try
        {
            //Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = await _userRepo.SingleOrDefaultAsync(us => us.Email == model.email || us.Username == model.userName);
            if (existingUser != null)
            {
                return false; // Người dùng đã tồn tại
            }

            //thêm user vào bảng user và thêm role vào bảng userrole
            User user = new User();
            user.Username = model.userName;
            user.Email = model.email;
            user.PasswordHash = PasswordHelper.HashPassword(model.password);
            user.FullName = model.fullName;
            //thêm role vào bảng user role
            UserRole usRole = new UserRole();
            usRole.UserId = user.Id;
            usRole.RoleId = model.getRoleId();
            //add bảng tham chiếu 
            user.UserRoles.Add(usRole);
            //thêm user vào bảng user
            await _userRepo.AddAsync(user);
            await _dbu.SaveChangesAsync();
            return true;
        }
        catch (Exception err)
        {
            return false;
        }
    }

    public async Task<bool> RegisterSeller(UserSellerRegister model)
    {
        try
        {
            //Kiểm tra xem người dùng đã tồn tại chưa
            var existingUser = await _userRepo.SingleOrDefaultAsync(us => us.Email == model.email || us.Username == model.userName);
            if (existingUser != null)
            {
                return false; // Người dùng đã tồn tại
            }
            //thêm user vào bảng user và thêm role vào bảng userrole
            User user = new User();
            user.Username = model.userName;
            user.Email = model.email;
            user.PasswordHash = PasswordHelper.HashPassword(model.password);
            user.FullName = model.fullName;
            user.CreatedAt = DateTime.Now;
            user.Deleted = false;
            //thêm role vào bảng user role
            UserRole usRole = new UserRole();
            usRole.UserId = user.Id;
            usRole.RoleId = model.getRoleId();
            //add bảng tham chiếu 
            user.UserRoles.Add(usRole);
            await _userRepo.AddAsync(user);
            await _dbu.SaveChangesAsync();
            return true;
        }
        catch (Exception err)
        {
            return false;
        }
    }
}