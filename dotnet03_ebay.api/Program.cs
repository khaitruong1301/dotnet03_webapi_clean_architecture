using System.Security.Claims;
using System.Text;
using dotnet03_ebay.Infrastructure.Models;
using EbayProject.Api.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// service EF
var connectionString = builder.Configuration.GetConnectionString("connectionStringEbay");
builder.Services.AddDbContext<EbayContext>(options =>
    options.UseSqlServer(connectionString));


//DI Repository 
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IConnectionCountLogRepository, ConnectionCountLogRepository>();
builder.Services.AddScoped<IEbayProductRepository, EbayProductRepository>();
builder.Services.AddScoped<IGetListOrderDetailByOrderIdRepository, GetListOrderDetailByOrderIdRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();
builder.Services.AddScoped<ILoginLogRepository, LoginLogRepository>();
builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderby2024Repository, Orderby2024Repository>();
builder.Services.AddScoped<IOrderby2025Repository, Orderby2025Repository>();
builder.Services.AddScoped<IOrdersBy2025Repository, OrdersBy2025Repository>();
builder.Services.AddScoped<IPhongBanRepository, PhongBanRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductListCategoryRepository, ProductListCategoryRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//DI Service
builder.Services.AddScoped<IUserService, UserService>();


//Sử dụng map controller 
builder.Services.AddControllers();
//Swagger cấu hình có điền Authentication
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ebay API", Version = "v1" });

    // 🔥 Thêm hỗ trợ Authorization header tất cả api
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập token vào ô bên dưới theo định dạng: Bearer {token}"
    });

    // 🔥 Định nghĩa yêu cầu sử dụng Authorization trên từng api
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


//Add service cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:5016","http://localhost:5254")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

//Cài đặt Jwt Bearer Authentication
//Thêm middleware authentication
var privateKey = builder.Configuration["jwt:Serect-Key"];
var Issuer = builder.Configuration["jwt:Issuer"];
var Audience = builder.Configuration["jwt:Audience"];
// Thêm dịch vụ Authentication vào ứng dụng, sử dụng JWT Bearer làm phương thức xác thực
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // Thiết lập các tham số xác thực token
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        // Kiểm tra và xác nhận Issuer (nguồn phát hành token)
        ValidateIssuer = true,
        ValidIssuer = Issuer, // Biến `Issuer` chứa giá trị của Issuer hợp lệ
                              // Kiểm tra và xác nhận Audience (đối tượng nhận token)
        ValidateAudience = true,
        ValidAudience = Audience, // Biến `Audience` chứa giá trị của Audience hợp lệ
                                  // Kiểm tra và xác nhận khóa bí mật được sử dụng để ký token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
        // Sử dụng khóa bí mật (`privateKey`) để tạo SymmetricSecurityKey nhằm xác thực chữ ký của token
        // Giảm độ trễ (skew time) của token xuống 0, đảm bảo token hết hạn chính xác
        ClockSkew = TimeSpan.Zero,
        // Xác định claim chứa vai trò của user (để phân quyền)
        RoleClaimType = ClaimTypes.Role,
        // Xác định claim chứa tên của user
        NameClaimType = ClaimTypes.Name,
        // Kiểm tra thời gian hết hạn của token, không cho phép sử dụng token hết hạn
        ValidateLifetime = true
    };
});


//Khai báo jwt auth service
builder.Services.AddScoped<JwtAuthService>();




var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

//sử dụng middleware authentication
app.UseAuthentication();
app.UseAuthorization();



//use middle ware controller
app.MapControllers();
//use swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
