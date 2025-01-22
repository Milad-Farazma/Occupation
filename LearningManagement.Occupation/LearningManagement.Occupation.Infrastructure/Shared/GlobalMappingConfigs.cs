namespace LearningManagement.Occupation.Infrastructure.Shared;

public class GlobalMappingConfigs : IRegister {
    public void Register(TypeAdapterConfig config) {
        // Ensures references are preserved (to avoid circular references).
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

        TypeAdapterConfig.GlobalSettings.Compile();
    }
}