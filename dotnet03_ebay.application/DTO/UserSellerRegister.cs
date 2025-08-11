public class UserSellerRegister
{
    public string userName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string fullName { get; set; }
    private int roleId = RoleTypeConst.Seller ;

    public int getRoleId()
    {
        return roleId;
    }


}