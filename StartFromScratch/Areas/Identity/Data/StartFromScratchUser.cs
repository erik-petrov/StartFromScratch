using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StartFromScratch.Areas.Identity.Data;

// Add profile data for application users by adding properties to the StartFromScratchUser class
public class StartFromScratchUser : IdentityUser
{
    [PersonalData]
    public string? FullName { get; set; }
    [PersonalData]
    public DateTime RegisterDate { get; set; }
}

