using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DI_Autofac_Test
{
	public static class TypeExtensions
	{
		public static Type GetGenericInterfaceType(this Type source, Type expectedGenericInterfaceType)
		{
			return source.GetInterfaces()
				.First(
					interfaceItem => interfaceItem.IsGenericType
					&& interfaceItem.GetGenericTypeDefinition().Equals(expectedGenericInterfaceType)
				);
		}

		public static List<Type> GetTypesWithGenericInterfacesInAssemblies(this Type source, params Assembly[] assemblies)
		{
			if (assemblies == null || assemblies.Length == 0) { throw new Exception(); }

			return assemblies
				.SelectMany(currentAssembly => currentAssembly.GetTypes()
				.Where(type => type.GetInterfaces().Any(
					interfaceItem => interfaceItem.IsGenericType
					&& interfaceItem.GetGenericTypeDefinition().Equals(source))))
				.ToList();
		}
	}
}
