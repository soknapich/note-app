using Microsoft.AspNetCore.Authorization;

namespace APIApplication.Policy
{
    public class DynamicRoleRequirement: IAuthorizationRequirement
    {
        public string ResourceKey { get; }
        public string ResourceController { get; }

        public DynamicRoleRequirement(string resourceKey, string resourceController)
        {
            ResourceKey = resourceKey;
            ResourceController = resourceController;
        }
    }
}
