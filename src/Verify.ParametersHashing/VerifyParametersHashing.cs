#pragma warning disable AppendParameter
#pragma warning disable UseParametersAppender

namespace VerifyTests;

public static class VerifyParametersHashing
{
    public static void Initialize() =>
        Initialized = true;

    public static bool Initialized { get; private set; }

    static string HashString(string value)
    {
        var data = XxHash64.Hash(Encoding.UTF8.GetBytes(value));

        return Convert.ToHexStringLower(data);
    }

    /// <summary>
    /// Hash parameters together for received and verified file name.
    /// Used to get a deterministic file name while avoiding long paths.
    /// </summary>
    public static void HashParameters(this VerifySettings settings) =>
        settings.UseParametersAppender((values, counter) =>
            builder =>
            {
                //TODO: use a more efficient way to hash the parameters that doesn't require an innerBuilder
                // uses an innerBuilder and VerifierSettings.AppendParameter to maintain
                // the file naming of the pre-existing feature in the core of Verify
                var innerBuilder = new StringBuilder();
                foreach (var value in values)
                {
                    innerBuilder.Append('_');
                    innerBuilder.Append(value.Key);
                    innerBuilder.Append('=');
                    VerifierSettings.AppendParameter(value.Value, innerBuilder, true, counter);
                }

                builder.Append('_');
                builder.Append(HashString(innerBuilder.ToString()));
            });

    /// <summary>
    /// Hash parameters together for received and verified file name.
    /// Used to get a deterministic file name while avoiding long paths.
    /// </summary>
    [Pure]
    public static SettingsTask HashParameters(this SettingsTask settings)
    {
        settings.CurrentSettings.HashParameters();
        return settings;
    }
}