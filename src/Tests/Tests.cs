public class ParametersHashSample
{
    #region HashParameters

    [Test]
    [Arguments("Value1")]
    [Arguments("Value2")]
    public Task HashParametersUsage(string arg)
    {
        var settings = new VerifySettings();
        settings.HashParameters();
        return Verify(arg, settings);
    }

    #endregion

    #region HashParametersFluent

    [Test]
    [Arguments("Value1")]
    [Arguments("Value2")]
    public Task HashParametersUsageFluent(string arg) =>
        Verify(arg)
            .HashParameters();

    #endregion
}