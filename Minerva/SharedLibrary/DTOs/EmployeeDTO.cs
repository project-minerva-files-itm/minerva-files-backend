﻿using SharedLibrary.Entities;
using SharedLibrary.Resources;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }

    [Display(Name = "FirstName", ResourceType = typeof(Literals))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName", ResourceType = typeof(Literals))]
    [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email", ResourceType = typeof(Literals))]
    [MaxLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Literals))]
    public string Email { get; set; } = null!;

    [Display(Name = "PhoneNumber", ResourceType = typeof(Literals))]
    [MaxLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    [Phone(ErrorMessageResourceName = "InvalidPhone", ErrorMessageResourceType = typeof(Literals))]
    public string PhoneNumber { get; set; } = null!;

    [Display(Name = "User", ResourceType = typeof(Literals))]
    [MaxLength(450, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string UserId { get; set; } = null!;

    [Display(Name = "Department", ResourceType = typeof(Literals))]
    [Range(1, int.MaxValue, ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public int DepartmentId { get; set; }

    [Display(Name = "Position", ResourceType = typeof(Literals))]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Position { get; set; } = null!;

    [Display(Name = "HireDate", ResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public DateTime HireDate { get; set; }
}