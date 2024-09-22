using System;
using System.Collections.Generic;

namespace Webapi.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EnrollmentNumber { get; set; } = null!;

    public string Course { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public decimal Gpa { get; set; }

    public bool IsActive { get; set; }
}
