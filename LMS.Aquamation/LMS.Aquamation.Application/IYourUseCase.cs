namespace LMS.Aquamation.Application;

public interface IYourUseCase {
    Task<ItemDto> GetItemAsync(int id);
}