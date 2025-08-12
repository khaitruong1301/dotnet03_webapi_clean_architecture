using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);


//add service blazor 
//Service của blazor server app
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Add service http client
// builder.Services.AddHttpClient();
builder.Services.AddHttpClient("EbayAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5016/api/"); //địa chỉ api
});
//Add service blazor storage

builder.Services.AddBlazoredLocalStorage(); //lưu trữ local



var app = builder.Build();


app.UseHttpsRedirection(); //kích hoạt https
app.UseRouting(); // để chia các component thành @page ...
app.UseStaticFiles(); // wwwroot thư mục chưa tài nguyên

//Sử dụng middleware của blazor map file host để làm file chạy đầu tiên
app.MapBlazorHub(); 
app.MapFallbackToPage("/_Host");
 

app.Run();
