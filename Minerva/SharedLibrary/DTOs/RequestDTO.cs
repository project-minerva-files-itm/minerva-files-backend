﻿using SharedLibrary.Resources;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.DTOs;

public class RequestDTO
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

    [Display(Name = "RequestType", ResourceType = typeof(Literals))]
    [MaxLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string RequestTypeId { get; set; } = null!;

    [Display(Name = "Subject", ResourceType = typeof(Literals))]
    [MaxLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Subject { get; set; } = null!;

    [Display(Name = "Description", ResourceType = typeof(Literals))]
    [MaxLength(500, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Literals))]
    [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Literals))]
    public string Description { get; set; } = null!;
}