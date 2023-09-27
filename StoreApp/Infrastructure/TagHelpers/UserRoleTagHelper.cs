using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
	[HtmlTargetElement("td", Attributes = "user-role")]
	public class UserRoleTagHelper : TagHelper
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		[HtmlAttributeName("user-name")]
        public String? UserName { get; set; }
        public UserRoleTagHelper(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var user = await _userManager.FindByNameAsync(UserName);
			var roles = _roleManager.Roles.ToList().Select(r=>r.Name);
			TagBuilder ul = new TagBuilder("ul");

			foreach (var role in roles)
			{
				TagBuilder li = new TagBuilder("li");
				li.InnerHtml.AppendHtml($"{ role} : {await _userManager.IsInRoleAsync(user, role)}");
				ul.InnerHtml.AppendHtml(li);
			}
			output.Content.AppendHtml(ul);
		}
	}
}
