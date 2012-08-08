#SignalR.StructureMap 

---

Install it from the nuget package.
Register the Resolver with structuremap.


###Register the resolver directly like
	
	ObjectFactory.Initialize(cfg => {
		cfg.For<IDependencyResolver>().Singleton().Add<StructureMapDependencyResolver>();
	});

###OR Build a registry like

	public class SignalRRegistry : Registry
    {
        public SignalRRegistry()
        {
            For<IDependencyResolver>().Singleton().Add<StructureMapDependencyResolver>();
        }

        public void Configure()
        {
            GlobalHost.DependencyResolver = ObjectFactory.GetInstance<IDependencyResolver>();
            RouteTable.Routes.MapHubs();
        }
    }

Just make sure that the configure call comes in your application_start or where you call that in asp.net mvc, or it will explode.
This has been tested and known working in fubumvc, as long as you call the configure after fubu bootstraps.

