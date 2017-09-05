﻿using Autofac.Extras.IocManager;

using Stove.Bootstrapping;
using Stove.Reflection.Extensions;
using Stove.Runtime.Session;

namespace Stove.TestBase
{
	public abstract class ApplicationTestBase<TStarterBootstrapper> : TestBaseWithLocalIocResolver
		where TStarterBootstrapper : StoveBootstrapper
	{
		protected ApplicationTestBase(bool autoUnitOfWorkInterceptionEnabled = false)
		{
			Building(builder =>
			{
				builder
					.UseStoveWithNullables<TStarterBootstrapper>(autoUnitOfWorkInterceptionEnabled);

				builder.RegisterServices(r => r.RegisterAssemblyByConvention(typeof(TestBaseWithLocalIocResolver).GetAssembly()));
				builder.RegisterServices(r => r.Register<IStoveSession, TestStoveSession>(Lifetime.Singleton));
			});
		}

		protected TestStoveSession StoveSession => The<TestStoveSession>();

		protected override void PreBuild()
		{
		}

		protected override void PostBuild()
		{
		}
	}
}
