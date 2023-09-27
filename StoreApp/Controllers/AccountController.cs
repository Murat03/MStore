﻿using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
		{
			return View(new LoginModel()
			{
				ReturnUrl = returnUrl
			});
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([FromForm]LoginModel model)
		{
			if(ModelState.IsValid)
			{
				ApplicationUser user = await _userManager.FindByNameAsync(model.Name);
				if (user is not null)
				{
					await _signInManager.SignOutAsync();
					if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
					{
						return Redirect(model?.ReturnUrl ?? "/");
					}
				}
				ModelState.AddModelError("Error", "Invalid username or password.");
			}
			return View();
		}
		public async Task<IActionResult> Logout([FromQuery(Name ="ReturnUrl")]string returnUrl = "/")
		{
			await _signInManager.SignOutAsync();
			return Redirect(returnUrl);
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
		{
			var user = new ApplicationUser()
			{
				UserName = registerDto.userName,
				Email = registerDto.Email
			};
			var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
				var roleResult = await _userManager.AddToRoleAsync(user, "User");
				if (roleResult.Succeeded)
				{
					return RedirectToAction("Login", new {ReturnUrl="/"});
				}
            }
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
            return View();
		}

		public IActionResult AccessDenied([FromQuery(Name ="ReturnUrl")] string returnUrl)
		{
			return View();
		}
	}
}
