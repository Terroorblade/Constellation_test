using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Fivesemtest.Models;

public partial class User
{
    public string? IdentityUserId {get; set;}

    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? Birthday { get; set; }
    

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<DailySchedule> DailySchedules { get; set; } = new List<DailySchedule>();

    public virtual ICollection<UserSphereSatisfaction> UserSphereSatisfactions { get; set; } = new List<UserSphereSatisfaction>();
}
