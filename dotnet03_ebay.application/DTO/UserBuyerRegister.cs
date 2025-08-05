public class UserBuyerRegister
{
    public string userName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string fullName { get; set; }
    private int roleId = RoleTypeConst.Buyer ;

    public int getRoleId()
    {
        return roleId;
    }


}