public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void OtherInitialize() =>
        VerifierSettings.InitializePlugins();
}