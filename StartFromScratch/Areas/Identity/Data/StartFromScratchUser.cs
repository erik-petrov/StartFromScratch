using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StartFromScratch.Models;

namespace StartFromScratch.Areas.Identity.Data;

public class StartFromScratchUser : IdentityUser
{
    [PersonalData]
    public string? FullName { get; set; }
    [PersonalData]
    public DateTime RegisterDate { get; set; } = DateTime.Now;
    public List<Buy> Bought { get; set; } = new List<Buy>();
    public List<Rent> Rented { get; set; } = new List<Rent>();
}

