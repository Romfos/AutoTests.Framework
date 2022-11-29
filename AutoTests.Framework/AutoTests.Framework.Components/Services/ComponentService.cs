namespace AutoTests.Framework.Components.Services;

    public class ComponentService
    {
        private readonly NestedComponentsService nestedComponentsService;
        private readonly ComponentStaticResourceService componentStaticResourceService;
        private readonly ComponentContentAttributeService componentContentAttributeService;

        public ComponentService(
            NestedComponentsService nestedComponentsService, 
            ComponentStaticResourceService componentStaticResourceService,
            ComponentContentAttributeService componentContentAttributeService)
        {
            this.nestedComponentsService = nestedComponentsService;
            this.componentStaticResourceService = componentStaticResourceService;
            this.componentContentAttributeService = componentContentAttributeService;
        }

        public virtual void InitializeComponent(Component component)
        {
            nestedComponentsService.InitializeComponent(component);
            componentStaticResourceService.InitializeComponent(component);
            componentContentAttributeService.InitializeComponent(component);
        }
    }
