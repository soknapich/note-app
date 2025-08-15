using APIApplication.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;

namespace APIApplication.Policy
{
    public class DynamicRoleHandler : AuthorizationHandler<DynamicRoleRequirement>
    {
        private readonly NoteDbContext _db;

        public DynamicRoleHandler(NoteDbContext db)
        {
            _db = db;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicRoleRequirement requirement)
        {
            var userRoles = context.User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

            // Get roles allowed for this resource
            var allowedRoles = _db.RolePermission
                .Where(p => (p.ResourceKey == requirement.ResourceKey && p.ResourceController == requirement.ResourceController) )
                .Select(p => p.Role.Name)
                .ToList();

            if (userRoles.Any(role => allowedRoles.Contains(role)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
