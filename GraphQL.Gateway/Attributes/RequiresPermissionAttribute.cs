﻿using System;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types;
using System.Reflection;
using HotChocolate;

namespace GraphQL.Gateway.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequiresPermissionAttribute : Attribute
    {
        public string Permission { get; }

        public RequiresPermissionAttribute(string permission)
        {
            Permission = permission;
        }
    }

    public class UseRequiresPermissionAttribute : ObjectFieldDescriptorAttribute
    {
        protected override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            var permissionAttributes = member.GetCustomAttributes<RequiresPermissionAttribute>(true);

            foreach (var attribute in permissionAttributes)
            {
                descriptor.Extend().Definition.ContextData["RequiredPermission"] = attribute.Permission;
            }

            descriptor.Extend().Definition.ContextData["RequiresAuthorization"] = true;
        }
    }
}