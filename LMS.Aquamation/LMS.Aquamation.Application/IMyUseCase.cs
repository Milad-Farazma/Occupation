namespace LMS.Aquamation.Application;

public interface IMyUseCase {
    Task<ItemDto> GetItemAsync(int id);
}