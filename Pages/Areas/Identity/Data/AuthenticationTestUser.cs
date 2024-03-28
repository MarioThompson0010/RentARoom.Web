using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationTest.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AuthenticationTestUser class
public class AuthenticationTestUser : IdentityUser
{
	int debug = 0;
}

