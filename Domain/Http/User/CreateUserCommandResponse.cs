using CoNettion.Core.Enums;
using Domain.Entities.Common;
using Domain.Entities.Users;
using Domain.Http.Common;

namespace Domain.Http.User;

public class CreateUserCommandResponse : BaseClassResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public int RoleId { get; set; }
    public Guid ParentDepartmentId { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

}