using System;
using System.Collections.Generic;

namespace AMIProjectAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Status { get; set; }
}
