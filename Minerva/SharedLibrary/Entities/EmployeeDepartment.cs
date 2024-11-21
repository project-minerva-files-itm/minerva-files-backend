namespace SharedLibrary.Entities;

public class EmployeeDepartment
{
    public int Id { get; set; }
    public Employee Employee { get; set; } = null!;
    public int EmployeeId { get; set; }
    public Department Department { get; set; } = null!;
    public int DepartmentId { get; set; }
}