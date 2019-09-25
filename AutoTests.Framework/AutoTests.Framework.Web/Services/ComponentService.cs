namespace AutoTests.Framework.Web.Services
{
    public class ComponentService
    {
        private readonly NestedComponentsService nestedComponentsService;
        private readonly ComponentStaticResourceService componentStaticResourceService;

        public ComponentService(NestedComponentsService nestedComponentsService, ComponentStaticResourceService componentStaticResourceService)
        {
            this.nestedComponentsService = nestedComponentsService;
            this.componentStaticResourceService = componentStaticResourceService;
        }

        public virtual void InitializeComponent(Component component)
        {
            nestedComponentsService.InitializeComponent(component);
            componentStaticResourceService.InitializeComponent(component);
        }
    }
}
