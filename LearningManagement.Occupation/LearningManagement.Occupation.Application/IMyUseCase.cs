namespace LearningManagement.Occupation.Application;

public interface IMyUseCase {
    Task<ItemDto> GetItemAsync(int id);
}